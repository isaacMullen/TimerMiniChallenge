using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TimerMiniChallenge
{
    internal class Timer
    {
        private int time;
        
        public Timer(int initialTime)
        {                       
            if(initialTime < 0)
            {
                throw new ArgumentException("Timer must be above 0!");
            }
            time = initialTime;
        }

        public void StartCountDown()
        {
            PerformCountDown();
        }

        private void PerformCountDown()
        {
            //Displaying Initial Time
            Console.WriteLine(time);

            while (time >= 0)
            {
                Thread.Sleep(1000);
                time -= 1;
                Console.WriteLine(time);      
            }                                    
        }  
        
        public int GetCurrentTime()
        {
            return time;
        }       
    }
}
