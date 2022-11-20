using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CsharpTests

{
    class MutexTests
    {
        //public Thread KeyboardThread = new Thread(KeyboardProcess);
        
        static void Main(string[] args)
        {
            keyboardTh KeyBoardsThread = new keyboardTh();
            while (true)
            {
                // запускаем пять потоков
                for (int i = 1; i < 6; i++)
                {
                    Reader reader = new Reader(i);                    
                }
                Console.WriteLine("Конец основной программы");
            }            
        }

        class Reader
        {
            // создаем семафор
            static Semaphore sem = new Semaphore(3, 3);
            static Semaphore keyboardSem = new Semaphore(1, 1);
            Thread myThread;
            //Thread keyboardThread;
            int count = 3;// счетчик чтения

            public Reader(int i)
            {
                myThread = new Thread(Read);
                myThread.Name = $"Читатель {i}";
                myThread.Start();
            }

            public void Read()
            {
                while (count > 0)
                {
                    sem.WaitOne();  // ожидаем, когда освободиться место

                    Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");

                    Console.WriteLine($"{Thread.CurrentThread.Name} читает");
                    Console.WriteLine("\n");
                    Thread.Sleep(1000);

                    Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");
                    sem.Release();  // освобождаем место

                    count--;
                    Thread.Sleep(1000);
                }
            }

            //Thread for requesting keyboard
            //public void KeyboardProcess()
            //{
            //    myThread = new Thread(KeyboardProcess);
            //    myThread.Name = $"Опрос Клавиатуры. Процесс";
            //    myThread.Start();
            //}
        }

        class keyboardTh
        {
            Thread KeyboardThread;

            public keyboardTh()
            {
                KeyboardThread = new Thread(KeyboardProcess);
                KeyboardThread.Start();
            }
        }

        static/*why not public?*/ void KeyboardProcess()
        {
            string keyboard;
            keyboard = Console.ReadKey().ToString();
            switch(keyboard)
            {
                case "space":
                    {
                        //Thread
                        
                    } break;
                case "enter": {; } break;
                default: break;
            }
        }
    }
}

//namespace KeyboardThread
//{
//    KeyboardThread.Start();
//}