using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class RS : Trigger
    {
        public RS() : base()
        {
        }

        public RS(int input, int output) : base(input, output)
        {
        }

        public override Trigger DeepCopy() => new RS(this.inn, this.outt);

        public override string ToString() => "|RS|-input: " + this.input + " output: " + this.output;
    }
}
