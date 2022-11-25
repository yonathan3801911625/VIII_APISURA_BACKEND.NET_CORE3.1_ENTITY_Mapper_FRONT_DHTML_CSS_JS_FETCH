using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PolizasVehiculos.Core.Entidades.Paypal
{
    public class PaypalAPI
    {
        public IConfiguration _configuration { get; }

        public PaypalAPI(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public async Task<string> getRedirectURLToPayPal() 
        {
            try
            {
                /*return Task.Run(async () => 
                {
                    HttpClient http = GetPaypalHttpCleint();
                    PaypalAccessToken accessToken = await GetPayPalAccessTokenAsync(http);
                    PayPalPaymentCreatedResponse createdPaymnet = CreatePaypalPaymentAsync(http, accessToken);
                    return createdPaymnet.links.First(x => x.rel == "").heref;
                }).Result;*/
                return null;
            }
            catch (Exception Ex) {
                Debug.WriteLine(Ex,"Fallo login Paypal");
                return null;
            }
        }

        private PayPalPaymentCreatedResponse CreatePaypalPaymentAsync(HttpClient http, PaypalAccessToken accessToken)
        {
            throw new NotImplementedException();
        }

        private Task<PaypalAccessToken> GetPayPalAccessTokenAsync(HttpClient http)
        {
            throw new NotImplementedException();
        }

        private HttpClient GetPaypalHttpCleint()
        {
            throw new NotImplementedException();
        }
    }
}
