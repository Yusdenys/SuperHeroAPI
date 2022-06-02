using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero {
                    Id = 1,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                },
                new SuperHero {
                    Id = 2,
                    Name = "IronMan",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Place = "Long Island"
                }
            };

        /**
         * GET Method usin Web API
         */
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        /**
         * GET Method usin Web API, find by Id
         */
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heroes.Find(x => x.Id == id);
            if (hero == null)
                return BadRequest("Hero not found!");
            return Ok(hero);
        }

        /*
         * POST Method usin Web API
         */
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        /*
         * PUT Method usin Web API
         */
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {

            var hero = heroes.Find(x => x.Id == request.Id);
            if (hero == null)
                return BadRequest("Hero not found!");

            hero.Name = request.Name;
            hero.FirstName = request.FirstName; 
            hero.LastName = request.LastName;   
            hero.Place = request.Place;

            return Ok(heroes);
        }

        /*
         * DELETE Method usin Web API
        */

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = heroes.Find(x => x.Id == id);
            if (hero == null)
                return BadRequest("Hero not found!");
            heroes.Remove(hero);
            return Ok(heroes);
        }


    }
}
