using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace UsingThreading
{
    public class Cell
    {
        private int cell;
        private volatile bool readerFlag = false;
        private Object lockThis = new Object();

        public void WriteToCell(int val)
        {
            lock (lockThis)
            {
                if (readerFlag)
                {
                    try
                    {
                        Monitor.Wait(lockThis);
                    }
                    catch (ThreadInterruptedException ex)
                    {
                        Console.WriteLine("Caught therad interrupted ex in WriteToCell: " + ex.Message);
                    }
                    catch (SynchronizationLockException ex)
                    {
                        Console.WriteLine("Caught SynchronizationLockException in WriteToCell: " + ex.Message);
                    }
                }
                cell = val;
                Console.WriteLine("Produced: {0}", cell);
                readerFlag = true;
                Monitor.Pulse(lockThis);
            }
        }

        public int ReadFromCell()
        {
            lock (lockThis)
            {
                if (!readerFlag)
                {
                    try
                    {
                        Monitor.Wait(lockThis);
                    }
                    catch (ThreadInterruptedException ex)
                    {
                        Console.WriteLine("Caught therad interrupted ex in WriteToCell: " + ex.Message);
                    }
                    catch (ThreadStateException ex)
                    {
                        Console.WriteLine("Caught thread state ex in WriteToCell: " + ex.Message);
                    }
                }
                
                Console.WriteLine("Consumed: {0}", cell);
                readerFlag = false;
                Monitor.Pulse(lockThis);
            }
            return cell;
        }

    }

    public class CellProd
    {
        public int max { get; set; }
        public Cell cell { get; set; }

        public CellProd(Cell cell, int max)
        {
            this.cell = cell;
            this.max = max;
        }

        public void produce()
        {
            for (int i = 1; i <= max; i++)
            {                
                Thread.Sleep(100);
                cell.WriteToCell(i);
            }
        }
    }

    public class CellCons
    {
        public int max { get; set; }
        public Cell cell { get; set; }

        public CellCons(Cell cell, int max)
        {
            this.max = max;
            this.cell = cell;
        }

        public void consume()
        {
            for (int i = 0; i < max; i++)
            {
                cell.ReadFromCell();
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Cell cell = new Cell();
            CellCons consumer = new CellCons(cell, 20);
            CellProd producer = new CellProd(cell, 20);

            Thread Tcons = new Thread(new ThreadStart(consumer.consume));
            Thread Tprod = new Thread(new ThreadStart(producer.produce));
            try
            {
                Tcons.Start();
                Tprod.Start();

                Tprod.Join();
                Tcons.Join();
            }
            catch (ThreadStateException ex)
            {
                Console.WriteLine("ThreadStartEx in Main: " + ex.Message);
            }
            Console.ReadLine();
        }
    }
}
