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

        private bool isRunning = true;
        
        public Timer(int initialTime)
        {                       
            if(initialTime < 0)
            {
                throw new ArgumentException("Timer must be above 0!");
            }
            time = initialTime;
        }

        public void StartCountDown(CancellationToken cancellationToken)
        {                        
            while (time >= 0)
            {
                if (cancellationToken.IsCancellationRequested || !isRunning)
                {
                    return;
                }
                while (!isRunning)
                {
                    Thread.Sleep(100); // Avoid busy waiting
                }

                Console.Clear();
                Console.WriteLine($"Time remaining: {time} seconds");
                Thread.Sleep(1000); // Simulate a 1-second interval
                time--;
            }
        }                  
        
        public void Pause()
        {
            isRunning = false;
        }

        public void Resume()
        {
            isRunning = true;
        }
    }
}
