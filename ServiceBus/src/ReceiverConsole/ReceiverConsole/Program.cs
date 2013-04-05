using System;
using System.Configuration;
using System.Threading;
using Microsoft.ServiceBus.Messaging;

namespace ReceiverConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            const string queueName = "workerqueue";
            var rand = new Random();

            var mSender = QueueClient.CreateFromConnectionString(connString, queueName);
            var mReceiver = QueueClient.CreateFromConnectionString(connString, queueName, ReceiveMode.PeekLock);

            mReceiver.OnMessage(m =>
                                    {
                                        Thread.Sleep(rand.Next(1000, 3000));
                                        Console.WriteLine("Received message {0}", m.GetBody<string>());
                                        m.Complete();
                                    }, 5);

            for (int i = 0; i < 10; i++)
            {
                string msg = string.Format("test{0}", i);
                Console.WriteLine("Sending {0}", msg);
                mSender.Send(new BrokeredMessage(msg));
            }
            Console.ReadLine();

        }
    }
}
