using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TOHWebApi.Model;
using TOHWebApi.Repository;

namespace TOHWebApi.Controllers
{
    [Route("api/[controller]")]
    public class HeroesController:Controller
    {
        private readonly IHeroesRepository _heroesRepository;

        public HeroesController(IHeroesRepository heroesRepository)
        {
            _heroesRepository = heroesRepository;
        }

        
        public async Task<ActionResult> GetAll([FromQuery]string filter)
        {
            var result = _heroesRepository.GetAll(filter);

            return new JsonResult(result);
        }


    }
}
