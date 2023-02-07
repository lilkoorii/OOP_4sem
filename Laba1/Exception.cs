using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    internal class WeightException : Exception
    {
        public string ErrorClass { get; set; }
        public WeightException(string message, string errorClass) : base(message) //наследуем message от System.Exception
        {
            this.ErrorClass = errorClass;
        }
    }
}
