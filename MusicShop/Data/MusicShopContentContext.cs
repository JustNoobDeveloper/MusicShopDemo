using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicShop.Models
{
    public class MusicShopContentContext : DbContext
    {
        public MusicShopContentContext (DbContextOptions<MusicShopContentContext> options)
            : base(options)
        {
        }

        public DbSet<Test> Test { get; set; }
    }
}
