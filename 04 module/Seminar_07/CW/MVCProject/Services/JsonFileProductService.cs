using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

public class JsonFileProductService
{
    public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
    {
        WebHostEnvironment = webHostEnvironment;
    }

    public IWebHostEnvironment WebHostEnvironment { get; }

    private string JsonFileName =>
        Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");

    public IEnumerable<Product> GetProducts()
    {
        using (var jsonFileReader = File.OpenText(JsonFileName))
        {
            return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}