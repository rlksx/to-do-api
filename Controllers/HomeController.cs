using Microsoft.AspNetCore.Mvc;
using to_do_api.Data;
using to_do_api.Models;

namespace to_do_api.Controllers
{
    [ApiController] //=> definindo como ApiController, só tem função de retornar json;
    // [Route("home")] //=> route definido mo prefixo de de todas as rotas abaixo;
    public class HomeControllers : ControllerBase
    {
        /* actions - métodos dentro de uma controller */

        [HttpGet("/")] //=> informa que é uma actions do tipo get, serve como route tbm;
        // [Route("/")] //=> https://localhost:7072/home/
        public IActionResult Get([FromServices] AppDbContext context) //=> instanciando AppDbContext com com Services;
            => Ok(context.ToDoModels.ToList());

        [HttpGet("/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id, //=> indicando que o parâmetro é recebido da rota
            [FromServices] AppDbContext context)
        {
            var ToDo = context.ToDoModels.FirstOrDefault(x => x.Id == id); //=> recuperando ToDo com o id do parâmetro
            if (ToDo == null)
                return NotFound();

            return Ok(ToDo);
        }

        [HttpPost("/")]
        public IActionResult Post(
            [FromBody] ToDoModel NewToDo,
            [FromServices] AppDbContext context)
        {
            context.ToDoModels.Add(NewToDo);
            context.SaveChanges();

            return Created($"/{NewToDo.Id}", NewToDo);
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromBody] ToDoModel ToDoUpdated,
            [FromServices] AppDbContext context)
        {
            var ToDo = context.ToDoModels.FirstOrDefault(x => x.Id == id);
            if (ToDo == null)
                return NotFound();

            ToDo.Title = ToDoUpdated.Title;
            ToDo.Done = ToDoUpdated.Done;

            context.ToDoModels.Update(ToDo);
            context.SaveChanges();
            return Ok(ToDo);
        } 

            [HttpDelete("/{id:int}")]
             public IActionResult Delete(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var ToDo = context.ToDoModels.FirstOrDefault(x => x.Id == id);
            if(ToDo == null)
                return NotFound();

            context.ToDoModels.Remove(ToDo);
            context.SaveChanges();
            return Ok(ToDo);
        }           
    }
}