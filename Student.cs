using System;
using System.Linq;

namespace HackerRank
{
    internal class Student : Person
    {
        private int[] scores;

        public Student(string firstName, string lastName, int id, int[] scores)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.scores = scores;
        }

        internal void printPerson()
        {
            Console.WriteLine(string.Format("Name: {0},{1}",this.firstName,this.lastName));
            Console.WriteLine(string.Format("ID: {0}", this.id));
        }

        internal string Calculate()
        {
            var av = scores.Average();
            if (av >= 90) return "O";
            else if (av >= 80) return "E";
            else if (av >= 70) return "A";
            else if (av >= 55) return "P";
            else if (av >= 40) return "D";
            else return "T";
        }
    }

    internal class Person
    {
        public string firstName;
        public string lastName;
        public int id;
    }
}