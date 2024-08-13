using Dapper;
using Microsoft.Data.SqlClient;

namespace Dapper_Efcore
{
    public class GameCharacterRepository
    {
        private readonly string connectionString = "Server={key};Database={key};Integrated Security=True; TrustServerCertificate=True";
        private GameContext context;
        public GameCharacterRepository()
        {
            context = new GameContext();
        }

        //EFc: ORM
        public void EF_Create()
        {
            var character = new GameCharacter
            {
                Name = "Test",
                PowerLevel = 10010,
                Weapon = "sword"
            };
            context.GameCharacters.Add(character);
            context.SaveChanges();
        }
        public void EF_Read()
        {
            var character = context.GameCharacters.FirstOrDefault(x => x.Name == "Test");
            Console.WriteLine($"Character: {character?.Name} \nPower Level: {character?.PowerLevel} \nWeapon: {character?.Weapon}");
        }
        public void EF_Update()
        {
            var character = context.GameCharacters.FirstOrDefault(x => x.Name == "Test");
            if (character != null)
            {
                character.Weapon = "Hammer";
                context.SaveChanges();
            }
        }
        public void EF_Delete()
        {
            var character = context.GameCharacters.FirstOrDefault(x => x.Name == "Test");
            if (character != null)
            {
                context.GameCharacters.Remove(character);
                context.SaveChanges();
            }
        }

        //Dapper: Micro ORM
        public void Dapper_Create()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO GameCharacters (Name, PowerLevel, Weapon) VALUES (@Name, @PowerLevel, @Weapon)";
                connection.Execute(insertQuery,
                    new { Name = "Okito", PowerLevel = 10054, Weapon = "Fire Sword" });
            }
        }
        public void Dapper_Read()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM GameCharacters WHERE Name = @Name";
                var character = connection.QueryFirstOrDefault<GameCharacter>(selectQuery,
                    new { Name = "Test" });
                Console.WriteLine($"Character: {character?.Name} \nPower Level: {character?.PowerLevel} \nWeapon: {character?.Weapon}");
            }
        }
        public void Dapper_Update()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE GameCharacters set Weapon = @Weapon WHERE Name = @Name";
                connection.Execute(updateQuery,
                    new { Name = "Test", Weapon = "Wooden Sword" });
            }
        }
        public void Dapper_Delete()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM GameCharacters WHERE Name = @Name";
                connection.Execute(deleteQuery,
                    new { Name = "Test" });
            }
        }
    }
}
