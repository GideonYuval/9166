using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9166
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        static Node<int> Arr2List(int[] arr)
        {
            Node<int> lst = new Node<int>(arr[0]);
            Node<int> last = lst;

            for (int i = 1; i < arr.Length; i++)
            {
                last.SetNext(new Node<int>(arr[i]));
                last = last.GetNext();
            }

            return lst;
        }

        //Q1 - 
        //1. תנו דוגמה לרשימה שעבורה תחזיר הפעולה אמת, ולרשימה שעבורה יוחזר שקר
        //2. מה עושה הפעולה
        public static bool Numbers(Node<int> p)
        {
            if (!p.HasNext())
                return true;
            else
            {
                int x = p.GetValue();
                int y = p.GetNext().GetValue();
                if ((x * y) > 0)
                    return false;
                else
                    return Numbers(p.GetNext());
            }
        }


        //Q2
        //1. מה יוחזר עבור הרשימה
        //6->30->12->3
        //מהי מטרת הפעולה
        public static int Value(Node<int> p)
        {
            if (p.GetNext() == null)
                return p.GetValue();
            else
                return Math.Max(p.GetValue(), Value(p.GetNext()));
        }

        //Q3

        //עקבו אחרי הפעולה הבאה - מה יודפס
        //מה מטרת הפעולה CallDoingWhat
        //מה הסיבוכית של הפעולה

        static void CallDoingWhat()
        {
            int[] arr = { 1, 4, 7, 5, 2, 30 };
            Node<int> head = Arr2List(arr);
            Console.WriteLine(head);
            Node<int> prev = head;
            while (prev.GetNext() != null)
                prev = prev.GetNext();
            DoingWhat(head, prev);
            Console.WriteLine(head);
        }

        public static void DoingWhat(Node<int> p, Node<int> q)
        {
            int x, y;
            if ((p != q) && (q.GetNext() != p))
            {
                x = p.GetValue();
                y = q.GetValue();
                if (x != y)
                {
                    p.SetValue(y);
                    q.SetValue(x);
                }
                Node<int> prev = p;
                while (prev.GetNext() != q)
                    prev = prev.GetNext();
                DoingWhat(p.GetNext(), prev);
            }
        }

        //Q3.1
        //תנו דוגמה לרשימה שיש בה 3 איברים שיוחזר אמת, ורשימה של שלושה איברים שיוחזר עבורה שקר
        //question1 - if Check returned true for a list, what will DoingWhat return for the same list?
        //question2 - give an example of a list with at least 3 elements, which Check returns false, and DoingWhat won't change the list
        public static bool Check(Node<int> p)
        {
            if (!p.HasNext())
                return true;
            else
            {
                int x = p.GetValue();
                int y = p.GetNext().GetValue();
                return (x == y) && Check(p.GetNext());
            }
        }


    }
}
