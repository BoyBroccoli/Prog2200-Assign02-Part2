using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign02_Part2
{
    public delegate void BalanceEventHandler(decimal theValue);


    class Program
    {
        static void Main(string[] args)
        {
            PiggyBank pb = new PiggyBank();
            BalanceLogger bl = new BalanceLogger();
            BalanceWatcher bw = new BalanceWatcher();

            // Triggering the balacedChanged event listener. 
            // That means this event is ready to implpement balanceLog method &
            // belanceWatch method once it is called from the setter of the m_bankBalance

            pb.balanceChanged += bl.balanceLog; // By implementing the balanceLog method
            pb.balanceChanged += bw.balanceWatch; // By implementing the balanceWatch method

            // Adding Anonymous delegate to the PiggyBank instance
            pb.negBalanceChanged += delegate(object sender, BalanceArgs balanceArgs)
            {
                if (balanceArgs.balance < 0)
                {
                    Console.WriteLine("You've dropped below zero. Your balance is ${0}\n", pb.theBalance);
                }
            };

            string theStr;
            do
            {
                Console.WriteLine("How much to deposit?");

                theStr = Console.ReadLine();
                decimal newVal;

                if (!theStr.Equals("exit"))
                {
                    //decimal newVal = decimal.Parse(theStr);

                    //pb.theBalance += newVal;

                    if (!decimal.TryParse(theStr, out newVal))
                    {
                        Console.WriteLine("This is not a number!\n");
                        Console.WriteLine("Enter another numerical number greater than 0!\n");

                        theStr = Console.ReadLine();
                    }

                    pb.theBalance += newVal;
                }
                
                


            } while (!theStr.Equals("exit"));
            Console.WriteLine("Your current balance after those transactions is: ${0}", pb.theBalance);
            Console.ReadLine();

        }
    }
}
