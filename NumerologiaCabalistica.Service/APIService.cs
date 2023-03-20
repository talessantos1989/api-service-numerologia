using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NumerologiaCabalistica.Repository;
using System.Net.Http.Json;

namespace NumerologiaCabalistica.Service
{

    public class APIService
    {

        public async static Task<Customer> SendAPI(Customer customer)
        {

            HttpResponseMessage responseMessage = new HttpResponseMessage();
            try
            {

                using (var client = new HttpClient())
                {
                    //TODO: arrumar isso aqui
                    client.BaseAddress = new Uri("https://api-service-numerologia-production.up.railway.app/api/CalculoCabalistico");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync(client.BaseAddress.AbsoluteUri, customer);
                    if (response != null)
                    {
                        var res = response.Content.ReadAsStringAsync().Result;
                        customer.MapFile = JsonConvert.DeserializeObject<Customer>(res).MapFile;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"***** Erro ****: {ex}");
            }
            return customer;


        }


    }
}
