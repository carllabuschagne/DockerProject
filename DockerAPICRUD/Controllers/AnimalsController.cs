using DockerAPIDataModels.Interface;
using DockerAPIDataModels.Model;
using DockerAPIDataModels.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DockerAPICRUD.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        //Define Repo
        private readonly AnimalRepository _animalRepository;
        private NpgsqlConnection connection;

        private IConfiguration Configuration;

        //Constructor
        public AnimalsController(IConfiguration _configuration)
        {
            Configuration = _configuration;

            connection = new NpgsqlConnection(this.Configuration.GetConnectionString("postgres"));
            connection.Open();

            string commandText = "SELECT * FROM Animals";
            using (NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                       
                    }
            }

            //Populate Repo from Repo
            _animalRepository = new AnimalRepository();

            connection.Close();
        }

        //GET : /v1/Animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        {
            if (_animalRepository.Animals == null)
            {
                return NotFound();
            }

            return _animalRepository.Animals.ToList();
        }

        //GET : /v1/Animals
        [HttpGet("{Id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int Id)
        {
            if (_animalRepository.Animals == null)
            {
                return NotFound();
            }

            var animal = _animalRepository.Animals.Find(model => model.Id == Id);

            if (animal == null)
            {
                return NotFound();
            }

            return animal;
        }

        //POST : /v1/Animals
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
        {
            _animalRepository.Animals.Add(animal);
            return CreatedAtAction(nameof(GetAnimal), new { Id = animal.Id }, animal);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<Animal>> PutAnimal(int Id, Animal animal)
        {
            if (Id != animal.Id)
            {
                return BadRequest();
            }

            Animal _animal = _animalRepository.Animals.Find(model => model.Id == Id);

            if (_animal == null)
            {
                return NotFound();
            }

            return NoContent();

        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Animal>> DeleteAnimal(int Id)
        {
            if (_animalRepository.Animals == null)
            {
                return NotFound();
            }

            Animal animal = _animalRepository.Animals.Find(model => model.Id == Id);

            if (animal == null)
            {
                return NotFound();
            }

            return NoContent();

        }

    }
}
