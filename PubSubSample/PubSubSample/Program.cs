﻿
using PubSubSample.Managers;
using PubSubSample.Publishers;
using System;
using System.Text;
using System.Threading.Tasks;

namespace PubSubSample
{
    class Program
    {
        static void Main(string[] args)
        {

            var publisher = new Message("Suba");
            var manager = new PubSubManager(publisher);
            manager.Start();

            Console.WriteLine("What is your message?:");
            publisher.Data = Console.ReadLine();

            Console.Read();

        }

    }

}
