using Repository.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataContexts
{
    public class MainDataContext : DbContext
    {
        public MainDataContext() : base("MemeQueen")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MainDataContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Meme> Memes { get; set; }
        public DbSet<CustomMessage> CustomMessages { get; set; }
    }
}
