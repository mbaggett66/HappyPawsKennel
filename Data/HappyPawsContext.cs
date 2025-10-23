using HappyPawsKennel.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HappyPawsKennel.Data
{
    public class HappyPawsContext : DbContext
    {
        public HappyPawsContext(DbContextOptions<HappyPawsContext> options)
            : base(options)
        {
        }

        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Kennel> Kennels { get; set; }
    }
}
