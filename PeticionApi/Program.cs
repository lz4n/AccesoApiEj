using PeticionApi.Model;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace PeticionApi
{
    internal class Program
    {
        private static string ApiURI = "https://petstore.swagger.io/v2/", PostPetEndpoint = "pet";

        static async Task Main(string[] args)
        {
            using (HttpClient client = new() { BaseAddress = new Uri(ApiURI) })
            {
                try
                {
                    HttpResponseMessage response = await client.PutAsJsonAsync(PostPetEndpoint, new Pet { Id = 0, Name = "DOGGIE" });

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("La mascota se ha insertado correctamente: ");
                        Console.WriteLine(await response.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        Console.WriteLine($"Ha ocurrido un error insertando la mascota: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error en la manipulación de JSON: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Operación no válida: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Se ha producido una excepción no controlada: {ex.Message}");
                }
            }
        }
    }
}
