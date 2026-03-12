using SketchMuse.Domain.DTOs;
using System.Text.Json;

namespace SketchMuse.Infrastructure.ExternalApis
{
    public class BingImageService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public BingImageService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<List<ImagenDTO>> LlamadaApiBing(string textoBusqueda, int numImagenes)
        {
            var apiKey = _config["BingApi:ApiKey"];
            string busquedaSinEspacios = Uri.EscapeDataString(textoBusqueda);
            var url = $"https://serpapi.com/search?engine=bing_images&q={busquedaSinEspacios}&count={numImagenes}&api_key={apiKey}";

            var response = await _httpClient.GetAsync(url);
            //comprueba que la respuesta sea 200-299 y si no lo es lanza una excepción
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var document = JsonDocument.Parse(json);

            if (!document.RootElement.TryGetProperty("images_results", out JsonElement listaImagenes))
            {
                Console.WriteLine("No se encontraron resultados: " + json);
                return new List<ImagenDTO>();
            }

            var imagenes = new List<ImagenDTO>();

            foreach (var img in listaImagenes.EnumerateArray())
            {
                imagenes.Add(new ImagenDTO
                {
                    Url = img.GetProperty("link").GetString(),
                    Titulo = img.TryGetProperty("title", out JsonElement titleEl)? titleEl.GetString(): ""
                });
            }

            return imagenes;
        }
    }
}
