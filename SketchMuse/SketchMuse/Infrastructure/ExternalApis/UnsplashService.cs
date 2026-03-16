namespace SketchMuse.Infrastructure.ExternalApis
{
    public class UnsplashService
    {
         private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public UnsplashService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<List<ImagenDTO>> LlamadaApiUnsplash(string textoBusqueda, int numImagenes)
        {
            var apiKey = _config["UnsplashApi:ApiKey"];
            string busquedaSinEspacios = Uri.EscapeDataString(textoBusqueda);
            var url = $"https://api.unsplash.com/search/photos?query={busqueda}&per_page={numImagenes}&client_id={apiKey}";

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
                    Url = img.GetProperty("urls").GetProperty("raw").GetString(),
                    Titulo = img.TryGetProperty("alt_description", out JsonElement titleEl) ? titleEl.GetString(): ""
                });
            }

            return imagenes;
        }
    }
}
