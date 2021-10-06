using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebFrontEnd.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public async Task OnGet()
    {
        ViewData["Message"] = "Hello from webFrontEnd";

        using (var client=new HttpClient())
        {
            var request =new HttpRequestMessage();
            request.RequestUri = new Uri("http://mywebapi/WeatherForecast");
            var response = client.Send(request);
            ViewData["Message"] += " and " + await response.Content.ReadAsStringAsync();
        }
    }
}