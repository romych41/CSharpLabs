using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class JK : Trigger
    {
        public JK() : base()
        {
        }

        public JK(int input, int output) : base(input, output)
        {
        }

        public override Trigger DeepCopy() => new JK(this.inn, this.outt);

        public override string ToString() => "|RS|-input: " + this.input + " output: " + this.output;
    }
}
