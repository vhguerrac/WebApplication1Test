using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Data;
using Newtonsoft.Json;


namespace Business
{
    public class FBusiness
    {
        
        public async Task<IEnumerable<object>> GetEmployees()
        {
            string json = string.Empty;
            string href = "http://masglobaltestapi.azurewebsites.net/api/Employees";

            Uri uri = new Uri(href);

            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                DateTime time = DateTime.Now;

                try
                {
                    response = await client.GetAsync(uri);
                }
                catch (Exception ex)
                {
                    throw new Exception("network error", ex);
                }
                json = await response.Content.ReadAsStringAsync();

            }
            IEnumerable<object> result = JsonConvert.DeserializeObject<IEnumerable<object>>(json);
            return result;
        }
    }
}
