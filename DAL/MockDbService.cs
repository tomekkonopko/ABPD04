using APBD04.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD04.DAL
{
    public class MockDbService
    {
        private static IEnumerable<Animal> _animals;
        static MockDbService()
        {
            _animals = new List<Animal>
            {
                new Animal{ IdAnimal="1", Name="Pies1", Descripton="Piesowaty", Category="Piesek", Area="Tarzania"},
                new Animal{ IdAnimal="2", Name="Pies2", Descripton="Piesowaty1", Category="Piesek1", Area="Tarzania1"},
                new Animal{ IdAnimal="3", Name="Pies3", Descripton="Piesowaty2", Category="Piesek2", Area="Tarzania2"}
            };
        }
        public IEnumerable<Animal> GetAnimals()
        {
            return _animals;
        }
    }
}
