using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

            foreach (string item in items)
            {
                sb4.Append(item).AppendLine();
            }

            Console.WriteLine(sb4.ToString());

            //example 5
            StringBuilder sb5 = new StringBuilder("Kunsan is University");
            sb5.Remove(7, 3);
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

            if (sb[sb.Length - 1] == letter)
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

        public static void practice5()  //2019-06-05
        {

            //아래와 같음
            int[] score = new int[] { 90, 75, 85, 95, 70, 75, 85, 85, 95, 72 };
            double result = 0;
            for (int i = 0; i < score.Length; i++)
            {
                result += score[i];
            }

            double ave = result / score.Length;

            Console.WriteLine("점수 : {0}", string.Join<int>(",", score));
            Console.WriteLine("합계 : {0}", result);
            Console.WriteLine("평균 : {0}", ave);


            /*  //배열을 이용해서 10명의 학생의 점수의 합계와 평균을 구하기
            int[] score = new int[] { 90, 75, 85, 95, 70, 75, 85, 85, 95, 72 };
            double result = 0;
            double ave = 0;
            for (int i = 0; i < score.Length; i++)
            {
                result += score[i];
                
                if (i >=1)
                {
                    ave = result / (i+1);
                }
            }
            Console.WriteLine("합계 : {0}", result);
            Console.WriteLine("평균 : {0}", ave);



            /*  //점수를 입력받아 학점 구분하기
            Console.Write("점수 입력 : ");
            string scores = Console.ReadLine();
            int score = Convert.ToInt32(scores);

            if (score >= 90)
            {
                Console.WriteLine("학점 : A");
            }

            else if (score >= 80)
            {
                Console.WriteLine("학점 : B");
            }

            else if (score >= 70)
            {
                Console.WriteLine("학점 : C");
            }

            else if (score >= 80)
            {
                Console.WriteLine("학점 : D");
            }

            else
            {
                Console.WriteLine("학점 : F");
            }


            /*  //원하는 줄 수 많큼 별찍기
            Console.Write("Enter line number : ");
            string a = Console.ReadLine();
            int b = Convert.ToInt32(a);

            for (int i = 1; i <= b; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }


            


            /*  //구구단
            for (int i = 2; i < 10; i++)
            {
                Console.WriteLine("\n");
                for (int a = 1; a < 10; a++)
                {
                    if (a == 1)
                    {
                        Console.WriteLine("** {0}단 **", i);
                        Console.WriteLine("{0} x {1} = {2}", i, a, a*i);
                    }
                    else
                    {
                        Console.WriteLine("{0} x {1} = {2}", i, a, a*i);
                    }
                    
                }
            }

            /*  //1~100까지 합계 구하기
            int a = 0;
            for (int i = 0; i <= 100; i++)
            {
                a += i;
            }
            Console.WriteLine("1 + 2 + 3 + 4 + ... + 99 + 100 = {0}", a);


            /*  //섭씨 온도를 화씨 온도로 변화하기
            double C, F = 0;

            C = 31.50;

            F = (C * 9/5) + 32;

            Console.WriteLine("섭씨 31.50도는 화씨{0}도 입니다.", F);
            Console.WriteLine();
            */
        }

        public static void practice6()  //2019-06-07
        {


            /*
            string plainText = "Hello World";

            StringBuilder sb = new StringBuilder();

            foreach (char ch in plainText)
            {
                char newchar = ch;

                if((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z'))
                {
                    //key + 3 만큼 이동
                    newchar = (char)(ch + 3);

                    //대문자 끝 3글자가 왔을 시 대문자를 소문자로 넘겨주는 코드
                    if((Char.IsUpper(ch) && newchar > 'Z') || (Char.IsLower(ch) && newchar > 'z'))
                    {
                        newchar = (char)(newchar + 26);
                    }
                }
                sb.Append(newchar);
            }
            Console.WriteLine(sb.ToString());

            /*    // 내가 한거 위에가 정답 : 주어진 스트링을 시저의 암호화 기법으로 변환하기

            string str = "Hello World";

            for (int i = 0; i < str.Length; i++)
            {
                char t = str[i];
                int ascii = Convert.ToInt32(t);
                if (ascii == 32)
                {
                    t = (char)(str[i] - 32);
                    Console.Write(t);
                }
                else if (ascii != 32)
                {
                    t = (char)(str[i] + 3);
                    Console.Write(t);
                }
            }


            /*  주어진 문자열의 대소문자를 비교해서 대문자면 소문자로, 소문자로 대문자로 바꾸기
            string str = "Hello, World";

            for (int i = 0; i < str.Length; i++)
            {
                char t = str[i];
                if (char.IsUpper(t))
                {
                    Console.Write("{0}", char.ToLower(t));
                }

                else
                {
                    Console.Write("{0}", char.ToUpper(t));
                }
            }



            /*  
            int[,] score = new int[5, 3]
            {
                { 90, 80, 90 },
                { 85, 85, 85 },
                { 95, 70, 75 },
                { 80, 80, 90 },
                {90, 75, 80 }
            };

            for (int i = 0; i < score.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < score.GetLength(1); j++)
                {
                    sum += score[i, j];
                }

                double avg = sum / 3;
                Console.WriteLine("ID={0} : 합계={1}, 평균={2:N2}", i, sum, avg);
            }

            /*  위가 정답, 아래가 내가 한거 : 제시된 점수의 각각의 합과 평균을 구하기
            int[,] score1 = new int[,]
            { { 90, 80, 90 },
              { 85, 85, 85 },
              { 95, 70, 75 },
              { 80, 80, 90 },
              { 90, 75, 80 }
            }; //배열이 정해져있는게 아니라면 new int [5,3] 과 같이 써줘야함

            int sum = 0;
            double avg = 0.0;
            
            for (int i = 0; i < score1.GetLength(0); i++)                //Console.WriteLine(score1.Length);   GetLength를 이용해서 각 배열의 숫자만큼만..
            {
                for (int j = 0; j < score1.GetLength(1); j++)
                {
                    sum += score1[i,j];
                    avg = sum / 3;
                    Console.WriteLine("ID={0} : 합계={1}, 평균={2}", i, sum, avg);
                }

            }*/
        }


        public static int Sum(int[] data)   //강사님이 한거 2019-06-07
        {   // 메인함수에서 인자를 받아 메서드를 호출해 출력하기
            int s = 0;
            for (int i = 0; i < data.Length; i++)
            {
                s += data[i];
            }
            return s;

            /*  //아래가 내가한거 위에가 강사님이한거
            int result = 0;
            for (int i = 0; i < data.Length; i++)
            {
                result += data[i];
            }
            return result;
            */
        }


        public static int Add(int a, int b)
        {  // 사칙연산 메서드를 호출해서 메인함수에서 계산하기 2019-06-07
            int result = 0;

            result = a + b;

            return result;
        }
        public static int Del(int a, int b)
        {
            int result = 0;

            result = a - b;

            return result;
        }
        public static int Mul(int a, int b)
        {
            int result = 0;

            result = a * b;

            return result;
        }
        public static int Div(int a, int b)
        {
            int result = 0;

            result = a / b;

            return result;

        }

        public static void practice12()
        {
            // A : 3, 4, 5
            // B : 3, 3, 3

            //Triangle.triA = new Triangle(3,4,5);

            List<Triangle> triangles = new List<Triangle>();
            triangles.Add(new Triangle(3, 4, 5));
            triangles.Add(new Triangle(3, 3, 3));


            int index = 1;      //몇번째 삼각형인지 알기위해 index변수를 넣음
            foreach (Triangle shape in triangles)
            {
                shape.Draw(index);
                index++;
            }

            /*  //위의 foreach문과 동일함
            index = 1;
            for (int i = 0; i < triangles.Count; i++)
            {
                Triangle.shape = triangles[i];
                Shape.Draw(index);
                index++;
            }
            */


            // Output
            // 삼각형1: A=3, B=4, C=5
            // 둘레길이: 12
            // 삼각형2: A=3, B=3, C=3
            // 둘레길이: 9
        }

        class Triangle
        {
            private int A, B, C;
            public Triangle(int a, int b, int c)
            {
                A = a;
                B = b;
                C = c;
            }

            public void Draw(int index)
            {
                int sum = A + B + C;
                Console.WriteLine("삼각형{0} : A = {1}, B = {2}, C = {3}", index, A, B, C);
                Console.WriteLine("둘레길이 : {0}", sum);
            }
        }

        public static void practice13_1()
        {
            Calculater calA = new Calculater();
            Calculater calB = new Calculater();

            int a = 20;
            int b = 10;

            double x = 20.5;
            double y = 10.5;

            Console.WriteLine("a={0}, b={1}", a, b);
            Console.WriteLine("사칙연산 결과: {0},{1},{2},{3}", calA.Add(a, b), calA.Substract(a, b), calA.Multiply(a, b), calA.Divide(a, b));
            Console.WriteLine();
            Console.WriteLine("x={0}, y={1}", x, y);
            Console.WriteLine("사칙연산 결과: {0},{1},{2},{3:N6}", calB.Add(x, y), calB.Substract(x, y), calB.Multiply(x, y), calB.Divide(x, y));

        }

        class Calculater        //practice13_1 에 쓰이는 사칙연산 클래스
        {
            public int Add(int a, int b)
            {
                return a + b;
            }
            public double Add(double x, double y)
            {
                return x + y;
            }

            public int Substract(int a, int b)
            {
                return a - b;
            }

            public double Substract(double x, double y)
            {
                return x - y;
            }

            public int Multiply(int a, int b)
            {
                return a * b;
            }

            public double Multiply(double x, double y)
            {
                return x * y;
            }

            public int Divide(int a, int b)
            {
                if (b == 0)
                {
                    Console.WriteLine("0으로는 나눌수가 없습니다.");
                    return 0;
                }
                return a / b;
            }
            public double Divide(double x, double y)
            {
                if (y == 0)
                {
                    Console.WriteLine("0으로는 나눌수가 없습니다.");
                    return 0;
                }
                return x * 1.0 / y;
            }
        }

        public static void practice13_2()
        {
            int a = 20, b = 10;
            double x = 20.5, y = 10.5;
            Calculater2<int> calA = new Calculater2<int>();
            Calculater2<double> calB = new Calculater2<double>();

            Console.WriteLine("a={0}, b={1}", a, b);
            Console.WriteLine("사칙연산 결과: {0},{1},{2},{3}", calA.Add(a, b), calA.Substract(a, b), calA.Multiply(a, b), calA.Divine(a, b));
            Console.WriteLine();
            Console.WriteLine("a={0}, b={1}", x, y);
            Console.WriteLine("사칙연산 결과: {0},{1},{2},{3:N6}", calB.Add(x, y), calB.Substract(x, y), calB.Multiply(x, y), calB.Divine(x, y));
        }

        class Calculater2<T>    //practice13_2 에 쓰이는 제네릭 클래스
        {
            public T Add(T a, T b)
            {
                dynamic da = a;
                dynamic db = b;

                dynamic sum = da + db;
                return sum;
            }
            public T Substract(T a, T b)
            {
                dynamic da = a;
                dynamic db = b;

                dynamic substract = da - db;
                return substract;
            }
            public T Multiply(T a, T b)
            {
                dynamic da = a;
                dynamic db = b;

                dynamic multiply = da * db;
                return multiply;
            }
            public T Divine(T a, T b)
            {
                dynamic da = a;
                dynamic db = b;

                if (db == 0)
                {
                    Console.WriteLine("0으로 나눌 수 없습니다");
                }
                if (db > da)
                {
                    dynamic divine1 = da % db;
                    return divine1;
                }
                dynamic divine = da / db;
                return divine;
            }

        }

        public static void practice14()
        {
            Car car = new Car("자동차 이름");
            car.Start();
            Console.WriteLine("시작시 속도:{0}", car.Speed);
            car.Accelerate();
            Console.WriteLine("엑셀 1단계 속도:{0}", car.Speed);
            car.Accelerate();
            Console.WriteLine("엑셀 2단계 속도:{0}", car.Speed + 10);
            car.Stop();
            Console.WriteLine("정지후 속도:{0}", car.Speed);
        }

        class Car   //practice14에 쓰이는 Car 클래스
        {
            private int speed;

            public string Name { get; set; }
            public string Maker { get; set; }
            public string Model { get; set; }

            public int Speed { get { return this.speed; } } //내부 speed를 외부로 가져가기위한 변수

            public Car(string param_name)
            {
                Name = param_name;
            }

            public void Start()
            {
                speed = 1;

            }

            public void Stop()
            {
                speed = 0;
            }

            public void Accelerate(int value = 10)
            {
                speed += value;

            }

            public void Break()
            {
                /*
                if (speed < 10)
                {
                    Console.WriteLine("자동차의 속도가 0인데 브레이크를 밟아?");
                }
                */

                speed -= 10;
                speed = (speed > 0) ? speed : 0;        //뺀값이 0보다 크면 speed 0보다 작으면 0으로
            }
        }

        public static void practice15()
        {
            MyPaint paint = new MyPaint();

            TriangleDraw t = new TriangleDraw(3, 4, 5);
            paint.DrawShape(t);
            Console.WriteLine();

            //Output
            //
            //Draw Triangle(3,4,5)
            RectangleDraw r = new RectangleDraw(5, 10);
            paint.DrawShape(r);
            Console.WriteLine();
            //
            //Draw Triangle(3,4,5)
            //Draw Rectangle(5,10)
            CustomShapeDraw c = new CustomShapeDraw(5, 10, 2, 2);
            paint.DrawShape(c);
            Console.WriteLine();
            //Draw Triangle(3,4,5)
            //Draw Rectangle(5,10)
            //Draw CustomShape(5,10,2,2)
        }

        public interface IDrawable  //인터페이스를 이용
        {
            void Draw();
        }

        public class MyPaint    //MyPain클래스생성
        {
            List<IDrawable> drawables = new List<IDrawable>();  //IDrawable 리스트를 생성


            public void DrawShape(IDrawable shape)  //생성했던 도형클래스들을 저장하는 메서드
            {
                drawables.Add(shape);   //저장

                foreach (IDrawable drawable in drawables)    //출력
                {
                    drawable.Draw();
                }
            }
        }

        class TriangleDraw : IDrawable  //practice15에서 사용한 삼각형
        {
            private int A, B, C;
            public TriangleDraw(int a, int b, int c)
            {
                A = a;
                B = b;
                C = c;
            }
            public void Draw()
            {
                Console.WriteLine("Draw triangle({0},{1},{2})", A, B, C);   // == Console.WriteLine($"Draw Triangle({A},{B},{C})");
            }
        }
        class RectangleDraw : IDrawable  //practice15에서 사용한 직사각형
        {
            private int w, h;
            public RectangleDraw(int Width, int Height)
            {
                w = Width;
                h = Height;
            }
            public void Draw()
            {
                Console.WriteLine("Draw Rectangle({0},{1})", w, h);
            }
        }
        class CustomShapeDraw : IDrawable  //practice15에서 사용한 커스텀도형
        {
            private int w, h, x, y;
            public CustomShapeDraw(int Width, int Height, int X, int Y)
            {
                w = Width;
                h = Height;
                x = X;
                y = Y;
            }

            public void Draw()
            {
                Console.WriteLine("Draw CustomShape({0}, {1}, {2}, {3})", w, h, x, y);
            }
        }

        public static void practice16()
        {
            FullTimeEmployee fe = new FullTimeEmployee("Tom", 190021);
            fe.AnnualSalary = 10000;
            fe.AdjustSalary(-100);
            Console.WriteLine("{0}'s annual salary is {1}", fe.Name, fe.AnnualSalary);
            fe.SayName();

            PartTimeEmployee pe = new PartTimeEmployee("Jane");
            pe.hourlyRate = 100;
            int workHour = 8;
            int totalPayment = pe.CalculatePay(workHour);
            Console.WriteLine("{0}'s work hour is {1}, total payment is {2}", pe.Name, workHour, totalPayment);
            pe.SayName();



        }

        public class Employee
        {

            public string Name { get; set; }
            public string Email { get; set; }

            /*  1번
            public Employee() { }
            */

            public Employee(string name)
            {
                this.Name = name;

            }

            public virtual void SayName()
            {
                Console.WriteLine($"My name is {Name}");
            }
        }
        public class FullTimeEmployee : Employee
        {
            /*  1번 위의 1번과같은 형태가 나올때는 이런 형태
            public FullTimeEmployee() : base()
            {

            }
            */
            private int EmployeeNumber { get; set; }

            public FullTimeEmployee(string name, int number) : base(name)   //풀타임임플로이도 임플로이를 상속 받는거고 name을 반드시 필요로하는거기때문에 베이스클래스도 네임을 받음
            {
                EmployeeNumber = number;
            }


            public int AnnualSalary { get; set; }

            public void AdjustSalary(int amount)
            {
                this.AnnualSalary += amount;
            }

            public override void SayName()
            {
                //base.SayName();
                Console.WriteLine($"My number is {EmployeeNumber}, name is {Name}"); ;
            }
        }
        public class PartTimeEmployee : Employee
        {
            public PartTimeEmployee(string name) : base(name)
            {

            }


            public int hourlyRate { get; set; }

            public int CalculatePay(int time)
            {
                return hourlyRate * time;
            }

            public override void SayName()
            {
                Console.WriteLine($"I'm part-time employee. My name is {Name}");
            }
        }

        public static void practice17() //원하는 txt파일을 불러와서 합산과 평균을 구하기
        { 
            if (File.Exists(@"C:\score.txt"))
            {
                 Console.WriteLine("[L] File exists");
            }

            else
            {
                Console.WriteLine("[L] File does not exists");
            }
            char[] charSeprators = new char[] { ',' };
            string path = @"D:\score.txt";


            string[] lines = File.ReadAllLines(@"C:\score.txt");
            {
                foreach (string line in lines)
                {
                    string[] result;
                    int sum = 0;
                    int div;
                    result = line.Split(charSeprators, StringSplitOptions.None);
                    for (int i = 1; i < result.Length; i++)
                    {
                        sum += int.Parse(result[i]);
                    }
                    div = sum / (result.Length - 1);

                    using (StreamWriter outputFile = new StreamWriter(path, true))
                    {
                        outputFile.Write(line);
                        outputFile.Write($",{ sum}");
                        outputFile.WriteLine($",{div}");
                    }
                }

            }
        }

        
    }
    public class Triangle   // practice12를 이해하기위함.
    {
        //필드    일반적인 변수들 가지고있음
        private double a;
        private double b;
        private double c;

        //생성자   
        public Triangle (double _a, double _b, double _c)
        {
            a = _a;
            b = _b;
            c = _c;
        }

        //속성
        public double A
        {
            get { return a; }
        }
        public double B
        {
            get { return b; }
        }
        public double C
        {
            get { return c; }
        }

        //메서드   함수같은거
        public double Perimeter
        {
            get { return a + b + c; }
        }
        public void Draw()
        {
            Console.WriteLine("Draw({0}, {1}, {2}", A, B, C);
        }
    }
}
