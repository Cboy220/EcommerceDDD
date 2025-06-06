// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace EcommerceDDD.ServiceClients.ApiGateway.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class OrderViewModel : IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The createdAt property</summary>
        public DateTimeOffset? CreatedAt { get; set; }
        /// <summary>The currencySymbol property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CurrencySymbol { get; set; }
#nullable restore
#else
        public string CurrencySymbol { get; set; }
#endif
        /// <summary>The customerId property</summary>
        public Guid? CustomerId { get; set; }
        /// <summary>The orderId property</summary>
        public Guid? OrderId { get; set; }
        /// <summary>The orderLines property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::EcommerceDDD.ServiceClients.ApiGateway.Models.OrderLineViewModel>? OrderLines { get; set; }
#nullable restore
#else
        public List<global::EcommerceDDD.ServiceClients.ApiGateway.Models.OrderLineViewModel> OrderLines { get; set; }
#endif
        /// <summary>The quoteId property</summary>
        public Guid? QuoteId { get; set; }
        /// <summary>The statusCode property</summary>
        public int? StatusCode { get; set; }
        /// <summary>The statusText property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? StatusText { get; set; }
#nullable restore
#else
        public string StatusText { get; set; }
#endif
        /// <summary>The totalPrice property</summary>
        public double? TotalPrice { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::EcommerceDDD.ServiceClients.ApiGateway.Models.OrderViewModel"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::EcommerceDDD.ServiceClients.ApiGateway.Models.OrderViewModel CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::EcommerceDDD.ServiceClients.ApiGateway.Models.OrderViewModel();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "createdAt", n => { CreatedAt = n.GetDateTimeOffsetValue(); } },
                { "currencySymbol", n => { CurrencySymbol = n.GetStringValue(); } },
                { "customerId", n => { CustomerId = n.GetGuidValue(); } },
                { "orderId", n => { OrderId = n.GetGuidValue(); } },
                { "orderLines", n => { OrderLines = n.GetCollectionOfObjectValues<global::EcommerceDDD.ServiceClients.ApiGateway.Models.OrderLineViewModel>(global::EcommerceDDD.ServiceClients.ApiGateway.Models.OrderLineViewModel.CreateFromDiscriminatorValue)?.AsList(); } },
                { "quoteId", n => { QuoteId = n.GetGuidValue(); } },
                { "statusCode", n => { StatusCode = n.GetIntValue(); } },
                { "statusText", n => { StatusText = n.GetStringValue(); } },
                { "totalPrice", n => { TotalPrice = n.GetDoubleValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteDateTimeOffsetValue("createdAt", CreatedAt);
            writer.WriteStringValue("currencySymbol", CurrencySymbol);
            writer.WriteGuidValue("customerId", CustomerId);
            writer.WriteGuidValue("orderId", OrderId);
            writer.WriteCollectionOfObjectValues<global::EcommerceDDD.ServiceClients.ApiGateway.Models.OrderLineViewModel>("orderLines", OrderLines);
            writer.WriteGuidValue("quoteId", QuoteId);
            writer.WriteIntValue("statusCode", StatusCode);
            writer.WriteStringValue("statusText", StatusText);
            writer.WriteDoubleValue("totalPrice", TotalPrice);
        }
    }
}
#pragma warning restore CS0618
