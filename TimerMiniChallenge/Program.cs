using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerMiniChallenge
{
    internal class Program
    {
        static void Main()
        {
            Timer timer = new Timer(5);

            timer.StartCountDown();
        }
    }
}
