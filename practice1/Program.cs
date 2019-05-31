using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice1
{
    class Program
    {
        void practiceRectangle()
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
        }


        static void Main(string[] args)
        {
            Console.WriteLine(String.Empty);
            Console.WriteLine("Animal");
            Console.WriteLine("=======================");

            Animal cow = new Animal("소", "Mewww");

            cow.MakeSound();


            Animal pig = new Animal("돼지", "Quiq");
            

            pig.MakeSound();


            Animal fox = new Animal("여우", "How");       // Animal = Class, fox = instance, new Animal = 생성자, ("여우","How") = 파라미터

            fox.MakeSound();        // function

            Console.WriteLine("numberOfAnimals : {0}", Animal.GetNumOfAnimals());
            Console.WriteLine(String.Empty);
            Console.WriteLine("ShapeMath");
            Console.WriteLine("==========================");
            Console.WriteLine("Area of Rectangle : {0}", ShapeMath.GetArea(enShape.Rectangle, 5, 6));
            Console.WriteLine("Area of Rectangle : {0}", ShapeMath.GetArea(enShape.Triangle, 5, 6));
            Console.WriteLine("Area of Rectangle : {0}", ShapeMath.GetArea(enShape.Circle, 5));

            Console.ReadLine();
        }   
        

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
    }
}
