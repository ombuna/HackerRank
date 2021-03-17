using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    abstract class Book
    {

        protected String title;
        protected String author;

        public Book(String t, String a)
        {
            title = t;
            author = a;
        }
        public abstract void display();


    }

    //Write MyBook class
    class MyBook : Book
    {
        int price;

        public MyBook(string title, string auther, int price) : base(title, auther)
        {
            this.price = price;
        }
        public override void display()
        {
            Console.WriteLine("Title: {0}", title);
            Console.WriteLine("Author: {0}", author);
            Console.WriteLine("Price: {0}", price);
        }
    }

    class Solution
    {
        static void Main2(String[] args)
        {
            String title = Console.ReadLine();
            String author = Console.ReadLine();
            int price = Int32.Parse(Console.ReadLine());
            Book new_novel = new MyBook(title, author, price);
            new_novel.display();
        }
        Stack<char> st = new Stack<char>();
        Queue<char> vs = new Queue<char>();

        internal void pushCharacter(char c)
        {
            st.Push(c);
        }

        internal void enqueueCharacter(char c)
        {
            vs.Enqueue(c);
        }

        internal Char popCharacter()
        {
            return st.Pop();
        }

        internal char dequeueCharacter()
        {
            return vs.Dequeue();
        }
    }
}
