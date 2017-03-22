using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Models.Reponses
{
    public class RequestModel
    {
        public class Sichuan
        {
            [JsonProperty("fpcy.fpdm")]
            public string fpdm { get; set; }

            [JsonProperty("fpcy.fphm")]
            public string fphm { get; set; }

            [JsonProperty("fpcy.type")]
            public string type { get; set; }

            //fpcy.fpdm:151001665018
            //fpcy.fphm:01444200
            //fpcy.type:0
        }
    }
}
