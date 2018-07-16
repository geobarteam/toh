using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TOHWebApi.Model;
using TOHWebApi.Repository;

namespace TOHWebApi.Controllers
{
    
    public class HeroesController:Controller
    {
        private readonly IHeroesRepository _heroesRepository;

        public HeroesController(IHeroesRepository heroesRepository)
        {
            _heroesRepository = heroesRepository;
        }

        [Route("api/heroes")]
        public async Task<ActionResult> GetAll([FromQuery] string filter)
        {
            IEnumerable<Hero> result;
            if (String.IsNullOrEmpty(filter))
            {
                result = await _heroesRepository.GetAll();
            }
            else
            {
                result = await _heroesRepository.GetAll(filter);
            }
            
            return new JsonResult(result);
        }
        
        [Route("api/heroes/{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _heroesRepository.GetById(id);

            return new JsonResult(result);
        }




    }
}
