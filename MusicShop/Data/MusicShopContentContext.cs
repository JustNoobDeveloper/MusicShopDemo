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
		public DbSet<Genre> Genre { get; set; }
		public DbSet<Music> Music { get; set; }
		public DbSet<Sales> Sales { get; set; }
	}
}
