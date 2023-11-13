using MyCar.Entities;

namespace MyCar
{
    public class DataContext
    {
        public List<Selling> SellList { get; set; }
        public List<Renting> RentList { get; set; }
        public List<Garage> GaragesList { get; set; }

        public DataContext()
        {
            SellList=new List<Selling>();
            RentList=new List<Renting>();   
            GaragesList=new List<Garage>(); 
        }
    }
}
