

namespace Infraestructura.Repositories.Models.Response
{
    public class PokemonResponse
    {
        public List<Ability> abilities { get; set; }
        public List<Form> forms { get; set; }

    }
    public class Ability
    {
        public Ability2 ability { get; set; }
        public bool is_hidden { get; set; }
        public int slot { get; set; }
    }

    public class Ability2
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    public class Form
    {
        public string name { get; set; }
        public string url { get; set; }
    }



}
