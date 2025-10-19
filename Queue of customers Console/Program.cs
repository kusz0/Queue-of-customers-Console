using System.Linq;
using System.Runtime.CompilerServices;

namespace Queue_of_customers_Console
{
    internal class Program
    {
        static Queue<string> shopQueue = new Queue<string>();
        static private string client = "|";
        static void Main(string[] args)
        {
            Shop();
        
        }
        public static void Shop()
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.WriteLine("=======WELCOME TO MY SHOP======");
                ShowQueue();
                Console.WriteLine("1.Add new client to queue | 2.Checkout Client | 3. Close App");
                Console.Write("Choose option: ");
                string input = Console.ReadLine();
                int goodNum;
                if(!int.TryParse(input, out goodNum))
                {
                    Console.WriteLine("Invalid Number! try again");
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }
                Dictionary<int, Action> operations = new Dictionary<int, Action>()
                {
                    {1, () => ShopQueue(shopQueue) },
                    {2,() =>Checkout(shopQueue) },
                    {3, () => isRunning = false }
                };
                if (operations.ContainsKey(goodNum))
                {
                    operations[goodNum].Invoke();
                }else
                {
                    Console.WriteLine("There is no option like that. Try again!!!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                

            }
        }
        public static void ShowQueue()
        {
            Console.WriteLine("[] <- Checkout");
            foreach(var client in shopQueue)
            {
                Console.Write(client);
            }
            Console.WriteLine();
        }
        public static void ShopQueue(Queue<string> queue)
        {
            queue.Enqueue(client);
            Console.WriteLine("New Client join to Queue");

        }
        public static void Checkout(Queue<string> queue)
        {
            if (queue.Count <= 0) 
            {
                Console.WriteLine("There is no queue (Wait 2 sec)" );
                Thread.Sleep(2000);
                return;
            }
            queue.Dequeue();
            Console.WriteLine("Client has checked out");
        }
    }
}
