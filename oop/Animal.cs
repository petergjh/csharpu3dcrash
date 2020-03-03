using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    class Animal
    {
        private string name;
        private static Animal animal;
        private Animal()
        {

        }

        public static Animal Create()
        {
            if(animal == null)
            {
                animal = new Animal("fashi");
            }
            return animal;
        }

        private Animal(string name)
        {
            this.name = name;
        }

       }
}
