using System.ComponentModel.DataAnnotations;

namespace ReactApi.Model
{
    public class Product
    {
        [Key]
        public int Prodct_Id { get; set; }
        public string Product_Name { get; set; }
        public float Product_price { get; set; }
        public DateTime Product_expityDate { get; set; }
    }
}
