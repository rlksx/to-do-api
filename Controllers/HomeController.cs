using Microsoft.AspNetCore.Mvc;

namespace to_do_api.Controllers
{
    [ApiController] //=> definindo como ApiController, só tem função de retornar json;
    // [Route("home")] //=> route definido mo prefixo de de todas as rotas abaixo;
    public class HomeControllers : ControllerBase
    {
        /* actions - métodos dentro de uma controller */

        [HttpGet("home")] //=> informa que é uma actions do tipo get, serve como route tbm;
        // [Route("/")] //=> https://localhost:7072/home/
        public string Get()
        {
            return "Hello World";
        }
    }
}