using ControleDeMedicamentos.ConsoleApp.Compartilhado;
using ControleDeMedicamentos.ConsoleApp.ModuloEntrada;
using ControleDeMedicamentos.ConsoleApp.ModuloRequisicaoDeSaida;
using ControleDeMedicamentos.ConsoleApp.Util;

namespace ControleDeMedicamentos.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        WebApplication app = builder.Build();

        app.UseStaticFiles();
        app.UseRouting();
        app.MapControllers();

        app.Run();
    }
}
