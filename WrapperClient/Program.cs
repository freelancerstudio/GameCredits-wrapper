using System;
using System.Configuration;
using System.Globalization;
using GamerscoinWrapper.Wrapper;
using GamerscoinWrapper.Wrapper.Interfaces;

namespace ConsoleClient
{
    internal sealed class Program
    {
        static void Main()
        {
            // Int Gamerscoin BaseConnector
            IBaseGamerscoinConnector baseGamerscoinConnector = new BaseGamerscoinConnector(true);
            Console.WriteLine("Connecting to Gamerscoin daemon: " + ConfigurationManager.AppSettings["PrimaryServerIp"]);
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            //Get Gamerscoin Global Network Info
            String infoGlobal = baseGamerscoinConnector.GetInfo();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Gamerscoin Global Network Info: ");
            Console.WriteLine(infoGlobal);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(" ");

            //Get Mining Difficulty
            Double networkDifficulty = baseGamerscoinConnector.GetDifficulty();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Network Difficulty: ");
            Console.WriteLine(networkDifficulty);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(" ");

            //Get Gamerscoin default Wallet Balance
            Decimal myBalance = baseGamerscoinConnector.GetBalance("");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("My default Gamerscoin Wallet balance: ");
            Console.WriteLine(myBalance + " GMC");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(" ");

            //Create a unique Gamerscoin address for User Bob
            String userBob = baseGamerscoinConnector.GetAccountAddress("Bob");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Gamerscoin Wallet Address for Bob is :");
            Console.WriteLine(userBob);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(" ");

            //Check Bob's Gamerscoin Wallet Balance
            Decimal bobBalance = baseGamerscoinConnector.GetBalance("Bob");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Bob's Gamerscoin Wallet balance: ");
            
            if (bobBalance > 1)
                Console.WriteLine(bobBalance + " GMC");
            else
                if (bobBalance <= 0)
                Console.WriteLine(bobBalance + " GMC");
                Console.WriteLine(" ");
                Console.WriteLine("Bob your deposit address is :");
                Console.WriteLine(userBob);
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(" ");


            //Create a unique Gamerscoin address for User Alice
            String userAlice = baseGamerscoinConnector.GetAccountAddress("Alice");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Gamerscoin Wallet Address for Alice is :");
            Console.WriteLine(userAlice);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(" ");

            //Bob + Alice = Love4ever(); Send to Address
            if (bobBalance > 1)
            {
                String sendToAlice = baseGamerscoinConnector.SendFrom("Bob",userAlice,1);
                Decimal aliceBalance = baseGamerscoinConnector.GetBalance("Alice");

                Console.WriteLine("Bob sends Alice 1 Gamerscoin");
                Console.WriteLine("Bob New Wallet Balance is : " + bobBalance + " GMC");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(" ");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Alice New Wallet Balance is : ");
                Console.WriteLine(aliceBalance + " GMC");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(" ");

            }
            else
            if (bobBalance <= 0)
            {
                Console.WriteLine("Bob Bob before you can send Gamerscoin you need to get some ......");
                Console.WriteLine("Bob your deposit address is :");
                Console.WriteLine(userBob);
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(" ");
            }

            //Bob + Alice = Love4ever(); Move from Account to Account
            if (bobBalance > 1)
            {
                String moveToAlice = baseGamerscoinConnector.Move("Bob","Alice", 1);
                Decimal aliceBalance = baseGamerscoinConnector.GetBalance("Alice");

                Console.WriteLine("Bob sends Alice 1 Gamerscoin");
                Console.WriteLine("Bob New Wallet Balance is : " + bobBalance + " GMC");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(" ");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Alice New Wallet Balance is : ");
                Console.WriteLine(aliceBalance + " GMC");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(" ");

            }
            else
                if (bobBalance <= 0)
                {
                    Console.WriteLine("Bob Bob before you can move Gamerscoin you need to get some ......");
                    Console.WriteLine("Bob your deposit address is :");
                    Console.WriteLine(userBob);
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine(" ");
                }

            //Read Line ;)
            Console.ReadLine();
        }
    }
}
