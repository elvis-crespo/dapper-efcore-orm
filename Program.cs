
using Dapper_Efcore;

var repository = new GameCharacterRepository();

Console.WriteLine("EFCore");
repository.EF_Create();
repository.EF_Update();
repository.EF_Read();
repository.EF_Delete();
Console.WriteLine("\n");
repository.EF_Read();


Console.WriteLine("Dapper");
repository.Dapper_Create();
repository.Dapper_Update();
repository.Dapper_Read();
repository.Dapper_Delete();
Console.WriteLine("\n");
repository.Dapper_Read();


