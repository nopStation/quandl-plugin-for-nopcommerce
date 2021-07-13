using Nop.Core.Configuration;

namespace Nop.Plugin.ExchangeRate.Quandl
{
    public class QuandlSettings : ISettings
    {
        /// <summary>
        /// Gets or sets an API key
        /// </summary>
        public string ApiKey { get; set; }
    }
}
