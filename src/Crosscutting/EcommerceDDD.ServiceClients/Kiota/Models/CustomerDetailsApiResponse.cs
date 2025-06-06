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
    public partial class CustomerDetailsApiResponse : IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The data property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::EcommerceDDD.ServiceClients.ApiGateway.Models.CustomerDetails? Data { get; set; }
#nullable restore
#else
        public global::EcommerceDDD.ServiceClients.ApiGateway.Models.CustomerDetails Data { get; set; }
#endif
        /// <summary>The message property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Message { get; set; }
#nullable restore
#else
        public string Message { get; set; }
#endif
        /// <summary>The success property</summary>
        public bool? Success { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::EcommerceDDD.ServiceClients.ApiGateway.Models.CustomerDetailsApiResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::EcommerceDDD.ServiceClients.ApiGateway.Models.CustomerDetailsApiResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::EcommerceDDD.ServiceClients.ApiGateway.Models.CustomerDetailsApiResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "data", n => { Data = n.GetObjectValue<global::EcommerceDDD.ServiceClients.ApiGateway.Models.CustomerDetails>(global::EcommerceDDD.ServiceClients.ApiGateway.Models.CustomerDetails.CreateFromDiscriminatorValue); } },
                { "message", n => { Message = n.GetStringValue(); } },
                { "success", n => { Success = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::EcommerceDDD.ServiceClients.ApiGateway.Models.CustomerDetails>("data", Data);
            writer.WriteStringValue("message", Message);
            writer.WriteBoolValue("success", Success);
        }
    }
}
#pragma warning restore CS0618
