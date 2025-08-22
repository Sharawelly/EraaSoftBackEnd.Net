namespace task3part1
{


    internal class Program
    {
        private static List<int> listOfNumber = new List<int>();
        private static bool exit = false;


        public static void PrintMenu()
        {
            Console.WriteLine("P - Print numbers");
            Console.WriteLine("A - Add a number");
            Console.WriteLine("M - Display mean of the numbers");
            Console.WriteLine("S - Display the smallest number");
            Console.WriteLine("L - Display the largest number");
            Console.WriteLine("F - Find a number");
            Console.WriteLine("C - Clear the whole list");
            Console.WriteLine("Q - Quit");
        }


        public static char GetInput()
        {
            Console.Write("Choose an option: ");
            return Convert.ToChar(Console.ReadLine().ToLower());
        }


        public static void PrintNumbers()
        {
            if (listOfNumber.Count > 0)
            {
                Console.Write("[ ");
                foreach (var num in listOfNumber)
                    Console.Write($"{num} ");
                Console.WriteLine("]");
            }
            else
            {
                Console.WriteLine("[] - the list is empty");
            }
        }


        public static void AddNumber()
        {
            Console.Write("Enter the number to add: ");
            int input = Convert.ToInt32(Console.ReadLine());
            listOfNumber.Add(input);
            Console.WriteLine($"{input} added");
        }


        public static void DisplayMean()
        {
            if (listOfNumber.Count > 0)
            {
                int sum = 0;
                foreach (var num in listOfNumber)
                    sum += num;
                Console.WriteLine($"Mean is: {sum / (double)listOfNumber.Count}");
            }
            else
            {
                Console.WriteLine("[] - the list is empty");
            }
        }


        public static void DisplaySmallest()
        {
            if (listOfNumber.Count > 0)
            {
                int small = int.MaxValue;
                foreach (var num in listOfNumber)
                    if (num < small) small = num;
                Console.WriteLine($"The smallest number is: {small}");
            }
            else
            {
                Console.WriteLine("[] - the list is empty");
            }
        }


        public static void DisplayLargest()
        {
            if (listOfNumber.Count > 0)
            {
                int large = int.MinValue;
                foreach (var num in listOfNumber)
                    if (num > large) large = num;
                Console.WriteLine($"The largest number is: {large}");
            }
            else
            {
                Console.WriteLine("[] - the list is empty");
            }
        }


        public static void FindNumber()
        {
            Console.Write("Enter the number to search: ");
            int searchNumber = Convert.ToInt32(Console.ReadLine());
            int index = listOfNumber.IndexOf(searchNumber);

            if (index != -1)
                Console.WriteLine($"Number found at index: {index}");
            else
                Console.WriteLine("Number not in the list!");
        }


        public static void ClearList()
        {
            listOfNumber.Clear();
            Console.WriteLine("List cleared successfully");
        }

        static void Main(string[] args)
        {
            while (!exit)
            {
                PrintMenu();
                char currentChar = GetInput();

                switch (currentChar)
                {
                    case 'p': PrintNumbers(); break;
                    case 'a': AddNumber(); break;
                    case 'm': DisplayMean(); break;
                    case 's': DisplaySmallest(); break;
                    case 'l': DisplayLargest(); break;
                    case 'f': FindNumber(); break;
                    case 'c': ClearList(); break;
                    case 'q': exit = true; break;
                    default: Console.WriteLine("Invalid option! Please try again"); break;
                }

                Console.WriteLine();
            }
        }
    }

}
