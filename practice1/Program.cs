using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice1
{
    class Program
    {
        static void Main(string[] args)
        {
            PracticeClass.practice13_1();

            /*  // 사칙연산 메서드를 호출해서 메인함수에서 계산하기 2019-06-07
            int sum = PracticeClass.Add(3, 5);
            int del = sum - PracticeClass.Del(sum, 2);
            int mul = del * PracticeClass.Mul(del, 2);
            int div = mul / PracticeClass.Div(mul, 3);

            Console.WriteLine(div);
            

            /*  // 메인함수에서 인자를 받아 메서드를 호출해 출력하기 2019-06-07
            int[] a = { 80, 90, 95, 75, 70 };
            int[] b = { 90, 85, 85, 85, 80 };

            int sumA = PracticeClass.Sum(a);
            Console.WriteLine("A : {0}", string.Join<int>(",",a));
            Console.WriteLine("Sum(A) = {0}", sumA);

            int sumB = PracticeClass.Sum(b);
            Console.WriteLine("A : {0}", string.Join<int>(",", b));
            Console.WriteLine("Sum(B) : {0}", sumB);
            */



            //PracticeClass.practice6();  //practice1,2를 하냐에따라 PracticeClass의 어떤 펑션을 실행할지 결정함.
            Console.ReadLine();
            
        }
    }
}
