using System.Collections.Generic;
using System.ComponentModel;

namespace MusicShop.Models
{
    public class Genre
    {
        public int ID { get; set; }
        [DisplayName("Genre Name")]
        public string GenreName { get; set; }
    }
}
