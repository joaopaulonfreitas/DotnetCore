using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try{

                var results = await _context.Eventos.ToListAsync();
                return Ok(results);

            }
            catch(Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar bando de dados");
            }
        }

        // api/values/1
        [HttpGet("{id}")]
        public ActionResult<Evento> Get(int id)
        {

            try{

                var results = _context.Eventos.ToList().FirstOrDefault(x => x.EventId == id);
                return Ok(results);
                
            }
            catch(Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar bando de dados");
            }
        }


    }
}