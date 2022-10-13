namespace Net6;

public class DomainContextFixed : DbContext
{
    public DomainContextFixed(DbContextOptions<DomainContextFixed> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .Property(p => p.Dob)
            .HasConversion
            (
                src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
            );
    }

    public static DomainContextFixed Create(string conStr)
    {
        var optionBuilder = new DbContextOptionsBuilder<DomainContextFixed>();
        optionBuilder.UseNpgsql(conStr, db => db.MigrationsAssembly("DbSetup"));
        return new DomainContextFixed(optionBuilder.Options);
    }

    public virtual DbSet<Person> People { get; set; }
}
