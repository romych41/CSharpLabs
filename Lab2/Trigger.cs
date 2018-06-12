using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    abstract class Trigger
    {
        protected int inn, outt;
        public string input, output;

        public Trigger()
        {
            this.input = "0";
            this.output = "0";
            this.inn = 0;
            this.outt = 0;
        }

        public Trigger(int input, int output)
        {
            this.input = DecToBin(input);
            this.output = DecToBin(output);
            this.inn = input;
            this.outt = output;
        }

        public void SetValues(int input, int output)
        {
            this.input = DecToBin(input);
            this.output = DecToBin(output);
            this.inn = input;
            this.outt = output;
        }

        public void ResetValues()
        {
            this.input = "0";
            this.output = "0";
            this.inn = 0;
            this.outt = 0;
        }

        public abstract Trigger DeepCopy();

        private string DecToBin(int a)
        {
            if (a == 0)
                return "0";
            else if (a == 1)
                return "1";
            else
                try
                {
                    return DecToBin(a / 2) + (a % 2);
                }
                catch(OverflowException e)
                {
                    Console.WriteLine("Overflow exception");
                    return null;
                }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Trigger t = obj as Trigger;
            if (t as Trigger == null)
                return false;
            return ((this.input == t.input) && (this.output == t.output));
        }

        public override int GetHashCode() => inn + outt;

        public static bool operator ==(Trigger a, Trigger b) => (a.Equals(b));

        public static bool operator !=(Trigger a, Trigger b) => !(a.Equals(b));
    }
}