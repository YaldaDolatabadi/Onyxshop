namespace Onyxshop.Models
{
    public class SabadItem
    {

        public int Id { get; set; }
   
        public decimal price { get; set; }
        public int quantityinstock { get; set; }

        //چرا productid نذاشت؟


        //navigation
       
        public product product { get; set; }
    }
}
