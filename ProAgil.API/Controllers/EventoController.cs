using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        public readonly IProAgilRepository _repo;

        public EventoController(IProAgilRepository repo)
        {
            _repo = repo;
        }

        #region GET

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllEventosAsync(true);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar bando de dados");
            }
        }

        [HttpGet("{EventoId}")]
        public async Task<IActionResult> Get(int EventoId)
        {
            try
            {
                var results = await _repo.GetEventoAsyncById(EventoId, true);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar bando de dados");
            }
        }

        [HttpGet("getByTema/{tema}")]
        public async Task<IActionResult> Get(string tema)
        {
            try
            {
                var results = await _repo.GetAllEventosAsyncByTema(tema, true);
                return Ok(results);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar bando de dados");
            }
        }

        #endregion

        #region POST

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangeAsync())
                {
                    return Created($"api/evento/{model.Id}", model);
                }

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar bando de dados");
            }

            return BadRequest();
        }

        #endregion

        #region PUT

        [HttpPut]
        public async Task<IActionResult> Put(Evento model)
        {
            try
            {

                var Evento = await _repo.GetEventoAsyncById(model.Id, false);
                if (Evento == null)
                    return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangeAsync())                
                    return Created($"api/evento/{model.Id}", model);                

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar bando de dados");
            }

            return BadRequest();
        }

        #endregion

        #region DELETE

        [HttpDelete("{EventoId}")]
        public async Task<IActionResult> Delete(int EventoId)
        {
            try
            {

                var Evento = await _repo.GetEventoAsyncById(EventoId, false);

                if (Evento == null)
                    return NotFound();

                _repo.Delete(Evento);

                if (await _repo.SaveChangeAsync())                
                    return Ok($"Evento {EventoId} removido com sucesso!");                

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar bando de dados");
            }

            return BadRequest();
        }

        #endregion
       

    }
}