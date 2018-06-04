using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList(5);
            RS r1 = new RS(0, 1);
            RS r2 = new RS(5, 4);
            list.Add(r1);
            list.Add(new RS(0, 2));
            list.Add(new RS(0, 3));
            list.Add(new JK(1, 1));
            list.Add(new JK(2, 1));
            Register R1 = new Register(list);
            R1.AddTrigger(new JK(3, 3));
            R1.RemoveTrigger(r1);
            R1.ShowTriggers();
            Console.WriteLine("==: "+(r1==r2)+" \n!=: "+(r1!=r2)+"\n Equals: "+r1.Equals(r1)+"; "+r1.Equals(r2)+"\n Hash: "+r1.GetHashCode()+"; "+r2.GetHashCode());
            Console.ReadKey();
        }
    }
}
