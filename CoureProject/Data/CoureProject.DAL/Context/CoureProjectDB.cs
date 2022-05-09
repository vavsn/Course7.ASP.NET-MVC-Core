using CoureProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoureProject.DAL.Context;
public class CoureProjectDB : DbContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<Parent> Parents{ get; set; }
    public DbSet<Source> Sources{ get; set; }
    public DbSet<Weather> Weathers{ get; set; }

    public CoureProjectDB(DbContextOptions<CoureProjectDB> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder model)
    {
        base.OnModelCreating(model);
        model.Entity<Parent>()
            .HasNoKey();
        model.Entity<Source>()
            .HasNoKey();
    }
}
