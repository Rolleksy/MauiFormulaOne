using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataPuller
{
    public class APIService
    {
        private readonly string _apiUrl;
        public APIService(string url)
        {
            _apiUrl = url;
        }

        public async Task<string> GetStringFromAPIAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Wysyłamy żądanie GET do API i oczekujemy odpowiedzi
                    HttpResponseMessage response = await httpClient.GetAsync(_apiUrl);

                    // Sprawdzamy, czy odpowiedź jest pomyślna (200 OK)
                    if (response.IsSuccessStatusCode)
                    {
                        // Odczytujemy zawartość odpowiedzi jako tekst (JSON)
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        return jsonResponse;
                    }
                    else
                    {
                        // Obsługujemy błędy, jeśli odpowiedź z API jest niepomyślna
                        Console.WriteLine("Nieudane żądanie. Status code: " + response.StatusCode);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    // Obsługujemy wyjątki, które mogą wystąpić podczas komunikacji z API
                    Console.WriteLine("Wystąpił błąd: " + ex.Message);
                    return null;
                }
            }
        }
        

    }

    
}
