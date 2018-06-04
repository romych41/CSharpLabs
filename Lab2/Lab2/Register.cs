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
        public Register(ArrayList triggers) => this.triggers = triggers;

        public Register() => this.triggers = new ArrayList();
        

        public void AddTrigger(Trigger T) => this.triggers.Add(T);

        public void RemoveTrigger(Trigger T) => this.triggers.Remove(T);

        public void ShowTriggers()
        {
            foreach (Trigger T in this.triggers)
            {
                Console.WriteLine(T);
            }
        }
    }
}
