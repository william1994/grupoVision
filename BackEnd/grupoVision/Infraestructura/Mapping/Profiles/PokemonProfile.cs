using AutoMapper;
using Core.Dto;
using Infraestructura.Repositories.Models.Dto;

namespace Infraestructura.Mapping.Profiles
{
    public class PokemonProfile: Profile
    {
        public PokemonProfile() {

            CreateMap<dataEx, PokemonDto>();
        }
    }
}
