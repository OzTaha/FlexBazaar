namespace FlexBazaar.RapidApiWebUI.Models
{
    public class ECommerceViewModel
    {

        public class Rootobject
        {
            public string status { get; set; }
            public string request_id { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public Product[] products { get; set; }
            public object[] sponsored_products { get; set; }
        }

        public class Product
        {
            public string product_id { get; set; }
            public string product_title { get; set; }
            public string price { get; set; }
            public string product_offer_page_url { get; set; }
            public bool on_sale { get; set; }
            public string product_photo { get; set; }
            public string store_name { get; set; }
            public string store_favicon { get; set; }
            public float product_rating { get; set; }
            public int product_num_reviews { get; set; }
            public object shipping { get; set; }
            public string original_price { get; set; }
        }

    }
}
