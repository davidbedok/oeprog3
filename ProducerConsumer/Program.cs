using System;
using System.Collections.Generic;
using System.Threading;

class Factory
{
    private const int MaxDelay = 500;

    private object queueLock = new object();
    private Queue<int> numbers = new Queue<int>();
    private Random rnd = new Random();

    public void Start()
    {
        new Thread(ProducerJob).Start();
        new Thread(ConsumerJob).Start();
    }

    private void ProducerJob()
    {
        Random rnd = new Random(1);
        while (true)
        {
            Produce();
            Thread.Sleep(rnd.Next(MaxDelay));
        }
    }

    private void ConsumerJob()
    {
        Random rnd = new Random(2);
        while (true)
        {
            Consume();
            Thread.Sleep(rnd.Next(MaxDelay));
        }
    }

    public void Produce()
    {
        lock (queueLock)
        {
            int workItem = rnd.Next(100, 200);
            numbers.Enqueue(workItem);
            Console.WriteLine("Producer #{0} produced work item #{1}\t\t\t\t\t\tQueue length: {2}", Thread.CurrentThread.GetHashCode(), workItem, numbers.Count);
            Monitor.Pulse(queueLock);
        }
    }

    public void Consume()
    {
        lock (queueLock)
        {
            if (numbers.Count == 0)
                Monitor.Wait(queueLock);
            int workItem = numbers.Dequeue();
            Console.WriteLine("\t\t\t\t\tConsumer #{0} consumed work item #{1}\tQueue length: {2}", Thread.CurrentThread.GetHashCode(), workItem, numbers.Count);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        new Factory().Start();
    }
}