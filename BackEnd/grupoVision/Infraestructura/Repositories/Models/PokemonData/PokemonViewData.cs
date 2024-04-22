using AutoMapper;
using Core.Dto;
using Core.Interfaces;
using Infraestructura.Interface;
using Infraestructura.Repositories.Models.Dto;

namespace Infraestructura.Repositories.Models.PokemonData
{
    public class PokemonViewData : IPokemonViewData
    {
        private readonly Ipokemon _ipokemon;
        private readonly IMapper _mapper;

        public PokemonViewData(Ipokemon ipokemon, IMapper mapper)
        {
            _ipokemon = ipokemon;
            _mapper = mapper;
        }

        public PokemonDto PokemonDataAbilitiesImg(string nombrePokemon)
        {
            var ability = _ipokemon.ObtenerHabilidades(nombrePokemon);
            var url = ability.forms.FirstOrDefault();
            var img = _ipokemon.obtenerImagen(url.url);
            var a = new PokemonDataDto { abilities = ability, urlImg = img };
            dataEx dataEx = new dataEx();
            foreach (var ae in ability.abilities) {
                
                dataEx.abilities.Add(ae.ability.name);
            }
            dataEx.url = img.sprites.front_default;

            var result = _mapper.Map<PokemonDto>(dataEx);
            return result;
        }
    }
}
