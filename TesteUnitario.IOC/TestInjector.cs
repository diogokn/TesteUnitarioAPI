using Microsoft.Extensions.DependencyInjection;
using System;
using TesteUnitario.ServiceProxy;

namespace TesteUnitario.IOC
{
    public static class TestInjector
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.AddScoped<IProdutoService, ProdutoService>();
        }
    }
}