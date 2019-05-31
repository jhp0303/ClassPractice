using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice1
{
    class Animal
    {
        static int numOfAnimals = 0;

        private string mName;
        private string mSound;
        private int mLegCount;

        //첫번째 생성자
        public Animal()
        {
            mName = "No name";
            mSound = "No sound";
            numOfAnimals++;

        }

        //두번째 생성자
        public Animal(string name, string sound)
        {
            mName = name;
            mSound = sound;
            //numOfAnimals = numOfAnimals + 1;
            numOfAnimals++;
        }

        //세번째 생성자
        public Animal(string name, string sound, int legCount)
        {
            mName = name;
            mSound = sound;
            mLegCount = legCount;
            numOfAnimals++;

        }


        //출력 함수
        public void MakeSound()
        {
            Console.WriteLine("[A] name : {0}, sound : {1}, number : {2}", mName, mSound, numOfAnimals);
        }

        public static int GetNumOfAnimals()
        {
            return numOfAnimals;
        }
    }
}
