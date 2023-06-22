using DockerAPIDataModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerAPIDataModels.Interface
{
    public interface IAnimal
    {
        //Return all Animals
        List<Animal> GetAllAnimals();

        //Return single Animal
        Animal GetAnimal(int id);
    }
}
