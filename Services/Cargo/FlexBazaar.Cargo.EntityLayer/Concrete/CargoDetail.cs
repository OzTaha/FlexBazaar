﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBazaar.Cargo.EntityLayer.Concrete
{
    public class CargoDetail
    {
        public int CargoDetailId { get; set; }
        // gönderen müşteri
        public string SenderCustomer { get; set; }
        // alıcı müşteri 
        // mongoDb'den gelen id kullanılacağı için string türünde tanımlandı. Çünkü mongo db'de id string olarak tanımlanmıştı. Ayrıca MongoDb'de id'ler default olarak ObjectId türündedir.
        public string ReceiverCustomer { get; set; }
        public int Barcode { get; set; }
        // kargo firması
        public int CargoCompanyId { get; set; }
        // kargo firması property'si
        public CargoCompany CargoCompany { get; set; }
    }
}
