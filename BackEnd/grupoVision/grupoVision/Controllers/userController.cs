using Core.Dto;
using Core.Interface;
using Infraestructura.Repositories.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Security.Policy;


namespace grupoVision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class userController : ControllerBase
    {
        private readonly IUseCaseUser _useCaseUser;
        private readonly IAutorizacionService _autorizacionService;
        private readonly IUseCasePokemon _pokemon;

        public userController(IUseCaseUser useCaseUser, IAutorizacionService autorizacionService, IUseCasePokemon pokemon)
        {
            _useCaseUser = useCaseUser;
            _autorizacionService = autorizacionService;
           _pokemon = pokemon;
        }

        [HttpPost]
        [Route("Autenticar")]
        public IActionResult Autenticar([FromBody] AutorizacionRequest autorizacion)        
            {
            var validacion = _useCaseUser.ValidacionUsuario(autorizacion.NombreUsuario, autorizacion.Clave).FirstOrDefault();
            if (validacion!=null)
            {
                var resultado_autorizacion = _autorizacionService.DevolverToken(autorizacion, validacion.Id.ToString());
                return  Ok(resultado_autorizacion);

            }
            else {
                return Unauthorized();
            }
            

        }
        [HttpGet("pokemon{nombrePokemon}")]
        [Authorize]
        public IActionResult pokemon(string nombrePokemon) {
            var respo = _pokemon.Pokemon(nombrePokemon);
        return Ok(respo);
        }
    }
}
