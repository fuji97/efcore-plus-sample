using Microsoft.EntityFrameworkCore;

namespace SampleEFCorePlus.Models; 

public class FooContext : DbContext {
    public DbSet<Foo> Foos { get; set; } = null!;
    public DbSet<Bar> Bars { get; set; } = null!;
    public DbSet<FooBar> FooBars { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("Data Source=Application.db;Cache=Shared");
        base.OnConfiguring(optionsBuilder);
    }
}