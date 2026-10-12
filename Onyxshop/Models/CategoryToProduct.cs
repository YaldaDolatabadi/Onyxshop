namespace Onyxshop.Models
{
    //واقعیتش دلیلشو درست نفهمدم ول ظاهرا یک گروه-محصول را تعریف میکند 
    public class CategoryToProduct
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        //Navigation Property
        public Category category { get; set; }
        public product product { get; set; }
    }
}
