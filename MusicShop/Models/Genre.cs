using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicShop.Models
{
    public class Genre
    {
        public int ID { get; set; }
        [DisplayName("Genre Name")]
        public string GenreName { get; set; }

        public ICollection<Music> Musics { get; set; }
    }
}
