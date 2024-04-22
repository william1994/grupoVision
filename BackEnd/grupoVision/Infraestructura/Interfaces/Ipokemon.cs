using Infraestructura.Repositories.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Interface
{
    public interface Ipokemon
    {
        public PokemonResponse ObtenerHabilidades(string nombrePokemon);
        public ImageResponse obtenerImagen(string url);

    }
}
