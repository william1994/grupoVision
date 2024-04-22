using clienteGrupoVision.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace clienteGrupoVision.Controllers
{
    public class pokemonController : Controller
    {
        public tokenjwt GenerarToken(user user)
        {
           
            user.nombreUsuario = "william";
            user.clave = "123";
            RestClient rest = new RestClient("http://localhost:5046/");
            var request = new RestRequest("/api/user/Autenticar", Method.Post) { RequestFormat = DataFormat.Json };
            string jsonModel = JsonConvert.SerializeObject(user, Formatting.Indented);
            request.AddParameter("application/json", jsonModel, ParameterType.RequestBody);
            var result = rest.Post(request);
            switch (result.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<tokenjwt>(result.Content);
                case HttpStatusCode.NotFound:
                    return new tokenjwt();
                default:
                    return null;

            }
        }
        public pokemon ObtenerHabilidades(string nombrePokemon)
        {
            user usuario= new user();
            var token = GenerarToken(usuario);

            RestClient rest = new RestClient("http://localhost:5046/");
            var request = new RestRequest($"/api/user/pokemon{nombrePokemon}", Method.Get);
            rest.AddDefaultHeader("Authorization", string.Format("Bearer {0}", token.token));
            var result = rest.Get(request);
            switch (result.StatusCode)
            {
                case HttpStatusCode.OK:
                    return JsonConvert.DeserializeObject<pokemon>(result.Content);
                case HttpStatusCode.NotFound:
                    return new pokemon();
                default:
                    return null;

            }

        }
        public IActionResult Index(string nombre)
        {
           var user= HttpContext.Session.GetString("usuario");
            if(user!=null)
            return View(ObtenerHabilidades(nombre));
            else
                return NoAccess();
            
            
        }
        public IActionResult NoAccess()
        {

            return View("NoAccess");
        }
        [HttpPost]
        public IActionResult log(string userName,string clave) { 
            user usuario = new user();
            usuario.nombreUsuario = userName;
            usuario.clave = clave;
          var r=  GenerarToken(usuario);
            if (r.msg.Equals("Ok"))
            {
                 HttpContext.Session.SetString("usuario",userName);

                return View("pokemonName");
            }
            else { return NoAccess(); } 
                
       
        }
    }
}
