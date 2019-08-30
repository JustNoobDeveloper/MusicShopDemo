using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    public class Music
    {
        public int ID { get; set; }
        [DisplayName("Music Name")]
        public string MusicName { get; set; }
        [DisplayName("Artist Name")]
        public string ArtistName { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
