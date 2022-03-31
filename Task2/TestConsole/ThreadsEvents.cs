using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole;

public static class ThreadsEvents
{

    public static void TestThreads()
    {
        for(int i=1; i<=10; i++)
        {
            var thread = new Thread(
                () =>
                {
                    var result = Calc(2, i);
                    Console.WriteLine("Поток {0}. 2 в степени {1} = {2}", Environment.CurrentManagedThreadId, i, result);
                });
            thread.Start();
        }
    }

    public static void Test_Two_Threads()
    {
        Semaphore semaphore = new Semaphore(0, 2);
        for (int i = 1; i <= 10; i++)
        {
            var thread = new Thread(
                () =>
                {
                    semaphore.WaitOne();
                    var i0 = i;
                    var result = Calc(2, i0);
                    Console.WriteLine("Поток {0}. 2 в степени {1} = {2}", Environment.CurrentManagedThreadId, i, result);
                });
            thread.Start();
            semaphore.Release();
        }
    }

    public static void TestThreadsEvents()
    {
        var manual_event = new ManualResetEvent(false);
        var threads = new Thread[100];
        for (int i = 0; i <= threads.Length-1; i++)
        {
            try
            {
                threads[i] = new Thread(() =>
                {
                    manual_event.WaitOne();
                    var i0 = i;
                    var result = Calc(2, i0);
                    Console.WriteLine("Поток {0}. 2 в степени {1} = {2}", Environment.CurrentManagedThreadId, i0, result);
                }, 30);
                threads[i].Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Достигнуто максимальное количество потоков!");
                Console.ReadLine(); 
            }
        }

        Console.WriteLine("Разрешаем вычисления");
        Console.ReadLine();

        manual_event.Set();

        Console.WriteLine("Вычисления заверешены");
    }

    public static void ThreadsDictionary()
    {
        var dict = new ConcurrentDictionary<int, double>();

        for (int i = 0; i <= 10; i++)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                var i0 = i;
                var result = dict.GetOrAdd(i0, d => Calc(2, i0));
                Console.WriteLine("Поток {0}. 2 в степени {1} = {2}", Environment.CurrentManagedThreadId, i0, result.ToString());
            });

            Console.WriteLine();

            Console.ReadLine();
        }

        var j = 6;
        Console.WriteLine("2 в степени {0} = {1}", j, dict.GetOrAdd(j, 0).ToString());

    }

    static readonly object locker = new();

    public static void Run()
    {
        Console.WriteLine("Запускается вычисление в неограниченном числе потоков");

        TestThreads();

        Console.WriteLine();

        
        Console.WriteLine("Запускается вычисление в 2 потоках");

        Test_Two_Threads();

        Console.WriteLine("Запускается вычисление в потоках по команде пользователя");

        TestThreadsEvents();

        Console.WriteLine("Заполняем данными потоконезависимый dictionary");

        ThreadsDictionary();
    }

    private static double Calc(int number, int pow)
    {
        lock (locker)
        {
            Thread.Sleep(100);
            return Math.Pow(number, pow);
        }
    }
}
