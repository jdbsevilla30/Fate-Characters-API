using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FateCharactersAPI.Controllers
{
    [Route("api/fatecharacters")]
    [ApiController]
    public class FateCharacterController : ControllerBase
    {
        private static List<FateCharacter> FateCharacter = new List<FateCharacter>
            {
            new FateCharacter {
                Id = 1,
                ServantName = "string",
                NoblePhantasm = "string",
                Class ="string",
                Origin = "string"
             } 
            };

        private readonly DataContext _context;

        public FateCharacterController(DataContext context)
        {
            _context  = context;
        }

        [HttpGet]   //api/fatecharacters
        public async Task<ActionResult<List<FateCharacter>>> GetCharacter()
        {
            return Ok(await _context.CharacterDetails.ToListAsync()); //return status code of 200, and the character result.
        }

        [HttpGet("{id}")]   //api/fatecharacters/{id} === return only the one with the same id which is called. 
        public async Task<ActionResult<List<FateCharacter>>> Get(int id)
        {
       

            var character = await _context.CharacterDetails.FindAsync(id);

            if(character == null) //checks if the character is non-existent
            {
                return BadRequest("Character not found."); //return a bad request error 400, if the character is non existent 
            }

            return Ok(character); //return status code of 200, and the character with of the same index. 
        }

        [HttpPost] //Adds a new character to our API. 
        public async Task<ActionResult<List<FateCharacter>>> AddCharacter(FateCharacter character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad request");
            }

            _context.CharacterDetails.Add(character);
            await _context.SaveChangesAsync();

            return Ok(await _context.CharacterDetails.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<FateCharacter>>> UpdateCharacter(FateCharacter request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Bad request");
            }

            var dbCharacter= await _context.CharacterDetails.FindAsync(request.Id);

            if (dbCharacter== null) //checks if the character is non-existent
            {
                return BadRequest("Character not found."); //return a bad request error 400, if the character is non existent 
            }
 
            dbCharacter.ServantName = request.ServantName; //change character name
            dbCharacter.Class = request.Class; //change character last name
            dbCharacter.Origin = request.Origin; //change character place
            dbCharacter.NoblePhantasm = request.NoblePhantasm; //change character first name
            await _context.SaveChangesAsync();

            return Ok(await _context.CharacterDetails.ToListAsync());
        }
        
        [HttpDelete("{id}")] //deletes the character with the same id

        public async Task<ActionResult<List<FateCharacter>>> DeleteCharacter(int id)
        {
            var character = await _context.CharacterDetails.FindAsync(id);

            if (character == null) //checks if the character is non-existent.
            {
                return BadRequest("Character not found."); //return a bad request error 400, if the character we're trying to
                                                           //delete is non-existent.
            }

            _context.CharacterDetails.Remove(character);
            await _context.SaveChangesAsync();

            return Ok(await _context.CharacterDetails.ToListAsync());
        }

    }
}
