using Microsoft.EntityFrameworkCore;

namespace Dapper_Efcore
{
    internal class GameContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server={key};Database={key};Integrated Security=True; TrustServerCertificate=True");
        }
        public DbSet<GameCharacter> GameCharacters { get; set; }
    }
}
