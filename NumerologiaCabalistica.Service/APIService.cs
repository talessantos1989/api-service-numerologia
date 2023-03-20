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
            Console.WriteLine("SEND API INICIADO");
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
                    Console.WriteLine($"RESPONSE =======> {response.Content.ReadAsStringAsync().Result}");
                    if (response != null)
                    {
                        var res = response.Content.ReadAsStringAsync().Result;
                        Console.WriteLine($"#### RESULT #### {res}"); 
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
