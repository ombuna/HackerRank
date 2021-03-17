using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class Solver
    {
        bool NextPerm(char[] a)
        {
            int n = a.Length;
            int k;
            for (k = n - 2; k >= 0; k--)
                if (a[k] < a[k + 1])
                    for (int l = n - 1; l >= 0; l--)
                        if (a[k] < a[l])
                        {
                            Swap(ref a[k], ref a[l]);
                            for (int i = k + 1, j = n - 1; i < j; i++, j--)
                                Swap(ref a[i], ref a[j]);
                            return true;
                        }
            return false;
        }

        void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }

        public object Solve()
        {
            for (int tt = ReadInt(); tt > 0; tt--)
            {
                var s = ReadToken().ToCharArray();
                if (!NextPerm(s))
                    writer.WriteLine("no answer");
                else
                    writer.WriteLine(new string(s));
            }
            return null;
        }

        #region Main

        protected static TextReader reader;
        protected static TextWriter writer;

        static void Maint()
        {
#if DEBUG
            reader = new StreamReader("..\\..\\input.txt");
            writer = Console.Out;
            //writer = new StreamWriter("..\\..\\output.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());
#endif
            try
            {
                var ts = DateTime.Now;
                object result = new Solver().Solve();
                if (result != null)
                    writer.WriteLine(result);
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine(ex);
#else
            Console.WriteLine(ex);
            throw;
#endif
            }
            reader.Close();
            writer.Close();
        }

        #endregion

        #region Read/Write

        private static Queue<string> currentLineTokens = new Queue<string>();

        private static string[] ReadAndSplitLine()
        {
            return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string ReadToken()
        {
            while (currentLineTokens.Count == 0)
                currentLineTokens = new Queue<string>(ReadAndSplitLine());
            return currentLineTokens.Dequeue();
        }

        public static int ReadInt()
        {
            return int.Parse(ReadToken());
        }

        public static long ReadLong()
        {
            return long.Parse(ReadToken());
        }

        public static double ReadDouble()
        {
            return double.Parse(ReadToken(), CultureInfo.InvariantCulture);
        }

        public static int[] ReadIntArray()
        {
            return ReadAndSplitLine().Select(int.Parse).ToArray();
        }

        public static long[] ReadLongArray()
        {
            return ReadAndSplitLine().Select(long.Parse).ToArray();
        }

        public static double[] ReadDoubleArray()
        {
            return ReadAndSplitLine().Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray();
        }

        public static int[][] ReadIntMatrix(int numberOfRows)
        {
            int[][] matrix = new int[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
                matrix[i] = ReadIntArray();
            return matrix;
        }

        public static int[][] ReadAndTransposeIntMatrix(int numberOfRows)
        {
            int[][] matrix = ReadIntMatrix(numberOfRows);
            int[][] ret = new int[matrix[0].Length][];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = new int[numberOfRows];
                for (int j = 0; j < numberOfRows; j++)
                    ret[i][j] = matrix[j][i];
            }
            return ret;
        }

        public static string[] ReadLines(int quantity)
        {
            string[] lines = new string[quantity];
            for (int i = 0; i < quantity; i++)
                lines[i] = reader.ReadLine().Trim();
            return lines;
        }

        public static void WriteArray<T>(IEnumerable<T> array)
        {
            writer.WriteLine(string.Join(" ", array));
        }

        #endregion
    }
}
