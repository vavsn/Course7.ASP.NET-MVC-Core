using CoureProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoureProject.DAL.Context;
public class CoureProjectDB : DbContext
{
    //public DbSet<City> Cities { get; set; }
    //public DbSet<Parent> Parents{ get; set; }
    //public DbSet<Source> Sources{ get; set; }
    //public DbSet<Weather> Weathers { get; set; }
    public DbSet<Consolidated_Weather> Consolidated_Weathers { get; set; }

    public CoureProjectDB(DbContextOptions<CoureProjectDB> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder model)
    {
        base.OnModelCreating(model);
        //model.Entity<Source>()
        //    .HasKey(x => new { x.title });
        //model.Entity<Parent>()
        //    .HasKey(x => new { x.title });
        //model.Entity<City>()
        //    .HasKey(x => new { x.Id});
        //model.Entity<Weather>()
        //    .HasKey(x => new { x.id });
        model.Entity<Consolidated_Weather>()
            .HasKey(x => new { x.woeid });
    }
}
