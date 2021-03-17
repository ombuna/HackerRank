using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class phoneBooks : IEnumerable
    {
        private string name = "a";
        private string number = "b";
        public phoneBooks() { }

        public phoneBooks(string number, string name)
        {
            this.Number = number;
            this.Name = name;
        }
        public String Name
        {
            get;
            set;
        }

        public String Number
        {
            get;
            set;
        }
        public IEnumerator<string> GetEnumerator()
        {
            yield return number;
            yield return name;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class LimitsComparer : IComparer<phoneBooks>
    {
        public int Compare(phoneBooks x, phoneBooks y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
    public class pupils : IEnumerable
    {
        string[] pupil = { "ken", "ben", "kevin" };
        public IEnumerator GetEnumerator()
        {
            return new PupilEnumerator(pupil);
        }
    }
    class numbers : IEnumerable<int>
    {
        int[] nums = null;

        public numbers(int[] numbs)
        {
            nums = numbs;
        }
        public IEnumerator<int> GetEnumerator()
        {
            return MyEnumerator(nums);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return nums.GetEnumerator();
        }

        private IEnumerator<int> MyEnumerator(int[] nums)
        {
            int[] num = nums;
            int i = 0;
            while (true)
            {
                if (i == num.Length)
                    yield break;
                yield return num[i++];
            }
        }
    }


    class words : IEnumerable
    {
        string[] word = null;
        public words(string[] wordz)
        {
            word = wordz;
        }
        public IEnumerator GetEnumerator()
        {
            return MyItrator(word);
        }
        public IEnumerator MyItrator(string[] wordz)
        {
            string[] arr = wordz;
            int i = 0;
            while (true)
            {
                if (i == wordz.Length)
                    yield break;
                yield return arr[i++];
            }
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] nums = { 1, 5, 4, 10, 3, 6, 9, 2,7 };
            Console.WriteLine(string.Join(" ",mergeSortNew(nums)));

            Console.ReadLine();
        }

        private static int[] mergeSortNew(int[] arr)
        {
            if (arr.Length <= 1) return arr;
            int mid = arr.Length / 2;
            int[] left = arr[0..mid]; //new int[mid];
            int[] right = arr[mid..^0]; //new int[arr.Length % 2 == 0 ? mid : mid + 1];
            int[] results = new int[arr.Length];

            //for (int i = 0; i < mid; i++)
            //{
            //    left[i] = arr[i];
            //}
            //int x = 0;
            //for (int i = mid; i < arr.Length; i++)
            //{
            //    right[x] = arr[i];
            //    x++;
            //}
            left = mergeSortNew(left);
            right = mergeSortNew(right);
            results = merge(left, right);
            return results;
        }

        public static int MaxProfitWithKTransactions(int[] prices, int k)
        {
            // Write your code here.
            /*
            get min, check for max, always remove the min
            */
            int min = 0;
            int sP = 0;
            int psP = int.MaxValue;
            int profit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (sP == 0 || sP > prices[i])
                    sP = prices[i];
                else if (i == prices.Length - 1 || prices[i] > prices[i + 1])
                {
                    //update min,max,k,profit
                    var p = prices[i] - sP;
                    var pp = prices[i] - psP;
                    if (pp > p)
                    {
                        p = Math.Max(p, pp);
                        psP = sP;
                        profit -= min;
                        k++;
                    }
                    if (min == 0 && k > 0)
                    {
                        min = p;
                        profit += p;
                        k--;
                        psP = sP;
                    }
                    else
                    {
                        if (k > 0)
                        {
                            min = Math.Min(p, min);
                            profit += p;
                            k--;
                        }
                        else
                        {
                            if (p > min)
                            {
                                profit += (p - min);
                                min = p;
                            }
                        }
                    }
                    sP = 0;
                }
            }
            return profit;
        }
        public static bool IsNumber(string s)
        {
            if (Double.TryParse(s, out double t)) return true;
            else return false;
        }
        public static void NextPermutation(int[] nums)
        {
            if (nums.Length <= 1) return;
            for (int i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i] > nums[i - 1])
                {
                    var t = i;
                    for (int j = i; j < nums.Length; j++)
                    {
                        if (nums[j] > nums[i - 1] && nums[j] < nums[t])
                            t = j;
                    }
                    Swap(ref nums[i - 1], ref nums[t]);
                    if (i < nums.Length - 1)
                    {
                        while (true)
                        {
                            bool sorted = true;
                            for (int j = i; j < nums.Length; j++)
                            {
                                if (nums[j] > nums[j + 1])
                                {
                                    Swap(ref nums[j], ref nums[j + 1]);
                                    sorted = false;
                                }
                            }
                            if (sorted) break;
                        }
                    }
                    return;
                }
            }
            Array.Sort(nums);
        }

        public static int SearchInsert(int[] nums, int target)
        {
            int l = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 && target < nums[i]) return 0;
                else if (nums[i] == target) return i;
                else if (i == l - 1) return l;
                else if (i < l)
                    if (nums[i] < target)
                        if (target < nums[i + 1]) return i + 1;
            }
            return 0;
        }

        public static int Divide(int dividend, int divisor)
        {
            if (dividend == 0) return 0;
            if (dividend == divisor) return 1;
            long res = 0;
            bool isNegative = ((dividend > 0 && divisor > 0) || (dividend < 0 && divisor < 0)) ? false : true;
            long a = dividend, b = divisor;
            a = a < 0 ? 0 - a : a;
            b = b < 0 ? 0 - b : b;

            while (a >= b)
            {
                res++;
                a -= b;
            }
            return isNegative ? unchecked((int)(0 - res)) : (int)Math.Min(int.MaxValue, res);
        }

        public static ListNode reverseKGroupC(ListNode head, int k)
        {
            var dummy = new ListNode(0, head);
            var groupPrev = dummy;
            //always introduce a dummy

            while (true)
            {
                var kth = GetKth(groupPrev, k);// this is the kth 
                if (kth is null)
                    break;
                var groupNext = kth.next; //maintain the link 

                // reverse group
                var prev = kth.next;  //maintain next twice
                var curr = groupPrev.next; //curr node
                while (curr != groupNext)
                {
                    var temp = curr.next; //tamp next i.e 2
                    curr.next = prev; //set next to 4 so as not to cut the link  
                    prev = curr; //prev to curr for the next node
                    curr = temp; //return curr to temp for next line of code i.e 2
                }
                var tmp = groupPrev.next;
                groupPrev.next = kth;
                groupPrev = tmp;
            }
            return dummy.next;
        }
        static ListNode GetKth(ListNode curr, int k)
        {
            while (curr != null && k > 0)
            {
                curr = curr.next;
                k -= 1;
            }
            return curr;
        }
        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            if (k == 1) return head;

            bool headset = false;

            var curr = head; //123
            var next = head.next; //234
            var cont = next.next; //345
            curr.next = null; //1
            var prev = cont;
            int t = 1;

            while (cont != null)
            {
                if (t < k)
                {
                    t++;
                    next.next = curr; //21
                    curr = next; //21
                    next = cont; //345 
                    prev = cont;
                    cont = next != null ? next.next : null; //45
                }
                else
                {
                    t = 0;
                    if (!headset) head = curr;
                    curr.next = prev;
                    curr = curr.next;
                    next = curr.next;
                    cont = next.next;
                }
            }

            //ListNode next = null;
            //var batch = GetBatch(head, next, k);
            //head = ReverseList(batch).next = next;
            //ReverseKGroup(head, null, 0, k);
            return curr;
        }

        private static ListNode GetBatch(ListNode head, ListNode next, int k)
        {
            ListNode t = head;
            var h = t;
            int i = 0;
            while (i < k)
            {
                i++;
                if (i == k)
                {
                    next = h.next;
                    h.next = null;
                }
                else
                    h = h.next;
            }
            return t;
        }

        //reverse list
        static ListNode ReverseList(ListNode head)
        {
            var temp = head.next; //2
            var curr = head; //1
            var next = temp.next; //345
            curr.next = null;
            while (temp != null)
            {
                temp.next = curr; //21
                curr = temp; //21
                temp = next; //345 
                next = temp != null ? temp.next : null; //45
            }
            return curr;
        }

        public static void ReverseKGroup(ListNode head, ListNode prev, int position, int interval)
        {
            if (head is null)
                return;

            if (position < interval)
            {
                ReverseKGroup(head.next, head, position + 1, interval);
                prev.next = head;
            }
            else ReverseKGroup(head.next, head, 0, interval);
        }

        public static ListNode SwapPairs(ListNode head)
        {
            if (head is null || head.next is null) return head;
            var curr = head;
            var swap = head.next;
            ListNode prev = null;
            head = swap;
            while (swap != null)
            {
                if (prev != null)
                {
                    prev.next = swap;
                }
                var temp = swap.next;
                swap.next = curr;
                swap.next.next = temp;
                prev = swap.next;
                curr = prev.next;
                swap = curr != null ? curr.next : null;
            }
            return head;
        }

        public static IList<string> GenerateParenthesis(int n)
        {
            IList<string> list = new List<string>();
            if (n == 1) list.Add("()");
            else
            {
                int open = n;
                while (true)
                {
                    int i = 1;
                    while (i < open)
                    {
                        Console.Write("(");
                    }
                    i = 0;
                    while (i < open)
                    {
                        Console.Write(")");
                    }
                }
            }
            return list;
        }

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 is null) return l2;
            if (l2 is null) return l1;

            ListNode l3;

            if (l1.val < l2.val)
            {
                l3 = l1;
                l3.next = MergeTwoLists(l1.next, l2);
            }
            else
            {
                l3 = l2;
                l3.next = MergeTwoLists(l1, l2.next);
            }

            return l3;
        }

        public static bool IsValidP(string s)
        {
            int l = s.Length;
            if (l == 0) return true;
            if (l % 2 == 1) return false;
            Dictionary<char, char> chars = new Dictionary<char, char>();
            chars.Add('(', ')');
            chars.Add('{', '}');
            chars.Add('[', ']');
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < l; i++)
            {
                if (chars.ContainsKey(s[i]))
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (!chars[stack.Pop()].Equals(s[i])) return false;
                }
            }
            return true;
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head.next == null)
                return null;
            int length = 0;
            var temp = head;
            while (temp != null)
            {
                length++;
                temp = temp.next;
            }
            n = length - n;
            if (n == 0)
            {
                head = head.next;
                return head;
            }
            else
            {
                temp = head;
                length = 0;
                while (temp != null)
                {
                    length++;
                    if (length == n)
                    {
                        temp.next = temp.next.next;
                        return head;
                    }
                    temp = temp.next;
                }
            }
            return head;
        }
        static int x = 0;
        public static void RemoveNthFromEnd(ListNode head, ListNode prev, int n, bool returning, int count)
        {
            x++;
            count++;
            if (head is null)
            {
                x--;
                return;
            }
            else RemoveNthFromEnd(head.next, head, n, returning, count);
            if (count == x)
            {
                head.next = head.next.next;
            }
            else if (count == 1 && x == 0)
            {
                head = head.next;
            }
        }

        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> results = new List<IList<int>>();
            Array.Sort(nums);
            int l = nums.Length;
            HashSet<string> done = new HashSet<string>();
            for (int i = 0; i < l; i++)
            {
                for (int j = i + 1; j < l; j++)
                {
                    int k = j + 1, q = l - 1;
                    while (k < q)
                    {
                        int sum = nums[i] + nums[j] + nums[k] + nums[q];
                        if (sum == target)
                        {
                            string dones = string.Format("{0}{1}{2}{3}", nums[i], nums[j], nums[k], nums[q]);
                            if (!done.Contains(dones))
                            {
                                List<int> ans = new List<int>();
                                ans.Add(nums[i]);
                                ans.Add(nums[j]);
                                ans.Add(nums[k]);
                                ans.Add(nums[q]);
                                results.Add(ans);
                                done.Add(dones);
                            }
                            if (nums[j] == nums[j + 1]) j++;
                            else if (nums[q] == nums[q - 1]) q--;
                            else break;
                        }
                        else
                        {
                            if (sum < target) k++;
                            else q--;
                        }
                    }
                }
            }
            return results;
        }

        public static IList<string> LetterCombinations(string digits)
        {
            IList<IList<int>> results = new List<IList<int>>();

            IList<string> result = new List<string>();
            int ln = digits.Length;
            if (digits.Length == 0) return result;
            string[] pad = { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            if (digits.Length == 1)
            {
                string y = pad[(Convert.ToInt32(digits)) - 2];
                int lk = y.Length;
                for (int i = 0; i < lk; i++)
                {
                    result.Add(y[i].ToString());
                }
            }
            else if (digits.Length == 2)
            {
                int p = Convert.ToInt32(digits);
                string y = pad[p / 10];
                string x = pad[p % 10];
                // int lk = y.Length;
                for (int i = 0; i < y.Length; i++)
                {
                    for (int j = 0; j < x.Length; j++)
                    {
                        result.Add(y[i].ToString() + x[j].ToString());
                    }
                }
            }

            return result;
        }

        public static bool IsAnagram(string a, string b)
        {
            int aL = a.Length;
            int bL = b.Length;
            if (aL != bL) return false;
            Dictionary<char, int> table = new Dictionary<char, int>();
            for (int i = 0; i < aL; i++)
            {
                if (table.ContainsKey(a[i])) table[a[i]]++;
                else table.Add(a[i], 1);
            }
            for (int i = 0; i < aL; i++)
            {
                if (table.ContainsKey(a[i]))
                {
                    if (table[a[i]] > 0)
                        table[a[i]]--;
                    else return false;
                }
                else return false;
            }
            return true;
        }

        public static int ThreeSumClosest(int[] nums, int target)
        {
            int result = 0;
            Array.Sort(nums);
            int min = int.MaxValue;
            int l = nums.Length - 2;
            int k = nums.Length - 1;
            for (int i = 0; i < l; i++)
            {
                // if (i == 0 || nums[i] != nums[i + 1])
                {
                    int j = i + 1, t = k;
                    while (j < t)
                    {
                        int sum = nums[i] + nums[t] + nums[j];
                        if (sum > target)
                        {
                            int temp = Math.Abs(sum - target);
                            if (temp < min)
                            {
                                min = temp;
                                result = sum;
                            }
                            t--;
                        }
                        else if (sum < target)
                        {
                            int temp = Math.Abs(sum - target);
                            if (temp < min)
                            {
                                min = temp;
                                result = sum;
                            }
                            j++;
                        }
                        else
                        {
                            return sum;
                        }
                    }
                }
            }
            return result;
        }

        public static String intToRomanJava(int num)
        {
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            String[] characters = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            StringBuilder sb = new StringBuilder();
            int indis = 0;
            while (num > 0)
            {
                if (num < values[indis])
                    indis++;
                else
                {
                    sb.Append(characters[indis]);
                    num -= values[indis];
                }
            }
            return sb.ToString();
        }

        public static string IntToRoman(int num)
        {
            StringBuilder s = new StringBuilder();

            while (num > 0)
            {
                if (num > 1000)
                {
                    int rem = num / 1000;
                    loop(rem, s, "M");
                    num = num % 1000;
                }
                else if (num > 899)
                {
                    s.Append("CM");
                    num = num % 900;
                }
                else if (num > 399)
                {
                    if (num < 500)
                        s.Append("CD");
                    else
                    {
                        int rem = (num - 500) / 100;
                        loop(rem, s, "C");
                    }
                    num = num % 100;
                }
                else if (num > 89)
                {
                    if (num < 100)
                    {
                        s.Append("XC");
                        num = num % 10;
                    }
                    else
                    {
                        int rem = num / 100;
                        loop(rem, s, "C");
                        num = num % 100;
                    }
                }
                else if (num > 39)
                {
                    if (num < 50)
                        s.Append("XL");
                    else
                    {
                        int rem = (num - 50) / 10;
                        loop(rem, s, "X");
                    }
                    num = num % 10;
                }
                else if (num > 8)
                {
                    if (num < 10)
                        s.Append("IX");
                    else
                    {
                        int rem = (num - 10) / 10;
                        loop(rem, s, "I");
                        num = num % 10;
                    }
                }
                else if (num > 4)
                {
                    s.Append("V");
                    int rem = (num - 5);
                    loop(rem, s, "I");
                }
                else if (num == 4)
                    s.Append("IV");
                else
                    loop(num, s, "I");
            }
            return s.ToString();
        }

        public static void loop(int k, StringBuilder s, string letter)
        {
            for (int i = 0; i < k; i++)
            {
                s.Append(letter);
            }
        }

        public static bool CanPartition(int[] nums)
        {
            //int sum = nums.Sum();
            //if (sum % 2 == 1)
            //{
            //    return false;
            //}

            //var result = new bool[(sum / 2) + 1];
            //result[0] = true;
            //foreach (var num in nums)
            //{
            //    for (int i = result.Length - 1; i >= num; i--)
            //    {
            //        if (result[i - num])
            //        {
            //            result[i] = true;
            //        }
            //    }
            //}

            //return result[result.Length - 1];
            int total = 0;
            foreach (int i in nums)
                total += i;
            if (total % 2 != 0)
                return false;

            return CanPartition(nums, 0, 0, total, new Hashtable());
        }
        private static bool CanPartition(int[] nums, int index, int sum, int total, Hashtable saved)
        {
            string s = index.ToString() + "-" + sum.ToString();
            if (saved.Contains(s))
                return (bool)saved[s];

            if (sum == total / 2)
                return true;

            if (sum > total / 2 || index >= nums.Length)
                return false;

            bool result = CanPartition(nums, index + 1, sum + nums[index], total, saved) || CanPartition(nums, index + 1, sum, total, saved);

            if (!saved.Contains(s))
                saved.Add(s, result);

            return result;
        }

        static int counter = 0;
        public static int KthSmallest(TreeNode root, int k)
        {
            if (root == null)
            {
                return -1;
            }

            int left = KthSmallest(root.left, k);
            if (left != -1)
            {
                return left;
            }

            counter++;
            if (counter == k)
            {
                return root.val;
            }

            int right = KthSmallest(root.right, k);
            if (right != -1)
            {
                return right;
            }

            return -1;
        }

        public static bool IsValidBSTM(TreeNode root)
        {
            return validate(root, null, null);
        }

        public static bool validate(TreeNode root, int? min, int? max)
        {
            if (root == null)
            {
                return true;
            }
            if (min != null && root.val <= min)
            {
                return false;
            }
            if (max != null && root.val >= max)
            {
                return false;
            }
            return validate(root.left, min, root.val)
                    && validate(root.right, root.val, max);
        }

        public static bool IsValidBST(TreeNode root)
        {
            if (root == null) return false;
            int leftMax = 0;
            int rightMax = 0;
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(root);
            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                if (node.left != null)
                {
                    if (node.left.val >= node.val || (leftMax > 0 && node.left.val >= leftMax)) return false;
                    else nodes.Enqueue(node.left);
                    leftMax = node.left.val;
                }
                if (node.right != null)
                {
                    if (node.right.val <= node.val || (rightMax > 0 && node.right.val <= rightMax)) return false;
                    else nodes.Enqueue(node.right);
                    rightMax = node.right.val;
                }
            }
            return true;
        }

        public static bool IsMatchs(string s, string p)
        {
            if (p.Length == 0) return s.Length == 0;
            bool first_match = ((s.Length > 0) && (p[0] == s[0] || p[0] == '.'));

            if (p.Length >= 2 && p[1] == '*')
            {
                return IsMatchs(s, p.Substring(2)) || (first_match && IsMatchs(s.Substring(1), p));
            }
            else
            {
                return first_match && IsMatchs(s.Substring(1), p.Substring(1));
            }
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n > 0)
            {
                int l = m + n;
                var p = new int[l];
                int t = 0;
                int k = 0;
                for (int i = 0; i < l; i++)
                {
                    if (k == n)
                    {
                        p[i] = nums1[t];
                        t++;
                    }
                    else if (t == m)
                    {
                        p[i] = nums2[k];
                        k++;
                    }
                    else if (nums1[t] < nums2[k])
                    {
                        p[i] = nums1[t];
                        t++;
                    }
                    else
                    {
                        p[i] = nums2[k];
                        k++;
                    }
                }
                for (int i = 0; i < l; i++)
                {
                    nums1[i] = p[i];
                }
            }
        }

        public static void DuplicateZeros(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == 0 && i <= arr.Length - 2)
                {
                    for (int j = arr.Length - 1; j > i; j--)
                    {
                        arr[j] = arr[j - 1];
                    }
                    arr[i + 1] = 0;
                    i++;
                }
            }
        }

        public static int[] SortedSquares(int[] nums)
        {
            int start = 0;
            int end = nums.Length - 1;
            int[] arr = new int[nums.Length];
            for (int i = (nums.Length - 1); i >= 0; i--)
            {
                if (Math.Abs(nums[start]) < Math.Abs(nums[end]))
                {
                    arr[i] = nums[end] * nums[end];
                    end--;
                }
                else
                {
                    arr[i] = nums[start] * nums[start];
                    start++;
                }
            }
            return arr;
        }

        public static bool IsValidC(string s)
        {
            if (s == "")
                return false;
            if (s.Length % 2 == 1) return false;
            HashSet<int> visited = new HashSet<int>();
            int limit = s.Length;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (!visited.Contains(i))
                {
                    if (i > limit) limit = s.Length;
                    visited.Add(i);
                    char correspondingValue = getCorrespondingC(s[i]);
                    int x = 1;
                    bool matched = false;
                    int expected = 0;
                    while (i + x < limit)
                    {
                        if (s[i + x] == correspondingValue)
                        {
                            if (i + x < s.Length && expected == 0) limit = i + x;
                            visited.Add(i + x);
                            if (expected == 0)
                            {
                                matched = true;
                                break;
                            }
                            else
                            {
                                x += 1;
                                expected--;
                            }
                        }
                        else
                        {
                            if (s[i] == s[i + x])
                            {
                                visited.Add(i + x);
                                expected++;
                            }
                            x += 1;
                        }
                    }
                    if (!matched) return false;
                }
            }
            return true;
        }

        private static char getCorrespondingC(char v)
        {
            if (v == 40) return ')';
            else if (v == 123) return '}';
            else return ']';
        }

        public static bool IsValid(string s)
        {
            if (s == "")
                return false;
            if (s.Length % 2 == 1) return false;
            HashSet<int> visited = new HashSet<int>();
            int limit = s.Length;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (!visited.Contains(i))
                {
                    if (i > limit) limit = s.Length;
                    visited.Add(i);
                    int correspondingValue = getCorresponding(char.ConvertToUtf32(s, i));
                    int x = 1;
                    bool matched = false;
                    int expected = 0;
                    while (i + x < limit)
                    {
                        if (char.ConvertToUtf32(s, i + x) == correspondingValue)
                        {
                            if (i + x < s.Length && expected == 0) limit = i + x;
                            visited.Add(i + x);
                            if (expected == 0)
                            {
                                matched = true;
                                break;
                            }
                            else
                            {
                                x += 1;
                                expected--;
                            }
                        }
                        else
                        {
                            if (s[i] == s[i + x])
                            {
                                visited.Add(i + x);
                                expected++;
                            }
                            x += 1;
                        }
                    }
                    if (!matched) return false;
                }
            }
            return true;
        }

        private static int getCorresponding(int v)
        {
            if (v == 40) return 41;
            else if (v == 123) return 125;
            else return 93;
        }

        public static bool IsPalindrome(string s)
        {
            s = s.ToLower();
            for (int i = 0, j = s.Length - 1; i <= j; i++, j--)
            {
                while (char.IsWhiteSpace(s[i]) || !char.IsLetterOrDigit(s[i]))
                {
                    if (i + 1 <= j)
                        i++;
                    else break;
                }
                while (char.IsWhiteSpace(s[j]) || !Char.IsLetterOrDigit(s[j]))
                {
                    if (j - 1 >= i)
                        j--;
                    else break;
                }
                Console.WriteLine(s[i] + ":" + s[j]);
                if (s[j] != s[i]) return false;
            }
            return true;
        }
        public static int solutionC(int[] A)
        {
            var currentNoTrees = A.Sum();
            var noGardens = A.Length;
            int requiredTrees;
            if (currentNoTrees % noGardens == 0)
            {
                //we have enough trees to redist over the gardens
                requiredTrees = currentNoTrees;
            }
            else
            {
                requiredTrees = currentNoTrees;
                //we need to plant more trees
                //Find the next divisior of noGardens
                while (requiredTrees % noGardens != 0)
                {
                    requiredTrees++;
                }

                //we have the no of required trees
            }
            //Redistribute any trees over x to other gardens
            //Plant new trees
            int treesPerGarden = requiredTrees / noGardens;
            int treesMoved = 0;
            int moves = 0;
            Array.Sort(A);
            for (var i = 0; i < A.Length; i++)
            {
                while (A[i] > treesPerGarden)
                {
                    A[i]--;
                    treesMoved++;
                    moves++;
                }
            }

            for (var i = 0; i < A.Length; i++)
            {
                while (A[i] < treesPerGarden)
                {
                    if (treesMoved != 0)
                    {
                        A[i]++;
                        treesMoved--;
                    }
                    else
                    {
                        //plant a tree
                        A[i]++;
                        moves++;
                    }

                }
            }

            return moves;
        }
        static int solutionw(int[] A)
        {
            int operations = 0;
            // write your code in Java SE 8
            int noOfTrees = 0;

            for (int i = 0; i < A.Length; i++)
            {
                noOfTrees += A[i];
            }

            int remainder = noOfTrees % A.Length;

            int requiredNoOfTrees = 0;
            if (remainder == 0)
            {
                requiredNoOfTrees = noOfTrees / A.Length;
            }
            else
            {
                //get next divisor
                int count = 0;
                while (noOfTrees % A.Length > 0)
                {
                    noOfTrees++;
                    count++;
                }
                requiredNoOfTrees = count;
            }

            int testOps = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < requiredNoOfTrees)
                {
                    A[i]++;
                    testOps++;
                }
                else
                {
                    A[i]--;
                    for (int j = 0; j < A.Length; j++)
                    {
                        if (A[i] < requiredNoOfTrees)
                        {
                            A[i]++;
                            testOps++;
                        }
                    }
                }
            }


            operations = testOps;
            return operations;
        }

        public static bool solution(int[] A, int K)
        {
            int n = A.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (A[i] > A[i + 1])
                    return false;
            }
            if (A[0] != 1 || A[n - 1] != K)
                return false;
            else
                return true;
        }
        public static bool solutionO(int[] A, int K)
        {
            int n = A.Length;
            for (int i = 0; i < n - 1; i++)
            {
                var t = A[i + 1];
                t = A[i] + 1;
                if (A[i] + 1 < A[i + 1])
                    if (A[i + 1] < K) return false;
            }
            if (A[0] != 1 && A[n - 1] != K)
                return false;
            else
                return true;
        }
        private static int solution(int[] A, int[] B)
        {

            int n = A.Length;
            int m = B.Length;
            Array.Sort(A);
            Array.Sort(B);
            int i = 0;

            for (int k = 0; k < n; k++)
            {
                if (i < m - 1 && B[i] < A[k])
                { i += 1; if (k + 1 == n && i + 1 < m) k--; }//this
                if (A[k] == B[i])
                    return A[k];
            }
            return -1;
        }

        private static string Riddle(string a)
        {
            if (a == "") return a;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '?')
                {
                    if (i == 0)
                    {
                        if (a.Length > 1)
                        {
                            if (a[1] == 'a') result.Append('b');
                            else result.Append('a');
                        }
                        else
                            result.Append('a');
                    }
                    else if (i == a.Length - 1)
                    {
                        if (result[i - 1] == 'a') result.Append('b');
                        else result.Append('a');
                    }
                    else
                    {
                        var c = 'a';
                        if (result[i - 1] == c || a[i + 1] == c)
                        {
                            c = 'b';
                            if (result[i - 1] == c || a[i + 1] == c)
                            {
                                c = 'c';
                            }
                        }
                        result.Append(c);
                    }
                }
                else result.Append(a[i]);
            }
            return result.ToString();
        }

        private static async Task<bool> countTo1000Async()
        {
            //for (int i = 0; i < 1001; i++)
            //{
            //    Console.Write(i);
            //}
            //await Task.Delay(0);
            var a = Task.Run(() => CountTo100());
            var b = Task.Run(() => CountTo100());
            var c = Task.Run(() => CountTo100());
            var d = Task.Run(() => CountTo100());
            var e = Task.Run(() => CountTo100());
            var f = Task.Run(() => CountTo100());
            var g = Task.Run(() => CountTo100());
            var h = Task.Run(() => CountTo100());

            await a;
            await b;
            await c;
            await d;
            await e;
            await f;
            await g;
            await h;
            return true;
        }

        private static void CountTo1000()
        {
            for (int i = 0; i < 80000001; i++)
            {
                //Console.Write(i);
            }
        }
        private static void CountTo100()
        {
            for (int i = 0; i < 10000001; i++)
            {
                //Console.Write(i);
            }
        }

        public static long minTime(List<int> files, int numCores, int limit)
        {
            if (numCores == 1) return files.Sum();
            long minTime = 0;
            files.Sort((a, b) => b.CompareTo(a));
            for (int i = 0; i < files.Count; i++)
            {
                if (limit > 0)
                {
                    if (files[i] % numCores == 0)
                    {
                        minTime += files[i] / numCores;
                        limit--;
                    }
                    else
                    {
                        minTime += files[i];
                    }
                }
                else
                {
                    minTime += files[i];
                }
            }
            return minTime;
        }

        public static string findSubstring(string s, int k)
        {
            if (s.Length == 0 || s.Length < k) return null;
            int maxVowels = 0, start = 0;
            for (int i = 0; i <= s.Length - k; i++)
            {
                //StringBuilder t = new StringBuilder();
                int vowels = 0;
                for (int j = 0; j < k; j++)
                {
                    if (s[i + j] == 'a' || s[i + j] == 'e' || s[i + j] == 'i' || s[i + j] == 'o' || s[i + j] == 'u') vowels++;
                }
                if (vowels > maxVowels)
                {
                    maxVowels = vowels;
                    start = i;
                }
            }
            if (maxVowels > 0)
                return s.Substring(start, k);
            else return null;
        }

        private static Stack<int> stackSort(Stack<int> s)
        {
            Stack<int> r = new Stack<int>(s.Count);
            while (s.Count > 0)
            {
                int temp = s.Pop();
                while (r.Count > 0 && r.Peek() > temp)
                {
                    s.Push(r.Pop());
                }
                r.Push(temp);
            }
            while (r.Count > 0)
            {
                s.Push(r.Pop());
            }
            return s;
        }

        private static int[] mergeSort(int[] arr)
        {
            if (arr.Length <= 1) return arr;
            int mid = arr.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[arr.Length % 2 == 0 ? mid : mid + 1];
            int[] results = new int[arr.Length];

            for (int i = 0; i < mid; i++)
            {
                left[i] = arr[i];
            }
            int x = 0;
            for (int i = mid; i < arr.Length; i++)
            {
                right[x] = arr[i];
                x++;
            }
            left = mergeSort(left);
            right = mergeSort(right);
            results = merge(left, right);
            return results;
        }

        private static int[] merge(int[] left, int[] right)
        {
            int[] result = new int[right.Length + left.Length];//create merged list 
            int indexL = 0, indexR = 0, indexRS = 0;
            while (indexL < left.Length || indexR < right.Length) //when both indexes are less than the length compare both 
            {
                if (indexL < left.Length && indexR < right.Length)
                {
                    if (left[indexL] < right[indexR])//add the less one - to the merged array
                    {
                        result[indexRS] = left[indexL];
                        indexRS++;
                        indexL++;
                    }
                    else
                    {
                        result[indexRS] = right[indexR];
                        indexRS++;
                        indexR++;
                    }
                }
                else if (indexL < left.Length)
                {
                    result[indexRS] = left[indexL];
                    indexRS++;
                    indexL++;
                }
                else if (indexR < right.Length)
                {
                    result[indexRS] = right[indexR];
                    indexRS++;
                    indexR++;
                }
            }
            return result;
        }

        private static bool iterate()
        {

            foreach (var item in new numbers(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }))
            {
                Console.WriteLine(item);
            }
            foreach (var item in new words(new string[] { "one", "two", "three", "four" }))
            {
                Console.WriteLine(item);
            }

            return true;
        }

        private static ListNode findIntersection(ListNode head, ListNode master)
        {
            if (head == null || master == null) return null;
            ListNode headSize = getTail(head);
            ListNode masterSize = getTail(master);
            if (headSize.next != masterSize.next) return null;
            //var longer = headSize.val > masterSize? head 
            return null;
        }

        private static ListNode getTail(ListNode head)
        {
            if (head == null) return null;
            int t = 0;
            while (head.next != null)
            {
                t++;
                head = head.next;
            }
            return new ListNode(t, head);
        }

        private static ListNode addNodes(ListNode head, ListNode tail)
        {
            int x = getLinkedListValue(head);
            int y = getLinkedListValue(tail);
            int z = x + y;
            ListNode ans = new ListNode(z % 10, null);
            z = z / 10;
            while (z > 0)
            {
                ans.next = new ListNode(z % 10, null);
                z = z / 10;
            }
            return ans;
        }

        private static int getLinkedListValue(ListNode head)
        {
            if (head != null) return (getLinkedListValue(head.next) * 10) + head.val;
            else return 0;
        }

        private static ListNode partitionNode(ListNode node, int v)
        {
            var head = new ListNode(node.val, null);
            var tail = head;
            while (node.next != null)
            {
                if (node.next.val < v)
                {
                    head = new ListNode(node.next.val, head);
                }
                else
                {
                    tail.next = new ListNode(node.next.val, null);
                    tail = tail.next;
                }
                node = node.next;
            }

            return head;
        }

        private static ListNode deleteNode(ListNode head, int v)
        {
            if (head == null) return null;
            var temp = head;
            while (temp != null)
            {
                if (temp.next != null && temp.next.val == v)
                {
                    temp.next = temp.next.next;
                    break;
                }
                else temp = temp.next;
            }
            return head;
        }

        private static ListNode nthToLast(ListNode head, int k)
        {
            ListNode p1 = head;
            ListNode p2 = head;

            //move p1 k nodes into the list
            for (int i = 0; i < k; i++)
            {
                if (p1.next == null) return null;
                p1 = p1.next;
            }
            while (p1 != null)
            {
                p1 = p1.next;
                p2 = p2.next;
            }
            return p2;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var d = new List<IList<int>>();
            if (nums.Length < 3) return d;
            var hash = new Dictionary<string, string>();

            for (int i = 0; i < nums.Length - 1; i++)
            {
                HashSet<int> s = new HashSet<int>();
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int x = -(nums[i] + nums[j]);
                    if (s.Contains(x))
                    {
                        Console.Write("{0} {1} {2}\n", x, nums[i], nums[j]);
                        var t = new int[] { x, nums[i], nums[j] };
                        Array.Sort(t);
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(t[0]);
                        stringBuilder.Append(t[1]);
                        stringBuilder.Append(t[2]);
                        if (!hash.ContainsKey(stringBuilder.ToString()))
                        {
                            d.Add(t);
                            hash.Add(stringBuilder.ToString(), null);
                        }
                    }
                    else
                    {
                        s.Add(nums[j]);
                    }
                }
            }

            //var d = new List<IList<int>>();
            //if (nums.Length < 3) return d;
            //var hash = new Dictionary<string, string>();
            //if (nums.Length == 3 && nums.Sum() == 0)
            //{
            //    d.Add(nums.ToList<int>());
            //    return d;
            //}
            //else
            //{
            //   // Array.Sort(nums);
            //    for (int i = 0; i < nums.Length-2; i++)
            //    {
            //        for (int j = i + 1; j < nums.Length-1; j++)
            //        {
            //            for (int k = j + 1; k < nums.Length; k++)
            //            {
            //                if (nums[i] + nums[j] + nums[k] == 0)
            //                {
            //                    var t = new int[] { nums[i], nums[j], nums[k] };
            //                    Array.Sort(t);
            //                    StringBuilder stringBuilder = new StringBuilder();
            //                    stringBuilder.Append(t[0]);
            //                    stringBuilder.Append(t[1]);
            //                    stringBuilder.Append(t[2]);
            //                    if (!hash.ContainsKey(stringBuilder.ToString()))
            //                    {
            //                        d.Add(t);
            //                        hash.Add(stringBuilder.ToString(), null);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            return d;
        }
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0) return "";
            if (strs.Length == 1) return strs[0];
            StringBuilder longest = new StringBuilder();
            int index = 0;

            //Array.Sort(strs, (x, y) => x.Length.CompareTo(y.Length));

            for (int j = 0; j < strs[0].Length; j++)
            {
                for (int i = 1; i < strs.Length; i++)
                {
                    if (strs[i].Length == index) return longest.ToString();
                    if (strs[0][index] != strs[i][index]) return longest.ToString();
                }
                longest.Append(strs[0][index]);
                index++;
            }
            return longest.ToString();
        }
        public static bool IsMatch(string s, string p)
        {
            if (p.Length == 0) return false;
            if (s.Length == 1 && p == ".") return true;
            if (p == ".*") return true;
            int frequency = 0;
            for (int i = 0, j = 0; i < s.Length; i++)
            {
                if (i == 0) ;

                // if(s[i] == s[i+1])
            }
            return true;
        }
        public static int MyAtoi(string s)
        {
            if (s.Length == 0) return 0;
            StringBuilder h = new StringBuilder();
            bool start = false, sign = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (!start)
                {
                    if (s[i] != ' ')
                    {
                        if (s[i] == '-' || s[i] == '+')
                        {
                            h.Append(s[i]);
                            start = true;
                            sign = true;
                        }
                        //else if (s[i] == '0' || s[i] == '1' || s[i] == '2' || s[i] == '3' || s[i] == '4' || s[i] == '5' || s[i] == '6' || s[i] == '7' || s[i] == '8' || s[i] == '9')
                        else if (char.IsDigit(s[i]))
                        {
                            h.Append(s[i]);
                            start = true;
                        }
                        else return 0;
                    }
                }
                else
                {
                    if (sign && (s[i] == '-' || s[i] == '+'))
                    {
                        if (h.Length == 1) return 0;
                        else return Int32.Parse(h.ToString());
                    }
                    // else if (s[i] == '0' || s[i] == '1' || s[i] == '2' || s[i] == '3' || s[i] == '4' || s[i] == '5' || s[i] == '6' || s[i] == '7' || s[i] == '8' || s[i] == '9')
                    else if (char.IsDigit(s[i]))
                    {
                        h.Append(s[i]);
                    }
                    else
                    {
                        if (h.Length > 0)
                        {
                            if (h.Length == 1 && sign) return 0;
                            if (Int32.TryParse(h.ToString(), out int t))
                                return t;
                            else
                            {
                                if (h[0] == '-') return Int32.MinValue;
                                else return Int32.MaxValue;
                            }
                        }
                        else return 0;
                    }
                }
            }
            if (h.Length > 0)
            {
                if (h.Length == 1 && sign) return 0;
                if (Int32.TryParse(h.ToString(), out int t))
                    return t;
                else
                {
                    if (h[0] == '-') return Int32.MinValue;
                    else return Int32.MaxValue;
                }
            }
            else return 0;
        }


        public static string Converts(string s, int numRows)
        {
            int interval = (numRows - 1) * 2;
            int x = interval;
            int y = interval;
            int z = 0;
            string ans = "";
            int rows = 1;
            while (true)
            {
                if (z < s.Length)
                {
                    ans += s[z];
                    z += x;
                    if (z < s.Length)
                    {
                        ans += s[z];
                        z += y;
                    }
                    else
                    {
                        z = rows;
                        if (rows == numRows) break; else rows++;
                        x -= 2;
                        if (x == 0) x = interval;
                        y += 2;
                        if (y > interval) y = 2;
                    }
                }
                else
                {
                    z = rows;
                    if (rows == numRows) break; else rows++;
                    x -= 2;
                    if (x == 0)
                    {
                        x = interval;
                    }
                    y += 2;
                    if (y > interval) y = 2;
                }
            }
            return ans;
        }

        private static string LongestPalindrome(string s)
        {
            if (s.Length < 2) return s;
            if (s.Length == 2) return s[0].ToString();
            if (Palindrome(s)) return s;
            for (int i = s.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < s.Length - i; j++)
                {
                    string h = s.Substring(j, i);
                    if (Palindrome(h)) return h;
                    h = s.Substring(s.Length - i - j, i);
                    if (Palindrome(h)) return h;
                }
            }
            return s[0].ToString();
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 0 && nums2.Length == 0) return 0;
            if (nums1.Length == 0)
            {
                if (nums2.Length == 1) return nums2[0];
                if (nums2.Length % 2 == 0) return (nums2[nums2.Length / 2] + nums2[(nums2.Length / 2) - 1]) / 2;
                else return nums2[nums2.Length / 2];
            }
            else if (nums2.Length == 0)
            {
                if (nums1.Length == 1) return nums1[0];
                if (nums1.Length % 2 == 0) return (nums1[nums1.Length / 2] + nums1[(nums1.Length / 2) - 1]) / 2;
                else return nums1[nums1.Length / 2];

            }
            else
            {
                int x = 0;
                int y = 0;
                var mid = (nums1.Length + nums2.Length) / 2;
                if ((nums1.Length + nums2.Length) % 2 == 1)
                {
                    for (int i = 0; i <= mid; i++)
                    {
                        if (x < nums1.Length && y < nums2.Length)
                        {
                            if (nums1[x] < nums2[y])
                            {
                                if (i == mid) return nums1[x];
                                x++;
                            }
                            else
                            {
                                if (i == mid) return nums2[y];
                                y++;
                            }
                        }
                        else if (x < nums1.Length)
                        {
                            if (i == mid) return nums1[x];
                            x++;
                        }
                        else
                        {
                            if (i == mid) return nums2[y];
                            y++;
                        }
                    }
                }
                else
                {
                    bool lastX = false;
                    for (int i = 0; i <= mid; i++)
                    {
                        if (x < nums1.Length && y < nums2.Length)
                        {
                            if (nums1[x] < nums2[y])
                            {
                                if (i == mid) return (double)(nums1[x] + (lastX ? nums1[x - 1] : nums2[y - 1])) / 2;
                                lastX = true;
                                x++;
                            }
                            else
                            {
                                if (i == mid) return (double)(nums2[y] + (lastX ? nums1[x - 1] : nums2[y - 1])) / 2;
                                lastX = false;
                                y++;
                            }
                        }
                        else if (x < nums1.Length)
                        {
                            if (i == mid) return (double)(nums1[x] + (lastX ? nums1[x - 1] : nums2[y - 1])) / 2;
                            lastX = true;
                            x++;
                        }
                        else
                        {
                            if (i == mid) return (double)(nums2[y] + (lastX ? nums1[x - 1] : nums2[y - 1])) / 2;
                            lastX = false;
                            y++;
                        }
                    }
                }
            }
            return 0;
        }

        private static int Reverse(Int32 x)
        {
            if (x == 0) return 0;
            if (x > 0 && x < 10) return x;
            if (x < 0 && x > -10) return x;
            if (x > Math.Pow(2, 31) - 1 || x < -1 * Math.Pow(2, 31)) return 0;
            Int32 y = 0;
            while (x != 0)
            {
                try
                {
                    checked
                    {
                        y = (y * 10) + x % 10;
                        x = x / 10;
                    }
                }
                catch (Exception)
                {

                    return 0;
                }
            }
            return y;
        }

        private static int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0) return 0;
            int max = 0;
            int temp = 0;
            Dictionary<char, int> letters = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!letters.ContainsKey(s[i]))
                {
                    temp++;
                    letters.Add(s[i], i);
                }
                else
                {
                    i = letters[s[i]] + 1;
                    letters.Clear();
                    letters.Add(s[i], i);
                    if (temp > max) max = temp;
                    temp = 1;
                    if (max > s.Length - i) break;
                }
            }
            return temp > max ? temp : max;
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            else if (l2 == null) return l1;

            ListNode result;
            int first = l1.val + l2.val;
            int remaining = first / 10;
            result = new ListNode(first % 10, null);
            var temp = result;

            while (l1.next != null || l2.next != null)
            {
                if (l1.next != null && l2.next != null)
                {
                    first = l1.next.val + l2.next.val + remaining;
                    result.next = new ListNode(first % 10, null);
                    result = result.next;
                    remaining = first / 10;
                    l1 = l1.next;
                    l2 = l2.next;
                }
                else if (l1.next != null)
                {
                    first = l1.next.val + remaining;
                    result.next = new ListNode(first % 10, null);
                    result = result.next;
                    remaining = first / 10;
                    l1 = l1.next;
                }
                else
                {
                    first = l2.next.val + remaining;
                    result.next = new ListNode(first % 10, null);
                    result = result.next;
                    remaining = first / 10;
                    l2 = l2.next;
                }
            }
            if (remaining > 0) result.next = new ListNode(remaining, null);

            return temp;
        }
        static ListNode Results(int value)
        {
            ListNode result = new ListNode(value % 10, null);
            var temp = result;
            value = value / 10;
            while (value > 0)
            {
                result.next = new ListNode(value % 10, null);
                result = result.next;
                value = value / 10;
            }
            return temp;
        }
        static int GetValue(ListNode l1)
        {
            int first = l1.val;
            while (l1.next != null)
            {
                first = first * 10 + l1.next.val;
                l1 = l1.next;
            }
            return first;
        }
        private static bool solutions(string str)
        {
            Char a = 'A';
            bool hasOccured = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (!hasOccured && a.Equals(str[i]))
                {
                    hasOccured = true;
                }
            }
            return hasOccured;
        }

        //public static int solutionb(int[] blocks)
        //{
        //    for (int i = 0; i < blocks.Length; i++)
        //    {

        //    }
        //    //int maxRight = 0;
        //    //int maxLeft = 0;
        //    //int tempRight = 0, tempLeft = 0;
        //    //int optimalStartingRight = 0;
        //    //int tempIndexRight = 0;
        //    //int tempIndexLeft = blocks.Length - 1;
        //    //int optimalStartingLeft = tempIndexLeft;
        //    ////int size = blocks.Length;
        //    //for (int i = 0; i < blocks.Length - 1; i++)
        //    //{
        //    //    if (blocks[i] <= blocks[i + 1])
        //    //    {
        //    //        tempRight++;
        //    //    }
        //    //    else
        //    //    {
        //    //        if (tempRight > maxRight)
        //    //        {
        //    //            maxRight = tempRight;
        //    //            tempRight = 0;
        //    //            optimalStartingRight = tempIndexRight;
        //    //        }
        //    //        tempIndexRight = i + 1;
        //    //    }
        //    //    if (blocks[(blocks.Length - 1) - i] <= blocks[(blocks.Length - 1) - i - 1])
        //    //    {
        //    //        tempLeft++;
        //    //    }
        //    //    else
        //    //    {
        //    //        if (tempLeft > maxLeft)
        //    //        {
        //    //            maxLeft = tempLeft;
        //    //            tempLeft = 0;
        //    //            optimalStartingLeft = tempIndexLeft;
        //    //        }
        //    //        tempIndexLeft = (blocks.Length - 1) - i - 1;
        //    //    }
        //    //}

        //    //maxRight = maxRight < tempRight ? tempRight : maxRight;

        //    //maxLeft = maxLeft < tempLeft ? tempLeft : maxLeft;
        //    //bool jumped = false;
        //    //if (optimalStartingRight > 0)
        //    //{
        //    //    for (int i = optimalStartingRight; i > 0; i--)
        //    //    {
        //    //        if (blocks[i] <= blocks[i - 1])
        //    //        {
        //    //            if (!jumped)
        //    //            {
        //    //                maxRight++;
        //    //                jumped = true;
        //    //            }
        //    //            maxRight++;
        //    //        }
        //    //        else break;
        //    //    }
        //    //}
        //    //else maxRight++;
        //    //jumped = false;
        //    //if (optimalStartingLeft < blocks.Length - 1)
        //    //    for (int i = optimalStartingLeft; i < blocks.Length - 1; i++)
        //    //    {
        //    //        if (blocks[i] <= blocks[i + 1])
        //    //        {
        //    //            if (!jumped)
        //    //            {
        //    //                maxLeft++;
        //    //                jumped = true;
        //    //            }
        //    //            maxLeft++;
        //    //        }
        //    //        else break;
        //    //    }
        //    //else maxLeft++;

        //    //return maxLeft > maxRight ? maxLeft : maxRight;
        //}
        public static int solution(int[] ranks)
        {
            if (ranks.Length < 2) return 0;
            int result = 0;
            int duplicates = 0;
            Array.Sort(ranks);
            for (int i = 0; i < ranks.Length - 1; i++)
            {
                if (ranks[i] == ranks[i + 1]) duplicates++;
                else if (ranks[i] + 1 == ranks[i + 1])
                {
                    result += duplicates + 1;
                    duplicates = 0;
                }
                else duplicates = 0;
            }
            return result;
        }

        private static void MatrixRotateTimes(int[][] matrix, int y)
        {
            int n = matrix.Length;
            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    int top = matrix[first][i]; // save top
                                                // left->top
                    matrix[first][i] = matrix[last - offset][first];
                    // bottom -> left
                    matrix[last - offset][first] = matrix[last][last - offset]; ;
                    // right -> bottom
                    matrix[last][last - offset] = matrix[i][last];
                    //I top -> right

                    matrix[i][last] = top; // right<-saved top
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private static void MatrixRotate(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix.Length != matrix[0].Length) Console.WriteLine("Not n by n");
            int n = matrix.Length;
            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    int top = matrix[first][i]; // save top
                                                // left->top
                    matrix[first][i] = matrix[last - offset][first];
                    // bottom -> left
                    matrix[last - offset][first] = matrix[last][last - offset]; ;
                    // right -> bottom
                    matrix[last][last - offset] = matrix[i][last];
                    //I top -> right

                    matrix[i][last] = top; // right<-saved top
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private static string Compression(string str)
        {
            if (str.Length < 3) return str;
            int count = 0;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                count++;
                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    result.Append(str[i]);
                    result.Append(count);
                    count = 0;
                }
            }
            return (str.Length == result.Length) ? str : result.ToString();
        }

        private static string OneWay(string first, string second)
        {
            if (first.Length == second.Length)
                return checkEdits(first, second);
            else if (first.Length == second.Length + 1)
                return checkEditsRemove(first, second);
            else if (first.Length == second.Length - 1)
                return checkEditsRemove(second, first);
            else return "false";
        }

        private static string checkEditsRemove(string first, string second)
        {
            bool hasDiff = false;
            int index = 0;
            for (int i = 0; i < second.Length; i++)
            {
                if (!first[i].Equals(second[index]))
                {
                    if (hasDiff) return "false";
                    hasDiff = true;
                }
                else
                    index++;
            }
            return "true";
        }

        private static string checkEdits(string first, string second)
        {
            bool hasDiff = false;
            for (int i = 0; i < first.Length; i++)
            {
                if (!first[i].Equals(second[i]))
                {
                    if (hasDiff) return "false";
                    hasDiff = true;
                }
            }
            return "true";
        }

        private static string PalindromePhrase(string str)
        {
            int odds = 0;
            var hash = new Hashtable();
            for (int i = 0; i < str.Length; i++)
            {
                if (!str[i].Equals(' '))
                {
                    if (hash.ContainsKey(str[i])) hash[str[i]] = Convert.ToInt32(hash[str[i]]) + 1;
                    else
                        hash.Add(str[i], 1);
                }
            }
            foreach (DictionaryEntry item in hash)
            {
                if (Convert.ToInt32(item.Value) % 2 > 0) odds++;
                if (odds > 1)
                {
                    return "false";
                }
            }
            return "true";
        }

        private static string Urilify(string str)
        {
            var strn = "";
            str = str.Trim();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Equals(' ')) strn += "%20";
                else strn += str[i];
            }
            return strn;
        }

        private static bool UniqueCharacters(string str)
        {
            if (str.Length == 0 || str.Length == 1) return true;
            else if (str.Length > 128) return false;
            var hash = new Hashtable();
            for (int i = 0; i < str.Length; i++)
            {
                if (hash.Contains(str[i]))
                    return false;
                else hash.Add(str[i], i);
            }
            return true;
        }

        private static void NumberSwap(int a, int b)
        {
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
            Console.WriteLine("a : {0}, b : {1}", a, b);
        }

        private static void permutationMine(string str, string start)
        {
            if (str.Length == 0)
            {
                Console.WriteLine(start);
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    string cut = str.Substring(0, i) + str.Substring(i + 1);
                    permutationMine(cut, start + str[i]);
                }
            }
        }
















        private static void permutation(string str, string prefix)
        {
            if (str.Length == 0)
            {
                Console.WriteLine(prefix);
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    String rem = str.Substring(0, i) + str.Substring(i + 1);
                    permutation(rem, prefix + str[i]);
                }
            }
        }
        int fib(int n)
        {
            if (n <= 0) return 0;
            else if (n == 1) return 1;
            return fib(n - 1) + fib(n - 2);
        }

        int fib(int n, int[] memo)
        {
            if (n <= 0) return 0;
            else if (n == 1) return 1;
            else if (memo[n] > 0) return memo[n];
            memo[n] = fib(n - 1, memo) + fib(n - 2, memo);
            return memo[n];
        }

        private static Hashtable GetCubesSum(int n)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var hash = new Hashtable();
            for (int i = 1; i <= n; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    var value = Math.Pow(i, 3) + Math.Pow(j, 3);
                    if (hash.Contains(value))
                    { }
                    //Console.WriteLine(string.Format("{0},{1},{2}", hash[value], i, j));
                    else hash.Add(value, i + "," + j);
                }
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            return hash;
        }

        private static int MultiplyA(int a, int b)
        {
            if (a == 0 || b == 0) return 0;
            else if (a < 0 && b > 0) return 0 - Multiply(0 - a, b);
            else if (a > 0 && b < 0) return 0 - Multiply(a, 0 - b);
            else if (a > 0 && b > 0) return Multiply(a, b);
            else return Multiply(0 - a, 0 - b);
        }

        private static int Multiply(int a, int b)
        {
            if (b == 0) return 0;
            return a + Multiply(a, b - 1);
        }

        private static int[] twoSum(int[] nums, int target)
        {
            var map = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement) && Convert.ToInt32(map[complement]) != i)
                {
                    return new int[] { Convert.ToInt32(map[complement]), i };
                }
                if (!map.ContainsKey(nums[i]))
                    map.Add(nums[i], i);
            }
            throw new Exception("No two sum solution");
        }

        public static string ReverseWordstack(string s) =>
    string.Join(" ", new Stack<string>(s.Split(' ').Where(_ => _ != "")));

        public static string ReverseWords(string s) => string.Join(" ", s.Split(' ').Where(_ => _ != "").Reverse());

        private static string PalindromeWords(string s)
        {
            var s_split = s.Trim().Split(' ');
            // Initialize empty string
            var str = "";

            // Loop through all except the first word because we don't want
            // space after the last word in the new string
            for (int i = (s_split.Length - 1); i >= 0; i--)
            {
                // If not a null string, add string and space
                // else add empty string (aka don't make a change)
                str += s_split[i] != "" ? s_split[i] + " " : "";
            }
            // Add last word without space
            str += s_split[0];

            return str;
        }

        //Step 1
        //void reverse(string out a, int i, int j)
        //{
        //    while (i < j) swap(a[i++], a[j--]);
        //}

        //Step 2
        //void reverseWords(string &a, int n)
        //{
        //    int i = 0, j = 0;

        //    while (i < n)
        //    {
        //        while (i < j) i++; //make i and j equal (j might be ahead as it might have seen a word before)
        //        while (i < n && a[i] == ' ') i++; // skip spaces

        //        while (j < i) j++; //make j and i equal (i might be ahead as it found few spaces)
        //        while (j < n && a[j] != ' ') j++; // skip non spaces

        //        reverse(a, i, j - 1);                      // reverse the word
        //    }
        //}

        ////Step 3
        //string cleanSpaces(string &a, int n)
        //{
        //    int i = 0, j = 0;

        //    while (j < n)
        //    {
        //        while (j < n && a[j] == ' ') j++;             // skip spaces
        //        while (j < n && a[j] != ' ') a[i++] = a[j++]; // keep non spaces
        //        while (j < n && a[j] == ' ') j++;             // skip spaces
        //        if (j < n) a[i++] = ' ';                      // keep only one space
        //    }

        //    a = a.substr(0, i);
        //}


        private static bool Palindrome(string x)
        {
            if (x.Length <= 1) return true;
            for (int i = 0, j = x.Length - 1; i <= j; i++, j--)
            {
                if (x[i] != x[j]) return false;
            }
            return true;
        }

        private static int powerSum(int x, int n, int t)
        {
            int value = Convert.ToInt32(x - Math.Pow(t, n));

            if (value < 0) return 0;
            else if (value == 0) return 1;
            else return powerSum(value, n, t + 1) +
                        powerSum(x, n, t + 1);
            //int O = 0, t, r;
            //double c = Math.Pow(x, (1.0 / n));
            //if (c % 1 == 0)
            //{
            //    O++;
            //    t = Convert.ToInt32(c) - 1;
            //}
            //else
            //{
            //    t = Convert.ToInt32(Math.Floor(c));
            //}

            //for (int i = t; i > t/2; i--)
            //{
            //    r = 0;
            //    if (factorialSquares(i, n) == x) O++;
            //    else if (factorialSquares(i, n) > x)
            //    {
            //        r += Convert.ToInt32(Math.Pow(i,n));
            //        int j = Convert.ToInt32(Math.Floor(Math.Pow(x - r, 1.0 / n)));
            //        for (int d = j; d > 0; d--)
            //        {
            //            if (factorialSquares(d, n) == x - r)
            //            {
            //                O++;
            //                break;
            //            }
            //            if(Math.Pow(d, n) + r <= x)
            //            r += Convert.ToInt32(Math.Pow(d, n));
            //            if (r == x)
            //            {
            //                O++;
            //                break;
            //            }
            //        }
            //    }
            //    else break;
            //}
            //return O;
        }

        private static string kangaroo(int x1, int v1, int x2, int v2)
        {
            if (x1 < x2 && v1 > v2 && x2 >= v1 - v2)
                return "Yes";
            else return "NO";
        }

        private static int repairRoads(int n, int[][] roads)
        {
            int robots = 0, l = 0, r = 0;
            for (int i = 0; i < roads.Length; i++)
            {
                if (l == 0 && r == 0)
                {
                    robots++;
                    l = roads[i][0];
                    r = roads[i][1];
                }
                else
                {
                    if (l != roads[i][0] && l != roads[i][1] && r != roads[i][0] && r != roads[i][1])
                        robots++;
                    l = roads[i][0];
                    r = roads[i][1];
                }
            }
            return robots;
        }

        private static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            int al = 0, ol = 0;
            for (int i = 0; i < apples.Length; i++)
            {
                if (apples[i] + a >= s && apples[i] + a <= t)
                    al++;
            }
            for (int i = 0; i < oranges.Length; i++)
            {
                if (oranges[i] + b >= s && oranges[i] + b <= t)
                    ol++;
            }
            Console.WriteLine(al);
            Console.WriteLine(ol);
        }

        private static int[] circularArrayRotation(int[] a, int k, int[] queries)
        {
            k = k % a.Length;
            int[] results = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int r = queries[i] - k;
                if (r < 0) r = a.Length + r;
                results[i] = a[r];
            }
            return results;
        }

        private static string getPrime(int v)
        {
            if (v == 2)
                return "Prime";
            else if (v % 2 == 0 && v != 2)
                return "Not prime";
            else if (v < 2)
                return "Not prime";

            int sq = (int)Math.Sqrt(v);
            for (int i = 2; i <= sq; i++)
            {
                if (v % i == 0) return "Not prime";
            }
            return "Prime";
        }

        private static int countingValleys(int n, string s)
        {
            int v = 0;
            int l = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'U') l++;
                else if (s[i] == 'D') l--;

                if (l == 0 && s[i] == 'U')
                    v++;
            }
            return v;
        }

        private static Node removeDuplicates(Node head)//recursion
        {
            if (head == null || head.next == null)
                return head;
            if (head.data == head.next.data)
            {
                head.next = head.next.next;
                removeDuplicates(head);
            }
            else
            {
                removeDuplicates(head.next);
            }
            return head;
        }

        private static void levelOrder(Node root)
        {
            Queue<Node> qu = new Queue<Node>();
            qu.Enqueue(root);
            while (qu.Count > 0)
            {
                var r = qu.Dequeue();
                Console.Write(r.data + " ");
                if (r.left != null)
                    qu.Enqueue(r.left);
                if (r.right != null)
                    qu.Enqueue(r.right);
            }
        }

        private static Queue<int> getQue(Node root, Queue<int> qu)//recursion
        {
            if (root == null)
            {
                return qu;
            }
            if (qu.Count == 0)
            {
                qu.Enqueue(root.data);
            }

            if (root.left != null)
                qu.Enqueue(root.left.data);
            if (root.right != null)
                qu.Enqueue(root.right.data);
            if (root.left != null)
                getQue(root.left, qu);
            if (root.right != null)
                getQue(root.right, qu);

            return qu;
        }

        private static int getHeight(Node root)//recursion
        {
            if (root == null)
                return -1;

            return 1 + Math.Max(getHeight(root.left), getHeight(root.right));
        }

        static Node insertSearch(Node root, int data)// insert nodes
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.data)
                {
                    cur = insertSearch(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = insertSearch(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }

        private static void PrintArray<T>(T[] intArray)//Generics
        {
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(intArray[i]);
            }
        }

        private static void SortArrayBubble(int[] a)
        {
            int n = a.Length;
            int swaps = 0;
            for (int i = 0; i < n; i++)
            {
                // Track number of elements swapped during a single array traversal
                int numberOfSwaps = 0;

                for (int j = 0; j < n - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                        Swap(ref a[j], ref a[j + 1]);
                        numberOfSwaps++;
                    }
                }

                // If no elements were swapped during a traversal, array is sorted
                if (numberOfSwaps == 0)
                {
                    break;
                }
                else
                {
                    swaps += numberOfSwaps;
                }
            }
            Console.WriteLine("Array is sorted in {0} swaps.", swaps);
            Console.WriteLine("First Element: {0}", a[0]);
            Console.WriteLine("Last Element: {0}", a[n - 1]);
        }

        private static void matrixRotation(List<List<int>> matrix, int r)
        {
            // int[,] ret = new int[matrix.Count, matrix.Count];
            var d = new List<List<int>>();
            //var dd = matrix.Count % 2;
            bool oddW = matrix.Count % 2 == 0 ? false : true, oddL = matrix[0].Count % 2 == 0 ? false : true, flip = false;
            int halfW = matrix.Count / 2, halfL = matrix[0].Count / 2, y = 0;
            for (int m = 0; m < r; m++)
            {
                y = 0;
                flip = false;
                d = new List<List<int>>();
                for (int i = 0; i < matrix.Count; ++i)
                {
                    var tempList = new List<int>();
                    for (int j = 0; j < matrix[i].Count; ++j)
                    {
                        int t;//, a = 1;
                        int x;

                        if (matrix.Count == matrix[0].Count)
                        {
                            if (oddL && i == j && i == halfL)//middle odd
                            {
                                t = i;
                                x = j;
                            }
                            else if (j >= i && j < (matrix.Count - 1) - i)
                            {
                                t = i;
                                x = j + 1;
                            }

                        }

                        //tempList.Add(matrix[t][x]);
                    }
                    d.Add(tempList);
                    if (!oddW)
                    {
                        if (!flip && (y + 1) < halfL)
                            y++;
                        else if (!flip)
                            flip = true;
                        else y--;
                    }
                    else
                    {
                        if (!flip && (y + 1) < halfL)
                            y++;
                        else if (!flip)
                        {
                            y++;
                            flip = true;
                        }
                        else y--;
                    }
                }
                matrix = d;
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                Console.WriteLine(string.Join(" ", d[i]));
            }
        }

        private static void almostSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                    break;
                else if (i + 2 == arr.Length)
                {
                    Console.WriteLine("yes");
                    return;
                }
            }
            if (arr.Length == 2)
            {
                Console.WriteLine("yes");
                Console.WriteLine("swap 1 2");
                return;
            }
            int p1 = 0, p2 = 0, d1 = 0, d2 = 0, no = 0, ii = 0, rr = 0;
            bool up = true;
            //if(arr.Length == 3)
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (!up) no++;
            //    if (arr[i] > arr[i + 1] && up && i > 0)
            //    {
            //        up = false;
            //        if (p1 == 0)
            //        {
            //            p1 = arr[i];
            //            ii = i + 1;
            //        }
            //    }
            //    else if (arr[i] < arr[i + 1] && !up)
            //    {
            //        up = true;
            //        if (d1 == 0)
            //        {
            //            rr = i + 1;
            //            d1 = arr[i];
            //        }
            //    }
            //}
            //if (p1 < p2 && d1 < d2)
            //{
            //    if (no == 1)
            //    {
            //        Console.WriteLine("yes");
            //        Console.WriteLine("swap {0} {1}", ii, rr);
            //        return;
            //    }
            //}
            p1 = 0; p2 = 0; d1 = 0; d2 = 0; no = 0; ii = 0; rr = 0;
            up = true;
            for (int i = 0; i < arr.Length; i++)
            {
                if (!up) no++;
                if (i < arr.Length - 1 && arr[i] > arr[i + 1] && up && i > 0)
                {
                    up = false;
                    if (p1 == 0)
                    {
                        p1 = arr[i];
                        d1 = arr[i - 1];
                        ii = i + 1;
                    }
                }
                else if (i < arr.Length - 1 && arr[i] < arr[i + 1] && !up)
                {
                    up = true;
                    if (p2 == 0)
                    {
                        rr = i + 1;
                        p2 = arr[i + 1];
                        d2 = arr[i];
                    }
                }
                else if (i == arr.Length - 1 && arr[i] < arr[i - 1] && !up)
                {
                    up = true;
                    if (p2 == 0)
                    {
                        rr = i + 1;
                        //p2 = arr[i + 1];
                        d2 = arr[i];
                    }
                }
            }
            if (p1 < p2 && d1 < d2)
            {
                if (no == 1)
                {
                    Console.WriteLine("yes");
                    Console.WriteLine("swap {0} {1}", ii, rr);
                    return;
                }
                else
                {
                    Console.WriteLine("yes");
                    Console.WriteLine("reverse {0} {1}", ii, rr);
                    return;
                }
            }
            if (d1 < d2)
            {
                if (no == 1)
                {
                    Console.WriteLine("yes");
                    Console.WriteLine("swap {0} {1}", ii, rr);
                    return;
                }
            }
            up = true;
            p1 = 0; p2 = 0; d1 = 0; d2 = 0; no = 0; ii = 0; rr = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (!up) no++;
                if (arr[i] > arr[i + 1] && up && i > 0)
                {
                    up = false;
                    if (p1 == 0)
                    {
                        p1 = arr[i];
                        ii = i;
                    }
                    else p2 = arr[i];
                }
                else if (arr[i] < arr[i + 1] && !up)
                {
                    up = true;
                    if (d1 == 0)
                    {
                        d1 = arr[i];
                    }
                    else
                    {
                        d2 = arr[i];
                        rr = i;
                    }
                }
            }
            if (no > 0)
                if (d2 > arr[ii - 1] && d2 < arr[ii + 1] && p1 < arr[rr + 1] && p1 > arr[rr - 1])
                {

                    Console.WriteLine("yes");
                    Console.WriteLine("swap {0} {1}", ii + 1, rr + 1);
                    return;

                }
            Console.WriteLine("no");
        }

        private static int[] cutTheSticks(int[] arr)
        {
            Array.Sort(arr);
            Dictionary<int, int> dick = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (dick.ContainsKey(arr[i]))
                {
                    dick[arr[i]] += 1;
                }
                else
                {
                    dick.Add(arr[i], 1);
                }
            }
            var res = new int[dick.Count()];
            int q = arr.Length, j = 0;
            foreach (var item in dick)
            {
                res[j] = q;
                q -= item.Value;
                j++;
            }
            return res;
        }

        private static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            if (y1 > y2) return 10000;
            else if (m1 > m2 && y1 == y2) return 500 * (m1 - m2);
            else if (d1 > d2 && y1 == y2 && m1 == m2) return 15 * (d1 - d2);
            else return 0;
        }

        private static int squares(int a, int b)
        {
            return (int)(Math.Floor(Math.Sqrt(b)) - Math.Ceiling(Math.Sqrt(a)) + 1);
        }

        private static string appendAndDelete(string s, string t, int k)
        {
            int commonlength = 0;
            for (int i = 0; i < Math.Min(s.Length, t.Length); i++)
            {
                if (s[i] == t[i]) commonlength++;
                else break;
            }
            if ((s.Length + t.Length - 2 * commonlength) > k)
            {
                return "No";
            }
            else if ((s.Length + t.Length - 2 * commonlength) % 2 == k % 2)
            {
                return "Yes";
            }
            else if ((s.Length + t.Length - k) < 0)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        private static void extraLongFactorials(int n)
        {
            BigInteger bigIntFromDouble = 1;
            for (int i = 1; i <= n; i++)
            {
                bigIntFromDouble *= i;
            }
            Console.WriteLine(n);
            Console.WriteLine(bigIntFromDouble);
        }

        //private static BigInteger factorials(int n)
        //{

        //        for (int i = 0; i < BigInteger; i++)
        //        {

        //        }

        //}

        private static int findDigits(int n)
        {
            int u = 0;
            var num = n.ToString().ToCharArray();
            foreach (int item in num)
            {
                int p = item - 48;
                if (p > 0 && n % p == 0)
                    u++;
            }
            return u;
        }

        private static int jumpingOnClouds(int[] c, int k)
        {
            int e = 100, i = k % c.Length;
            e -= c[i] * 2 + 1;
            while (i != 0)
            {
                i = (i + k) % c.Length;
                e -= c[i] * 2 + 1;
            }
            return e;
        }

        static int[] permutationEquation(int[] p)
        {
            int k = 0;
            Dictionary<int, int> t = new Dictionary<int, int>();
            int[] res = new int[p.Length];
            for (int i = 1; i <= p.Length; i++)
            {
                t.Add(i, p[i - 1]);
            }
            for (int i = 0; i < p.Length; i++)
            {
                k = t.FirstOrDefault(x => x.Value == i + 1).Key;
                res[i] = t.FirstOrDefault(x => x.Value == k).Key;
            }
            // t.TryGetValue

            return res;
        }

        private static int[] RepetitiveKSums(int[] input, int[] results)
        {
            int[] res = new int[input[0]];
            if (input[0] == 1) res[0] = (results[0] / input[1]);
            else
            {
                int f = 0;
                results.OrderBy(c => c).ToArray();
                for (int i = 0, j = input[0]; i < results.Length; i += (j * (input[1] - 1)), j--)
                {
                    res[f] = results[i] / input[1];
                    f++;
                }
            }
            return res;
        }

        //private static int[] kFactorization(int n, int[] v)
        //{
        //   // int[] result
        //    v = v.OrderBy(c => c).ToArray();

        //}

        public int divisorSum(int n)
        {
            int sum = 0;
            int sqrt = (int)Math.Sqrt(n);

            // Small optimization: if n is odd, we can't have even numbers as divisors
            int stepSize = (n % 2 == 1) ? 2 : 1;

            for (int i = 1; i <= sqrt; i += stepSize)
            {
                if (n % i == 0)
                { // if "i" is a divisor
                    sum += i + n / i; // add both divisors
                }
            }

            // If sqrt is a divisor, we should only count it once
            if (sqrt * sqrt == n)
            {
                sum -= sqrt;
            }
            return sum;
        }

        public static Node insert(Node head, int data)
        {
            //Complete this method
            if (head == null)
            {
                return new Node(data);
            }
            else if (head.next == null)
            {
                head.next = new Node(data);
            }
            else
            {
                insert(head.next, data);
            }
            return head;
        }

        public static void display(Node head)
        {
            Node start = head;
            while (start != null)
            {
                Console.Write(start.data + " ");
                start = start.next;
            }
        }

        private static int pickingNumbers(List<int> a)
        {
            int maxlength = 0, prev = 0, tempCurrLength = 0;
            a.Sort();
            var i = from numbers in a
                    group numbers by numbers into grouped
                    select new { Number = grouped.Key, Freq = grouped.Count() };

            var k = i.ToDictionary(y => y.Number);

            foreach (var item in k)
            {
                if (prev == 0)
                {
                    prev = item.Value.Number;
                    tempCurrLength = item.Value.Freq;
                }
                else
                {
                    if (item.Value.Number == prev + 1)
                    {
                        tempCurrLength += item.Value.Freq;
                    }
                }
            }

            return 0;
        }

        public static int CountDivisions(double number)
        {
            int count = 0;

            if (number > 0 && number % 2 == 0)
            {
                count++;
                number /= 2;

                return count += CountDivisions(number);
            }

            return count;
        }

        private static int computeDifference(int[] a)
        {
            a.Max();
            int b = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[a.Length - 1] - a[i] > b) b = a[a.Length - 1] - a[i];
            }
            return b;
        }

        private static int beautifulDays(int i, int j, int k)
        {
            int result = 0;
            for (int ii = i; ii <= j; ii++)
            {
                var num = ii.ToString().ToCharArray();
                for (int l = 0, m = num.Length - 1; l < m; l++, m--)
                {
                    Swap(ref num[l], ref num[m]);
                }
                //string t = num.ToString();
                if ((ii - int.Parse(new string(num))) % k == 0) result++;
            }
            return result;
        }

        private static int utopianTree(int n)
        {
            int odd = 0, result = 0;
            for (int i = -1; i < n; i++)
            {
                if (odd == 0)
                {
                    result++;
                    odd++;
                }
                else
                {
                    result = result * 2;
                    odd = 0;
                }
            }
            return result;
        }

        private static int designerPdfViewer(int[] h, string word)
        {
            int height = 0;
            Dictionary<char, int> inputs = new Dictionary<char, int>();
            char first = 'a';
            for (int i = 0; i < h.Count(); i++)
            {
                inputs.Add(first, h[i]);
                first = (char)(first + 1);
            }
            for (int i = 0, j = word.Length - 1; i <= j; i++, j--)
            {
                inputs.TryGetValue(word[i], out int result);
                if (result > height) height = result;
                inputs.TryGetValue(word[j], out result);
                if (result > height) height = result;

            }
            return height * word.Length;
        }

        private static int hurdleRace(int k, int[] height)
        {
            int max = height.Max();
            if (k < max) return max - k;
            else return 0;
        }

        private static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            if (scores[scores.Count() - 1] > alice[alice.Count() - 1])
            {
                return Enumerable.Repeat(scores.Distinct<int>().Count() + 1, alice.Count()).ToArray();
            }

            int ranking = 1, lastScore = 0, aliceScore = alice.Count() - 1;
            int[] aliceScores = new int[alice.Count()];
            for (int i = 0; i < scores.Count(); i++)
            {
                if (i == 0)
                {
                    lastScore = scores[i];
                    if (alice[aliceScore] >= lastScore)
                    {
                        assignScores(ref aliceScores, ref aliceScore, ranking, lastScore, alice);
                    }
                }
                else
                {
                    if (lastScore > scores[i])
                    {
                        lastScore = scores[i];
                        ranking++;
                    }
                    if (alice[aliceScore] >= lastScore)
                    {
                        assignScores(ref aliceScores, ref aliceScore, ranking, lastScore, alice);
                    }
                }
                if (aliceScore < 0)
                    i = scores.Count();
            }
            if (aliceScore > -1)
                for (int i = aliceScore; i >= 0; i--)
                {
                    aliceScores[aliceScore] = ranking + 1;
                }
            return aliceScores;
        }

        private static void assignScores(ref int[] aliceScores, ref int aliceScore, int ranking, int lastScore, int[] alice)
        {
            while (alice[aliceScore] >= lastScore)
            {
                aliceScores[aliceScore] = ranking;
                aliceScore--;
                if (aliceScore < 0) return;
            }
        }



        //void insert(String s)
        //{
        //    foreach (char every in s)
        //    {
        //        if (child node belonging to current char is null)
        //{
        //            child node = new Node();
        //        }
        //        current_node = child_node;
        //    }
        //}

        private static int binaryConsecutive(int n)
        {
            // List<int> binary = new List<int>(); 
            int longest = 0, current = 0;

            while (n > 0)
            {
                int remainder = n % 2;
                n /= 2;
                if (remainder == 1)
                {
                    current++;
                    if (current >= longest)
                        longest = current;
                }
                else
                {
                    current = 0;
                }
            }
            return longest;
        }

        private static int factorial(int n)
        {
            //recursion
            if (n > 1) return factorial(n - 1) * n;
            return n;
        }

        private static int factorialSquares(int n, int y)
        {
            //recursion
            if (n > 1) return factorialSquares(n - 1, y) + (int)Math.Pow(n, y);
            return n;
        }

        private static void hourglassArrays()
        {

            int[][] arr = new int[6][];

            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int max = 0, sum = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    sum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] + arr[i + 1][j + 1] + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                    if (i == 0 && j == 0) max = sum; else if (sum > max) max = sum;
                }
            }
            Console.Write(max);
        }

        static void dictionary()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, int> inputs = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] ab = Console.ReadLine().Split(' ');
                inputs.Add(ab[0], int.Parse(ab[1]));
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) return;

                inputs.TryGetValue(input, out int result);

                if (result == 0) Console.WriteLine("Not found");
                else Console.WriteLine(input + "=" + inputs[input]);
            }
        }

        static string twoArrays(int k, int[] A, int[] B)
        {
            Array.Sort(A);
            Array.Reverse(B);
            for (int i = 0, j = 0; i < A.Length; i++, j++)
            {
                if (A[i] + B[j] < k) return "NO";
            }
            return "YES";
        }

        private static void sort(int[] arr, int[][] orders)
        {
            int[] sequence = Enumerable.Range(1, orders.Length).ToArray();
            //for (int i = 0; i < arrr.Length; i++)
            //{
            orders[0] = new int[2] { 8, 1 };//9
            orders[1] = new int[2] { 4, 2 };//6
            orders[2] = new int[2] { 5, 6 };//11
            orders[3] = new int[2] { 3, 1 };//4
            orders[4] = new int[2] { 4, 3 };//7
                                            //}
                                            //for (int i = 0; i < arr.Length; i++)
                                            //{
            int n = orders.Length;
            int k, j, least = 0, leastindex = 0;
            for (k = 0; k < n - 1; k++)
            {
                leastindex = k;
                least = (orders[k][0] + orders[k][1]);
                for (j = k + 1; j <= n - 1; j++)
                {
                    if ((orders[k][0] + orders[k][1]) > (orders[j][0] + orders[j][1]) && (orders[j][0] + orders[j][1]) < least)
                    {
                        least = (orders[j][0] + orders[j][1]);
                        leastindex = j;
                    }
                }
                Swap(ref orders[k], ref orders[leastindex]);
                Swap(ref sequence[k], ref sequence[leastindex]);
                //Console.WriteLine(string.Join(" ", sequence));
            }
            //Console.WriteLine(string.Join(" ", sequence));
        }

        private static void OddsAndEvens(string n)
        {
            string odd = "", even = "";
            for (int i = 0, j = 1; i < n.Length; i++, i++, j++, j++)
            {
                even += n[i]; odd += j < n.Length ? n[j].ToString() : "";
            }
            Console.WriteLine(even + " " + odd);
        }

        public void amIOld()
        {
            int age = 0;
            // Do some computations in here and print out the correct statement to the console 
            if (age < 13)
            {
                Console.WriteLine("print You are young");
            }
            else if (age >= 13 && age < 18)
            {
                Console.WriteLine("print You are a teenager");
            }
            else Console.WriteLine("print You are old");
        }

        public void yearPasses()
        {
            // Increment the age of the person in here
            //age += 1;
        }


        static void solve(double meal_cost, int tip_percent, int tax_percent)
        {

            Console.WriteLine(Math.Round(meal_cost));
            double t = meal_cost * tax_percent / 100;
            Console.WriteLine(((meal_cost * tax_percent / 100)));
            Console.WriteLine(meal_cost * tip_percent / 100);
            Console.WriteLine(Math.Round(meal_cost + (meal_cost * tip_percent / 100) + (meal_cost * tax_percent / 100)));
        }

        private static int birthdayCakeCandles(int[] ar)
        {
            int total = 0, max = ar.Max();
            total = ar.Count(x => x == max);
            return total;
        }

        private static void miniMaxSum(int[] arr)
        {
            Int64 total = 0, min = arr.Min(), max = arr.Max();

            for (int i = 0; i < arr.Length; i++)
            {
                total += arr[i];
            }

            Console.WriteLine((total - max) + " " + (total - min));
            //arr.Sort()
            //for (int i = 0; i < arr.Length; i++)
            //{

            //}
        }
        //public static T[] RemoveAt<T>(this T[] source, int index)
        //{
        //    T[] dest = new T[source.Length - 1];
        //    if (index > 0)
        //        Array.Copy(source, 0, dest, 0, index);

        //    if (index < source.Length - 1)
        //        Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

        //    return dest;
        //}

        static bool NextPerm(char[] a)
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

        static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }

        static string biggerIsGreater(string w)
        {
            w.ToCharArray();
            if (w.Length > 1)
            {
                var len = w.Length;
                var most = w[w.Length - 1];
                var rest = "";
                for (int i = 0; i < w.Length; i++)
                {
                    if (most > w[w.Length - (1 + i)])
                    {
                        rest = i > 0 ? w[w.Length - (1 + i)] + rest : "";
                        return w.Substring(0, w.Length - (1 + i)) + most.ToString() + rest;
                    }
                    rest = i > 0 ? w[w.Length - (1 + i)] + rest : "";
                }
            }
            return "no answer";
        }


        public static string FindSubstring(string s, int k)
        {
            int most = 0; int winner = 0;
            // Console.WriteLine(s.Count());
            var vowels = "aeiou";
            if (s.Length > k)
                if (s.Intersect(vowels).Any())
                    for (int i = 0; i <= s.Length - k; i++)
                    {
                        // Console.WriteLine(s.Substring(i, k));
                        var totals = 0;
                        if (s.Substring(i, k).Intersect(vowels).Any())
                            for (int x = 0; x < s.Substring(i, k).Count(); x++)
                            {
                                totals += vowels.Contains(s.Substring(i, k).Substring(x, 1)) ? 1 : 0;
                            }
                        if (totals > most)
                        {
                            winner = i;
                            most = totals;
                        }
                    }

            return most > 0 ? s.Substring(winner, k) : "Not found!";
        }

        static string angryProfessor(int k, int[] a)
        {
            var ontime = 0;
            for (int i = 0; i < a.Count(); i++)
            {
                ontime += a[i] >= 0 ? 1 : 0;
            }
            if (ontime >= k) return "NO";
            else return "YES";
        }

        private static string timeConversion(string s)
        {
            s.Trim().Replace(" ", "");
            var x = s.Split(':').ToList();
            if (x[2].ToUpper().Contains("AM") && x[0].Equals("12"))
            {
                return string.Format("{0}:{1}:{2}", "00", x[1], x[2].Replace("AM", ""));
            }
            else if (x[2].ToUpper().Contains("PM"))
            {
                return string.Format("{0}:{1}:{2}", Convert.ToInt32(x[0]) < 12 ? Convert.ToInt32(x[0]) + 12 : Convert.ToInt32(x[0]), x[1], x[2].Replace("PM", ""));
            }
            else return s.Replace("PM", "").Replace("AM", "");
        }

        private static void plusMinus(int[] arr)
        {
            int c = 0, b = 0, a = 0;
            for (int i = 0; i < arr.Count(); i++)
            {
                a += arr[i] > 0 ? 1 : 0;
                b += arr[i] < 0 ? 1 : 0;
                c += arr[i] == 0 ? 1 : 0;
            }
            Console.WriteLine(Math.Round((double)a / arr.Count(), 6).ToString("0.000000"));
            Console.WriteLine(Math.Round((double)b / arr.Count(), 6).ToString("0.000000"));
            Console.WriteLine(Math.Round((double)c / arr.Count(), 6).ToString("0.000000"));
        }

        private static int diagonalDifference(List<List<int>> arr)
        {
            var res = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                res += (arr[i][arr.Count - 1 - i] - arr[i][i]);
            }
            return res < 0 ? res * -1 : res;
        }

        private static int diagonalDifference2(List<List<int>> arr)
        {
            int res = 0, res2 = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                res += (arr[i][i]);
            }
            for (int i = 0; i < arr.Count; i++)
            {
                res2 += (arr[i][arr.Count - 1 - i]);
            }

            return res2 - res;
        }
    }

    internal class Calculator
    {
        internal int power(int n, int p)
        {
            if (n < 0 || p < 0) throw new Exception("n and p should be non-negative");
            return (int)Math.Pow(n, p);
        }
    }

    class Node
    {
        public int data;
        public Node next, left, right;
        public Node(int d)
        {
            data = d;
            next = null;
            left = right = null;
        }

    }
}
