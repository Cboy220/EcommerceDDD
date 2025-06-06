﻿namespace EcommerceDDD.IdentityServer.Services;

public class IdentityManager(
	ITokenRequester tokenRequester,
	UserManager<ApplicationUser> userManager,
	IOptions<TokenIssuerSettings> issuerSettings,
	RoleManager<IdentityRole> roleManager) : IIdentityManager
{
	private readonly ITokenRequester _tokenRequester = tokenRequester
		?? throw new ArgumentNullException(nameof(tokenRequester));
	private readonly UserManager<ApplicationUser> _userManager = userManager
		?? throw new ArgumentNullException(nameof(userManager));
	private readonly TokenIssuerSettings _issuerSettings = issuerSettings.Value
		?? throw new ArgumentNullException(nameof(issuerSettings));
	public readonly RoleManager<IdentityRole> _roleManager = roleManager
		?? throw new ArgumentNullException(nameof(roleManager));

	public async Task<LoginResult> AuthUserByCredentials(LoginRequest request)
	{
		var response = await _tokenRequester.GetUserTokenFromCredentialsAsync(
			request.Email, request.Password
		);

		if (response.HttpStatusCode == HttpStatusCode.BadRequest)
			throw new ApplicationException($"Invalid username or password.");

		return new LoginResult()
		{
			AccessToken = response.AccessToken,
			ErrorDescription = response.ErrorDescription,
			IdentityToken = response.IdentityToken,
			RefreshToken = response.RefreshToken,
		};
	}

	public async Task<UserRegisteredResult> RegisterNewUser(RegisterUserRequest request)
	{
		await AddDefaultRoles();

		var user = new ApplicationUser
		{
			UserName = request.Email,
			Email = request.Email,
			EmailConfirmed = true,
		};

		// Creating user
		var result = await _userManager
			.CreateAsync(user, request.Password);
		if (!result.Succeeded)
			throw new ApplicationException(result.Errors.First().Description);

		// Adding role
		result = await _userManager
			.AddToRoleAsync(user, Roles.Customer);
		if (!result.Succeeded)
			throw new ApplicationException($"Can't add role for {user.Email}");

		// Adding claims
		result = await _userManager.AddClaimsAsync(user,
			new Claim[]
			{
				new Claim(JwtClaimTypes.Subject, user.Id),
				new Claim(JwtClaimTypes.Name, user.UserName),
				new Claim(JwtClaimTypes.Email, user.Email),
				new Claim(JwtClaimTypes.Role, Roles.Customer),
				new Claim(IdentityConfiguration.CustomerIdClaimType, request.CustomerId.ToString())
			});
		if (!result.Succeeded)
			throw new ApplicationException($"Can't add claims for {user.Email}");

		return new UserRegisteredResult()
		{
			UserId = user.Id,
			Succeeded = result.Succeeded
		};
	}

	private async Task AddDefaultRoles()
	{
		var clientRole = await _roleManager
			.FindByNameAsync(Roles.Customer);

		if (clientRole is null)
		{
			var result = await _roleManager
				.CreateAsync(new IdentityRole(Roles.Customer));

			if (!result.Succeeded)
				throw new ApplicationException($"Can't add role {Roles.Customer}");
		}

		await Task.CompletedTask;
	}
}