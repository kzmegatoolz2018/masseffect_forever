using masseffect_forever.Models;
using Microsoft.EntityFrameworkCore;

namespace masseffect_forever.Data
{
    public class MassEffectContext : DbContext
    {
        public MassEffectContext(DbContextOptions<MassEffectContext> options) : base(options)
        {
        }
        
        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<PlotFlag> PlotFlags { get; set; } = null!;
        public DbSet<RomanticInterest> RomanticInterests { get; set; } = null!;
        public DbSet<Biography> Biographies { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Отношения между сущностями
            modelBuilder.Entity<Character>()
                .HasOne(c => c.Biography)
                .WithOne(b => b.Character)
                .HasForeignKey<Biography>(b => b.CharacterId);
                
            modelBuilder.Entity<RomanticInterest>()
                .HasOne(r => r.Character)
                .WithMany(c => c.RomanticInterests)
                .HasForeignKey(r => r.CharacterId);
                
            // Начальные данные загружаются через класс DataSeeder
        }
    }
}
