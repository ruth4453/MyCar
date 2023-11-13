using Microsoft.AspNetCore.Mvc;
using MyCar.Entities;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentingController : ControllerBase
    {
        private DataContext _context;
        private static int Id = 0;
        public RentingController(DataContext context)
        {
            _context = context;
        }
        // GET: api/<RentingController>
        [HttpGet]
        public IEnumerable<Renting> Get()
        {
            return _context.RentList;
        }

        // GET api/<RentingController>/5
        [HttpGet("{id}")]
        public ActionResult <Renting> Get(int id)
        {
            var r= _context.RentList.Find(x => x.Id == id);
            if(r == null)
            {
                return NotFound();
            }
            return r;
        }

        // POST api/<RentingController>
        [HttpPost]
        public Renting Post([FromBody] Renting renting)
        {      
            var newRent=new Renting {Id=Id+1, Company=renting.Company, Model=
                renting.Model,SeveralPlaces=renting.SeveralPlaces,
                DateTaken = renting.DateTaken,
                returnDate = renting.returnDate,
                Price = renting.Price};
            _context.RentList.Add(newRent);
            return newRent;
        }

        // PUT api/<RentingController>/5
        [HttpPut("{id}")]
        public ActionResult <Renting> Put(int id, [FromBody] Renting renting)
        {
            var r= _context.RentList.Find(x => x.Id == id);
            if(r == null)
            {
                return NotFound();
            }
            r = renting;
            return r;

        }

        // DELETE api/<RentingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var r = _context.RentList.Find(x => x.Id == id);
            _context.RentList.Remove(r);
        }
    }
}
