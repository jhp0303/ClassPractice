using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice1
{
    public static class PracticeClass
    {
        struct Rectangle
        {
            public double length;
            public double width;

            public Rectangle(double l, double w)
            {
                length = l;
                width = w;
            }

            public void print()
            {
                Console.WriteLine("[L] width{0}, length:{1}, Area{2}", width, length, Area());
            }

            public double Area()
            {
                return length * width;
            }
        }

        public static void practice1()
        {
            Console.WriteLine(String.Empty);
            Console.WriteLine("Struct");
            Console.WriteLine("=======================");

            Rectangle rect1;
            rect1.width = 100;
            rect1.length = 30;

            rect1.print();

            // Console.WriteLine("[L] width{0}, length:{1}, Area{2}", rect1.width, rect1.length, rect1.Area());

            Rectangle rect2 = new Rectangle(200, 50);

            rect2.print();

            //Console.WriteLine("[L] width{0},, length:{1}, Area{2}", rect2.width, rect2.length, rect2.Area());


            Console.WriteLine(String.Empty);
            Console.WriteLine("Class Animal");
            Console.WriteLine("=======================");

            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal("fox", "Raww"));
            animals.Add(new Animal("dog", "Woof"));
            animals.Add(new Animal("cat", "Mewww"));

            /* //  바로 아래 foreach와 같음
            for (int i = 0; i < animals.Count; i++)
            {
                Animal thisAnimal = animals[i];
            }
            */

            bool bFound = false;

            foreach (var animal in animals)
            {
                var animalName = animal.GetName();
                if (animalName == "pig")
                {
                    bFound = true;
                    break;
                }
            }

            if (bFound)
            {
                Console.WriteLine("pig found");
            }
            else
            {
                Console.WriteLine("pig not found");
            }

            foreach (var animal in animals)
            {
                //var animalNamePub = animal.name;   - private이기떄문에 안됨
                var animalName = animal.GetName();
                if (animalName == "cat")
                {
                    Console.WriteLine("Found cat");
                    Console.WriteLine(">>");
                    animal.MakeSound();
                }
                //animal.MakeSound();
            }

            Animal myCat = null;    // = Animal myCat = animals.Find( ...
            myCat = animals.Find(item => item.GetName().Equals("cat"));
            if (myCat != null)
            {
                Console.WriteLine("Found my cat again");
                Console.WriteLine(">>");
                myCat.MakeSound();
            }

            Animal myPig = animals.Find(item => item.GetName().Equals("pig"));
            if (myPig != null)
            {
                Console.WriteLine("Found pig");
                myPig.MakeSound();
            }
            else
            {
                Console.WriteLine("pig not found");
            }

            Dictionary<enAnimalType, Animal> dicAnimals = new Dictionary<enAnimalType, Animal>();

            dicAnimals.Add(enAnimalType.fox, new Animal("red", "Raww"));
            dicAnimals.Add(enAnimalType.dog, new Animal("blue", "Woof"));
            dicAnimals.Add(enAnimalType.cat, new Animal("pink", "Meww"));

            var someAnimal = dicAnimals[enAnimalType.cat]; // foreach (var animal in animals), Animal my Cat (위의 2개) 2개 하고 동일

            foreach (KeyValuePair<enAnimalType, Animal> item in dicAnimals)
            {
                var key = item.Key;
                var value = item.Value;

                value.MakeSound();
            }

            foreach (var item in dicAnimals.Values)
            {
                item.MakeSound();
            }

            Animal outAnimal;
            if (dicAnimals.TryGetValue(enAnimalType.pig, out outAnimal))
            {
                outAnimal.MakeSound();
            }
            else
            {
                Console.WriteLine("[E] pig not found");
            }

            var pig = dicAnimals[enAnimalType.fox];

            /*  //위랑 같은내용
            var cat = new Animal("고양이", "Mewww");

            cat.MakeSound();


            var dog = new Animal("개", "woof");


            dog.MakeSound();


            var fox = new Animal("여우", "How");       // Animal = Class, fox = instance, new Animal = 생성자, ("여우","How") = 파라미터

            fox.MakeSound();        // function
            */


            Console.WriteLine("numberOfAnimals : {0}", Animal.GetNumOfAnimals());
            Console.WriteLine(String.Empty);
            Console.WriteLine("ShapeMath");
            Console.WriteLine("==========================");

            Console.WriteLine("Area of Rectangle : {0}", ShapeMath.GetArea(enShape.Rectangle, 5, 6));
            Console.WriteLine("Area of Rectangle : {0}", ShapeMath.GetArea(enShape.Triangle, 5, 6));
            Console.WriteLine("Area of Rectangle : {0}", ShapeMath.GetArea(enShape.Circle, 5));

            Console.ReadLine();
        }
    }
}
