using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class CircularQueue
    {
        private int[] element;
        private int front;
        private int rear;
        private int max;
        private int count;

        public CircularQueue(int size)
        {
            element = new int[size];
            front = 0;
            rear = -1;
            max = size;
            count = 0;
        }

        public void insert(int item)
        {
            if (count == max)
            {
                Console.WriteLine("Queue overflow");
                return;
            }
            else
            {
                rear = rear++ % max;
                element[rear] = item;

                count++;
            }
        }

        public void delete(int item)
        {
            if (count == 0)
            {
                Console.WriteLine("Queue is empty");
                return;
            }
            else {
                front = front++ % max;

                count--;
            }
        }
    }
}
