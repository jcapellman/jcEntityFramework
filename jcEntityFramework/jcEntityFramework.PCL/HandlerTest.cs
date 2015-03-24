using System;
using System.Collections.Generic;
using System.Net.Http;

using jcEntityFramework.PCL.Transports;

using Newtonsoft.Json;

namespace jcEntityFramework.PCL {
    public class HandlerTest {
        private readonly string _address;

        public HandlerTest(string address) { _address = address; }

        private HttpClient getHttpClient()
        {
            
            var handler = new HttpClientHandler();

            var client = new HttpClient(handler) { Timeout = TimeSpan.FromMinutes(5) };

            return client;
        }

        private T GetSync<T>(string urlArguments) {
           
                var client = getHttpClient();

                var str = client.GetStringAsync(String.Format(_address + "{0}", urlArguments)).GetAwaiter().GetResult();

                return JsonConvert.DeserializeObject<T>(str);
           
        }

        public List<jcSelectTest> Get(bool useEF) { return GetSync<List<jcSelectTest>>(String.Format("Test?useEF={0}", useEF)); } 
    }
}
