
using ExampleRazorTemplatesLibrary.Models;
using Razor.Templating.Core;

namespace ExampleWorkerService.Net6_0;
public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            System.Console.WriteLine(DateTime.Now);
            var model = new ExampleModel()
            {
                PlainText = "Some text",
                HtmlContent = "<em>Some emphasized text</em>"
            };

            var viewData = new Dictionary<string, object>();
            viewData["Value1"] = "1";
            viewData["Value2"] = "2";

            var html = await RazorTemplateEngine.RenderAsync("/Views/ExampleView.cshtml", model, viewData);
            System.Console.Write(html);
            System.Console.WriteLine(DateTime.Now);
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine("{0}", e);
        }
    }
}
