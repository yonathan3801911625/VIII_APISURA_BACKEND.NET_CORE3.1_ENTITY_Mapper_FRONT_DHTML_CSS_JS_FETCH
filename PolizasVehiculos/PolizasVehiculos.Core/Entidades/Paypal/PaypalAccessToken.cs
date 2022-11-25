using System;
using System.Collections.Generic;
using System.Text;

namespace PolizasVehiculos.Core.Entidades.Paypal
{
    public class PaypalAccessToken
    {
        public int expires_in { get; set; }

        public string access_token { get; set; }

        public string tokenType { get; set; }

        public string app_id { get; set; }

        public string nonce { get; set; }

        public string scope { get; set; }
    }
}
