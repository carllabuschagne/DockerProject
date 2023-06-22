using DockerAPIDataModels.Interface;
using DockerAPIDataModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerAPIDataModels.Repository
{
    public class AnimalRepository
    {
        public AnimalRepository() { }

        public List<Animal> Animals = new List<Animal> {
            new Animal {Id = 1, Name = "dog", Description = "brown", Type="mammal"},
            new Animal {Id = 2, Name = "dog", Description = "brown", Type="mammal"},
            new Animal {Id = 3, Name = "dog", Description = "brown", Type="mammal"},
            new Animal {Id = 4, Name = "dog", Description = "brown", Type="mammal"},
            new Animal {Id = 5, Name = "dog", Description = "brown", Type="mammal"},
            new Animal {Id = 6, Name = "dog", Description = "brown", Type="mammal"},
            new Animal {Id = 7, Name = "dog", Description = "brown", Type="mammal"}
        };

        public List<Animal> GetAllAnimals()
        {
            return Animals;
        }

        public Animal GetAnimal(int Id)
        {
            return Animals.FirstOrDefault<Animal>(m => m.Id == Id);
        }





    }
}
