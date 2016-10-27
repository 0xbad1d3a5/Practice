using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * An animal shelter holds only dogs and cats, and operates on a strictly "first in,
 * first out" basis. People must adopt either the "oldest" (based on arrival time) of
 * all animals at the shelter, or they can select whether they would prefer a dog or
 * a cat (and will receive the oldest animal of that type). They cannot select which
 * specific animal they would like. Create the data structures to maintain this system
 * and implement operations such as enqueue, dequeueAny, dequeueDog and
 * dequeueCat. You may use the built-in LinkedList data structure.
 */
namespace Cracking.Chapter03
{
    /*
     * Does not support multi-threaded applications
     */
    public class AnimalShelter
    {
        int arrivalTime = 0;
        private LinkedList<Dog> listDog = new LinkedList<Dog>();
        private LinkedList<Cat> listCat = new LinkedList<Cat>();

        public void enqueue(Animal animal)
        {
            arrivalTime++;
            animal.ArrivalTime = arrivalTime;

            if (animal is Cat)
            {
                listCat.AddLast((Cat)animal);
            }
            else if (animal is Dog)
            {
                listDog.AddLast((Dog)animal);
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        public Animal dequeueAny()
        {
            Animal animal;
            
            if (listDog.Count == 0 && listCat.Count == 0)
            {
                return null;
            }
            else if (listDog.Count == 0)
            {
                animal = listCat.First();
                listCat.RemoveFirst();
            }
            else if (listCat.Count == 0)
            {
                animal = listDog.First();
                listDog.RemoveFirst();
            }
            else
            {
                if (listCat.First().ArrivalTime < listDog.First().ArrivalTime)
                {
                    animal = listCat.First();
                    listCat.RemoveFirst();
                }
                else
                {
                    animal = listDog.First();
                    listDog.RemoveFirst();
                }
            }

            return animal;
        }

        public Animal dequeueDog()
        {
            if (listDog.Count == 0)
            {
                return null;
            }

            Animal animal = listDog.First();
            listDog.RemoveFirst();
            return animal;
        }

        public Animal dequeueCat()
        {
            if (listCat.Count == 0)
            {
                return null;
            }

            Animal animal = listCat.First();
            listCat.RemoveFirst();
            return animal;
        }
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name)
        {
        }
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name)
        {
        }
    }

    public class Animal
    {
        public int ArrivalTime { get; set; }
        public string Name { get; private set; }

        public Animal(string name)
        {
            this.Name = name;
        }
    }

    [TestClass]
    public class Tests_03_07
    {
        [TestMethod]
        public void Test()
        {
            AnimalShelter animalShelter = new AnimalShelter();
            animalShelter.enqueue(new Dog("D1"));
            animalShelter.enqueue(new Dog("D2"));
            animalShelter.enqueue(new Dog("D3"));
            animalShelter.enqueue(new Cat("C1"));
            animalShelter.enqueue(new Dog("D4"));
            animalShelter.enqueue(new Cat("C2"));
            animalShelter.enqueue(new Dog("D5"));
            animalShelter.enqueue(new Cat("C3"));
            animalShelter.enqueue(new Dog("D6"));

            Assert.AreEqual("D1", animalShelter.dequeueAny().Name);
            Assert.AreEqual("C1", animalShelter.dequeueCat().Name);
            Assert.AreEqual("D2", animalShelter.dequeueAny().Name);
            Assert.AreEqual("D3", animalShelter.dequeueDog().Name);

            Assert.AreEqual("D4", animalShelter.dequeueAny().Name);
            Assert.AreEqual("C2", animalShelter.dequeueAny().Name);
            Assert.AreEqual("D5", animalShelter.dequeueAny().Name);
            Assert.AreEqual("C3", animalShelter.dequeueAny().Name);
            Assert.AreEqual("D6", animalShelter.dequeueAny().Name);

            Assert.AreEqual(null, animalShelter.dequeueAny());
        }
    }
}
