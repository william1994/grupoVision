using Core.Interface;
using Core.Interfaces;
using Core.UseCase;
using Infraestructura.Interface;
using Infraestructura.Interfaces;
using Infraestructura.Repositories.Contexts;
using Infraestructura.Repositories.httpClients;
using Infraestructura.Repositories.Models.Autorizacion;
using Infraestructura.Repositories.Models.PokemonData;
using Infraestructura.Repositories.Models.userRepo;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructura.Configuration
{
    public class DependecyInjectionConfig
    {
        public static void ResgisterService(IServiceCollection services) { 
        
            services.AddScoped<IUserContex,GrupoVisionContext>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUseCaseUser, UseCaseUser>();
            services.AddScoped<IAutorizacionService, AutorizacionService>();
            services.AddScoped<Ipokemon, Pokemon>();
            services.AddScoped<IPokemonViewData, PokemonViewData>();
            services.AddScoped<IUseCasePokemon, useCasePokemon>();

        }
    }
}
