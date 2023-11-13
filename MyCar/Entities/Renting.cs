namespace MyCar.Entities
{
    public class Renting
    {
        public int Id { get; set; } 
        public string Company { get; set; }
        public int Model { get; set; }
        public int SeveralPlaces { get; set; }
        public int DateTaken {  get; set; }
        public int returnDate { get; set; }
        public int Price { get; set; }
    }
}
