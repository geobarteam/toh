using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TOHWebApi.Model;

namespace TOHWebApi.Controllers
{
    [Route("api/[controller]")]
    public class HeroesController:Controller
    {
        public async Task<ActionResult> GetAll()
        {
            var mockValues = new[]
            {
                new Heroe { Id = 11, Name = "Mr. Nice"},
                new Heroe { Id = 12, Name = "Narco"},
                new Heroe { Id = 13, Name = "Bombasto" },
                new Heroe { Id = 14, Name = "Celeritas"},
                new Heroe { Id = 15, Name = "Magneta"},
                new Heroe { Id = 16, Name = "RubberMan" },
                new Heroe { Id = 17, Name = "Dynama"},
                new Heroe { Id = 18, Name = "Dr. IQ"},
                new Heroe { Id = 19, Name = "Magma" },
                new Heroe { Id = 20, Name = "Tornado"}
            };

            return new JsonResult(mockValues);
        }
    }
}
