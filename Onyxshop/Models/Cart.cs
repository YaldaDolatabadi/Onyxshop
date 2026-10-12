namespace Onyxshop.Models
{
    //درواقع عملا فاکتور ماست
    public class Cart
    {
        public Cart()
        {
            cartItems = new List<CartItem>();
        }


        public int orderId { get; set; }
        public List<CartItem> cartItems { get; set; }

        //دو تا متد لازم داریم
        //// یکی برای اضافه کردن آیتم

        public void addItem(CartItem item)
        {   //اگر آیتم ورودی در لیست وجود داشت
            if (cartItems.Exists(x => x.SabadItem.Id==item.SabadItem.Id))
            {
                
                //آن رکورد در لیست را که برابر آیتم ورودی است پیدا کرده
                //و یک واحد به آن در فاکتور اضافه کن
                cartItems.Find(i => i.SabadItem.Id == item.SabadItem.Id)
                    .quantityincart += 1;
            }
            else
            {
                cartItems.Add(item);
            }
        }

        ////یکی برای کم کردن یا حذف آیتم
        public void removeItem (int itemid)
        {
            var itemm=
                cartItems.SingleOrDefault(c=>c.SabadItem.Id == itemid);
            
            if (itemm?.quantityincart<=1)
            { cartItems.Remove(itemm); }
            else if (itemm!=null) 
            {
                itemm.quantityincart -= 1; 
            }



        }

    }
}
