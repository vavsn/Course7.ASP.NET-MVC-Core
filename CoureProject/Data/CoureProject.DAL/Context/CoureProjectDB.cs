using CoureProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoureProject.DAL.Context;
public class CoureProjectDB : DbContext
{
    public DbSet<Consolidated_Weather> Consolidated_Weathers { get; set; }

    public CoureProjectDB(DbContextOptions<CoureProjectDB> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder model)
    {
        base.OnModelCreating(model);
        model.Entity<Consolidated_Weather>()
            .HasKey(x => new { x.woeid });
    }
}
