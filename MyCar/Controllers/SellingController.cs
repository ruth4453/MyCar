using Microsoft.AspNetCore.Mvc;
using MyCar.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellingController : ControllerBase
    {
        private DataContext _context;
        private static int Id = 0;

        public SellingController(DataContext context)
        {
            _context = context;
        }
        // GET: api/<SellingController>
   [HttpGet]
        public IEnumerable<Selling> Get()
        {
            return _context.SellList;
        }

        // GET api/<SellingController>/5
        [HttpGet("{id}")]
        public ActionResult <Selling> Get(int id)
        {
            var s= _context.SellList.Find(x=> x.Id==id);
            if (s == null)
            {
                return NotFound();
            }
            return s;
        }

        // POST api/<SellingController>
        [HttpPost]
        public Selling Post([FromBody] Selling selling)
        {
            var newSell = new Selling
            {
                Id = Id + 1,
                Company = selling.Company,
                Model =selling.Model,
                Year = selling.Year,     
                SeveralPlaces = selling.SeveralPlaces,
                UnitsInStock = selling.UnitsInStock,
                Price = selling.Price
            };
            _context.SellList.Add(newSell);
            return newSell;
        }

        // PUT api/<SellingController>/5
        [HttpPut("{id}")]
        public ActionResult <Selling> Put(int id, [FromBody] Selling selling)
        {
            var s= _context.SellList.Find(x=> x.Id == id);
            if (s == null)
            {
                return NotFound();
            }
            s = selling;
            return s;
        }

        // DELETE api/<SellingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var s = _context.SellList.Find(x => x.Id == id);
            _context.SellList.Remove(s);

        }
    }
}
