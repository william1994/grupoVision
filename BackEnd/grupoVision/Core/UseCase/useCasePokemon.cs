using Core.Dto;
using Core.Interface;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase
{
    public class useCasePokemon : IUseCasePokemon
    {
        private readonly IPokemonViewData _pokemonViewData;

        public useCasePokemon(IPokemonViewData pokemonViewData)
        {
            _pokemonViewData = pokemonViewData;
        }

        public  PokemonDto Pokemon(string nombrePokemon)
        {
            var respuesta = _pokemonViewData.PokemonDataAbilitiesImg(nombrePokemon);
            return respuesta;
        }
    }
}
