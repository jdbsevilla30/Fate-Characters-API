using FateCharactersAPI;
using Microsoft.EntityFrameworkCore;
namespace FateCharactersAPI.Data
{
    public class DataContext : DbContext
    {
       public DataContext(DbContextOptions<DataContext> options) : base(options){       }

         

        public DbSet<FateCharacter> CharacterDetails {get; set; }
    }

   
}
 