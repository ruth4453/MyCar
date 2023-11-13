using Microsoft.AspNetCore.Mvc;
using MyCar.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarageController : ControllerBase
    {
        private DataContext _context;
        private static int Id = 0;
        public GarageController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<GarageController>
        [HttpGet]
        public IEnumerable<Garage> Get()
        {
            return _context.GaragesList;
        }

        // GET api/<GarageController>/5
        [HttpGet("{id}")]
        public ActionResult <Garage> Get(int id)
        {
            var g= _context.GaragesList.Find(x=> x.Id==id);
            if (g == null)
            {
                return NotFound();
            }
            return g;
        }

        // POST api/<GarageController>
        [HttpPost]
        public Garage Post([FromBody] Garage gar)
        {
            var newGar=new Garage{ Id = Id + 1,City=gar.City,Street=
                    gar.Street,EngineerName=gar.EngineerName};
            _context.GaragesList.Add(newGar);
            return newGar;
        }

        // PUT api/<GarageController>/5
        [HttpPut("{id}")]
        public ActionResult <Garage> Put(int id, [FromBody] Garage gar)
        {
            var g= _context.GaragesList.Find(x=>x.Id==id);
            if (g == null)
            {
                return NotFound();
            }
            g = gar;
            return g;
        }

        // DELETE api/<GarageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var g = _context.GaragesList.Find(x => x.Id == id);
            _context.GaragesList.Remove(g);

        }
    }
}
