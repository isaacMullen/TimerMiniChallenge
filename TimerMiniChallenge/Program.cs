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
            Console.WriteLine($"Press 'P' to pause | Press 'R' to resume | Press 'C' to cancel.\n\nPress any key To Begin.");
            Console.ReadKey();
            
            CancellationTokenSource cts = new CancellationTokenSource();
            
            Timer timer = new Timer(8);

            //Creating seperate thread for the timer to run on. Passing it a token so I can efficiently control the thread 
            Thread timerThread = new Thread(() => timer.StartCountDown(cts.Token));
            timerThread.Start();

            //Assigning a thread to detect input asyncronously (without interfering with other threads such as the one that controls the timer)
            Thread inputThread = new Thread(() =>
            {
                while (true)
                {                    
                    if(timer.GetTime() == 0)
                    {
                        Console.Clear();
                        break;
                    }
                    
                    if (Console.KeyAvailable)
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
                            timer.Resume();                            
                        }
                        else if (key == ConsoleKey.C)
                        {
                            Console.Clear();                            
                            timer.Cancel();
                            break;
                        }
                    }
                }
            });            
                   
            
            //Starting the input thread
            inputThread.Start();
            
            //Ensuring the sub threads finish their current task before proceeding with the main thread and exiting the program
            timerThread.Join();
            inputThread.Join();
                        
            Console.WriteLine("Program ended.");
            Console.ReadKey();           
        }

    }
}

