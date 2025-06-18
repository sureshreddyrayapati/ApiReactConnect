using System.ComponentModel.DataAnnotations;

namespace ReactApi.Model
{
    public class Cooldrink
    {
        [Key]
        public int Drink_Id { get; set; }
        public string Dring_Name {  get; set; }
        public string Quantity { get; set; }
        public float Price { get; set; }

    }
}
