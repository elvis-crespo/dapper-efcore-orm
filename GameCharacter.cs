
namespace Dapper_Efcore
{
    internal class GameCharacter
    {
        public int GameCharacterId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PowerLevel { get; set; } 
        public string Weapon { get; set; } = string.Empty;
    }
}
