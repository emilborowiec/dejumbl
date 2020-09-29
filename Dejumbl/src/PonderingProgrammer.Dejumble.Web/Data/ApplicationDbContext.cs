using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PonderingProgrammer.Dejumble.Web.Model;

namespace PonderingProgrammer.Dejumble.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Context> Contexts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Context>().HasKey(c => new {c.OwnerUserName, c.ContextKey});

            builder.Entity<Relation>().Property<string>("SourceId");
            builder.Entity<Relation>().Property<string>("TargetId");
            builder.Entity<Relation>().HasKey("SourceId", "TargetId");
            builder.Entity<Relation>()
                   .HasOne(r => r.Source)
                   .WithMany(i => i.OutgoingRelations)
                   .HasForeignKey("SourceId");
            builder.Entity<Relation>()
                   .HasOne(r => r.Target)
                   .WithMany()
                   .HasForeignKey("TargetId");
        }
    }
}