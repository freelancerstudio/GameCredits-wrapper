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
            IBaseBtcConnector baseBtcConnector = new BaseBtcConnector(true); // Use Primary Wallet
            Console.Write("Connecting to Gamerscoin daemon: " + ConfigurationManager.AppSettings["ServerIp"] + "...");
            Double networkDifficulty = baseBtcConnector.GetDifficulty();
            Console.WriteLine("OK\n\nBTC Network Difficulty: " + networkDifficulty.ToString("#,#", CultureInfo.InvariantCulture));
            Decimal myBalance = baseBtcConnector.GetBalance();
            Console.WriteLine("My balance: " + myBalance + " BTC");
            Console.ReadLine();
        }
    }
}
