using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HW3
{
    class FibonacciTextReader : TextReader
    {
        private int maxLines = -1;
        private int callsMade = 0;
        private System.Numerics.BigInteger firstLastValue = 0;
        private System.Numerics.BigInteger secondLastValue = 1;

        public FibonacciTextReader(int newMax)
        {
            this.maxLines = newMax;
        }

        public override string ReadLine()
        {
            if (this.callsMade == 0)
            {
                this.callsMade++;
                return 0.ToString();
            }
            else if (this.callsMade == 1)
            {
                this.callsMade++;
                return 1.ToString();
            }
            else
            {
                System.Numerics.BigInteger returnValue = this.firstLastValue + this.secondLastValue;
                this.firstLastValue = this.secondLastValue;
                this.secondLastValue = returnValue;

                this.callsMade++;
                return returnValue.ToString();
            }
        }

        public override string ReadToEnd()
        {
            StringBuilder stringBuilder = new StringBuilder(string.Empty);
            for (int i = 0; i < this.maxLines; i++)
            {
                stringBuilder.Append((i + 1).ToString() + ": " + this.ReadLine() + "\r\n");
            }

            return stringBuilder.ToString();
        }
    }
}
