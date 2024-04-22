using Infraestructura.Interface;
using Infraestructura.Repositories.Models.Response;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositories.httpClients
{
    public class Pokemon : Ipokemon
    {

            public PokemonResponse ObtenerHabilidades(string nombrePokemon)
            {

                RestClient rest = new RestClient("https://pokeapi.co/");
                var request = new RestRequest($"/api/v2/pokemon/{nombrePokemon}", Method.Get);

                var result = rest.Get(request);
                switch (result.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return JsonConvert.DeserializeObject<PokemonResponse>(result.Content);
                    case HttpStatusCode.NotFound:
                        return new PokemonResponse();
                    default:
                        return null;

                }
  
            }

        public ImageResponse obtenerImagen(string url)
        {
            var request = new RestRequest(url, Method.Get);
            RestClient rest = new RestClient(url);
            var result = rest.Get(request);
            switch (result.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<ImageResponse>(result.Content);
                case HttpStatusCode.NotFound:
                    return new ImageResponse();
                default:
                    return null;

            }
        }
    }
}
