

using Infraestructura.Repositories.Models.Response;

namespace Infraestructura.Repositories.Models.Dto
{
    public class PokemonDataDto
    {
        public PokemonResponse abilities { get; set; }
        public ImageResponse urlImg { get; set; }
    }
    
}
