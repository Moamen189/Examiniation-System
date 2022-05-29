using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiniation_System
{
    class Answer
    {
        string value;
        int index;

        public string Value { get => value; set => this.value = value; }
        public int Index { get => index; set => index = value; }

        public Answer(string value, int index)
        {
            this.value = value;
            this.index = index;
        }
    }
}
