using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerMiniChallenge
{
    internal class Program
    {
        static void Main()
        {
            CancellationTokenSource cts = new CancellationTokenSource();


            Timer timer = new Timer(5);

            Thread timerThread = new Thread(() => timer.StartCountDown(cts.Token));
            timerThread.Start();

            Thread inputThread = new Thread(() =>
            {
                while (true)
                {                                        
                    if(Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true).Key;

                        if(key == ConsoleKey.P)
                        {
                            Console.Clear();
                            Console.WriteLine("Paused");
                            timer.Pause();                            
                        }
                        else if (key == ConsoleKey.R)
                        {
                            Console.Clear();
                            Console.WriteLine("Resumed");
                            timer.Resume();                            
                        }
                    }
                }
            });
                        
            inputThread.Start();
        }

    }
}

