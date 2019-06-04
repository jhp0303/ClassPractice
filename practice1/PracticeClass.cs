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

        public static void practice2()
        {
            //string str = "Kunsan University";
            //Console.WriteLine(str.Substring(str.IndexOf("University"))); // \n에 n은 newline의 약자

            //example 1
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sb.Append(i).Append(" ");
            }

            Console.WriteLine(sb.ToString());

            //example 2
            StringBuilder sb2 = new StringBuilder();
            sb2.Append("The list starts here:");
            sb2.AppendLine();
            sb2.Append("1 cat").AppendLine();

            string str2 = sb2.ToString();
            Console.WriteLine(str2);

            //example 3
            StringBuilder sb3 = new StringBuilder("Korea University");
            sb3.Replace("Korea", "Kunsan");
            Console.WriteLine(sb3.ToString());

            //example 4
            string[] items = { "Cat", "Dog", "Fox", "Pig" };

            StringBuilder sb4 = new StringBuilder("These animals are required:").AppendLine();

            foreach(string item in items)
            {
                sb4.Append(item).AppendLine();
            }

            Console.WriteLine(sb4.ToString());

            //example 5
            StringBuilder sb5 = new StringBuilder("Kunsan is University");
            sb5.Remove(7,3);
            Console.WriteLine(sb5.ToString());

            //example 6
            StringBuilder sb6 = new StringBuilder();
            sb6.Append("Kunsan University.");

            TrimEnd(sb6, '.');
            Console.WriteLine(sb6.ToString());
        }
        
        private static void TrimEnd(StringBuilder sb, char letter)
        {
            if (sb.Length == 0) return;

            if (sb[sb.Length -1] == letter)
            {
                sb.Length -= 1;
            }
        }

        public static void practice3()
        {
            Tuple<string, double>[] areas =
                     { Tuple.Create("Sitka, Alaska", 2870.3),
                       Tuple.Create("New York City", 302.6),
                       Tuple.Create("Los Angeles", 468.7),
                       Tuple.Create("Detroit", 138.8),
                       Tuple.Create("Chicago", 227.1),
                       Tuple.Create("San Diego", 325.2) };

            Console.WriteLine("{0,-18} {1,14:N1} {2,30}\n", "City", "Area (mi.)",
                              "Equivalent to a square with:");

            foreach (var area in areas)
                Console.WriteLine("{0,-18} {1,14:N1} {2,14:N2} miles per side",
                                  area.Item1, area.Item2, Math.Round(Math.Sqrt(area.Item2), 2));
        }

        public static void practice4()
        {
            
            Console.Write("newID : ");
            string newID = Console.ReadLine();
            Console.Write("newPW : ");
            string newPW = Console.ReadLine();

            Console.WriteLine("ID : {0}, Password : {1}", newID, newPW);

            Console.Write("ID : ");
            string ID = Console.ReadLine();
            Console.Write("PW : ");
            string PW = Console.ReadLine();

            if (ID == newID.ToLower())
            {
                if (PW == newPW)
                {
                    Console.WriteLine("ID / PW is Correct");
                }
                else
                {
                    Console.WriteLine("Wrong PW");
                }
            }

            else
            {
                Console.WriteLine("Wrong ID");
            }

        }
    }
}
