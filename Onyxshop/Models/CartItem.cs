namespace Onyxshop.Models
{
    public class CartItem
    {
        //چرا cartid نداره؟
        public int Id { get; set; } //انگار این برای ما نقطه تفکیک نیست بلکه sabaditem است
        public SabadItem SabadItem { get; set; }
        public int quantityincart { get; set; }

        public decimal gettotalprice ()
        {
            return quantityincart * SabadItem.price;
        }
    }
}
