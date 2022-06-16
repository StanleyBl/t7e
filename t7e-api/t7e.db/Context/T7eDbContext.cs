using Microsoft.EntityFrameworkCore;
using t7e.db.Entities;

namespace t7e.db.Context
{
    public class T7eDbContext : DbContext
    {
        public T7eDbContext(DbContextOptions<T7eDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<TranslationKey> TranslationKeys { get; set; }
        public virtual DbSet<Translation> Translations { get; set; }
        public virtual DbSet<ProjectLanguage> ProjectLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.ProjectLanguages)
                .WithOne(e => e.Project);

            modelBuilder.Entity<ProjectLanguage>()
                .HasKey(e => new {e.LanguageId, e.ProjectId});
        }
    }
}
