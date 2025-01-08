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

        //'Volatile' to ensure up to date values are read regardless of compiler optimizations (important for asynchronous threading)
        private volatile bool isRunning = true;
        private volatile bool isCancelled = false;
        
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
            while (time > 0)
            {
                //Validating the thread to continue if the thread is not cancelled
                if (cancellationToken.IsCancellationRequested || isCancelled)
                {                   
                    return;
                }
                //Checking for being paused every 100 miliseconds to avoid over consumption of resources
                while (!isRunning)
                {
                    Thread.Sleep(100); 
                }

                Console.Clear();
                Console.WriteLine($"Time remaining: {time} seconds");
                Thread.Sleep(1000); // Simulate a 1-second interval
                time--;
            }           
        }                  
        
        //Used in junction with a boolean to stop the input thread when the timer is at 0
        public int GetTime()
        {
            return time; 
        }

        public void Pause()
        {
            isRunning = false;
        }

        public void Resume()
        {
            isRunning = true;
        }

        public void Cancel()
        {
            isCancelled = true; 
        }
    }
}
