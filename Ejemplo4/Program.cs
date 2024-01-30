using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Ejemplo4
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<string> endpoints = new List<string>
            {
            "http://localhost:5000/users",
            "http://localhost:5000/products",
            
            };
            // Consumir datos de varios endpoints en paralelo
            await Task.WhenAll(endpoints.ConvertAll(async endpoint => await FetchDataAsync(endpoint)));

            Console.WriteLine("Consumo de datos completado.");
            Console.WriteLine("Presione cualquier tecla para cerrar...");
    
            Console.Read();
        }


        static async Task FetchDataAsync(string endpoint)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(endpoint);
                    response.EnsureSuccessStatusCode(); 

                    var content = await response.Content.ReadAsStringAsync();
                    

                    Console.WriteLine($"Datos de {endpoint}: {content}");
                    Console.WriteLine();
                   

                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error al obtener datos de {endpoint}: {ex.Message}");
                }
            }
        }

        

    }

}
