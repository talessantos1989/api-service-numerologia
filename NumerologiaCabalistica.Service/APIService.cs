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
            Console.WriteLine($"SEND API INICIADO {customer.NomeCompleto}");
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                using (var client = new HttpClient())
                {
                    //TODO: arrumar isso aqui
                    client.BaseAddress = new Uri("https://api-service-numerologia-production.up.railway.app/api/CalculoCabalistico");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    response = await client.PostAsJsonAsync(client.BaseAddress.AbsoluteUri, customer);
                    Console.WriteLine($"RESPONSE =======> {response}");
                    if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var res = response.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(String.Format("#### RESULT #### {0}", res)); 
                        customer.MapFile = JsonConvert.DeserializeObject<Customer>(res).MapFile;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"***** Erro ****: {ex.StackTrace}");
            }
            return customer;
        }
    }
}
