using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    public class Sales
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string PaymentMethod { get; set; }
        public Decimal Total { get; set; }
    }
}
