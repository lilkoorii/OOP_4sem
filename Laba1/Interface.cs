using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1
{
    public interface ICalculator
    {
        int CalcMale();
        int CalcFemale();
        double CalcIMT();
        void IMTType();
        int CalcFuture();

    }
}
