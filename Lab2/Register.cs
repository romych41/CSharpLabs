using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Register
    {
        public ArrayList triggers;
        public delegate void del();
        public event del ev;
        public Register(ArrayList triggers)
        {
            try
            {
                this.triggers = triggers;
            }
            catch(ArrayTypeMismatchException e)
            {
                Console.WriteLine("Array type mismatch exception");
            }
        }

        public Register() => this.triggers = new ArrayList();//TUT LYAMBDA ALO


        public void AddTrigger(Trigger T)
        {
            this.triggers.Add(T);
            ev();
        }

        public Trigger GetTrigger(int i)
        {
            try
            {
                return (Trigger)triggers[i];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Index out of range exception");
                return null;
            }
            catch(InvalidCastException e)
            {
                Console.WriteLine("Invalid cast exception");
                return null;
            }
        }

        public void RemoveTrigger(Trigger T) => this.triggers.Remove(T);

        public void ShowTriggers()
        {
            foreach (Trigger T in this.triggers)
            {
                Console.WriteLine(T);
            }
            ev();
        }
    }
}
