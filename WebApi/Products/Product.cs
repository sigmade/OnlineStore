namespace WebApi.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public static List<Product> InitializeProductList()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "iPhone 13", Description = "Смартфон Apple с экраном 6.1 дюйма и поддержкой 5G", Price = 79990m },
                new Product { Id = 2, Name = "Samsung Galaxy S21", Description = "Флагманский смартфон Samsung с тройной камерой и экраном 6.2 дюйма", Price = 69990m },
                new Product { Id = 3, Name = "Xiaomi Redmi Note 10", Description = "Бюджетный смартфон Xiaomi с большим экраном и хорошей батареей", Price = 19990m },
                new Product { Id = 4, Name = "Google Pixel 6", Description = "Смартфон Google с чистым Android и улучшенной камерой", Price = 59990m },
                new Product { Id = 5, Name = "OnePlus 9 Pro", Description = "Смартфон OnePlus с экраном 120 Гц и быстрой зарядкой", Price = 64990m },
                new Product { Id = 6, Name = "Sony Xperia 5 III", Description = "Компактный смартфон Sony с отличной камерой и OLED-экраном", Price = 74990m },
                new Product { Id = 7, Name = "Huawei P40 Pro", Description = "Смартфон Huawei с камерой Leica и высоким качеством фото", Price = 55990m },
                new Product { Id = 8, Name = "Oppo Find X3 Pro", Description = "Флагманский смартфон Oppo с инновационным дизайном и отличной камерой", Price = 72990m },
                new Product { Id = 9, Name = "Vivo X60 Pro", Description = "Смартфон Vivo с камерой, настроенной совместно с Zeiss", Price = 48990m },
                new Product { Id = 10, Name = "Motorola Edge 20", Description = "Смартфон Motorola с поддержкой 5G и хорошим соотношением цена/качество", Price = 34990m },
                new Product { Id = 11, Name = "Realme GT Master Edition", Description = "Смартфон Realme с хорошей производительностью и стильным дизайном", Price = 27990m },
                new Product { Id = 12, Name = "Nokia G50", Description = "Смартфон Nokia с большим экраном и поддержкой 5G", Price = 19990m },
                new Product { Id = 13, Name = "Asus ROG Phone 5", Description = "Игровой смартфон Asus с высокими характеристиками и мощной батареей", Price = 84990m },
                new Product { Id = 14, Name = "Poco X3 Pro", Description = "Смартфон Poco с хорошим соотношением цена/производительность и большим экраном", Price = 23990m },
                new Product { Id = 15, Name = "Honor 50", Description = "Смартфон Honor с отличной камерой и поддержкой 5G", Price = 39990m }
            };
        }
    }
}