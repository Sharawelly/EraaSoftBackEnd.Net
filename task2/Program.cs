List<int> listOfNumber = new List<int>();

bool exit = false;
while (!exit)
{
    Console.Out.WriteLine("P - Print numbers");
    Console.Out.WriteLine("A - Add a number");
    Console.Out.WriteLine("M - Display mean of the numbers");
    Console.Out.WriteLine("S - Display the smallest number");
    Console.Out.WriteLine("L - Display the largest number");
    Console.Out.WriteLine("F - Find a number");
    Console.Out.WriteLine("C - Clear the whole list");
    Console.Out.WriteLine("Q - Quit");
    char currentChar = Convert.ToChar(Console.ReadLine().ToLower());

    switch (currentChar)
    {
        case 'p':
            int listSize = listOfNumber.Count;
            if (listSize > 0)
            {
                Console.Write("[ ");
                for (int i = 0; i < listSize; i++)
                {
                    Console.Out.Write($"{listOfNumber[i]} ");
                }
                Console.Write("]");
            }
            else
            {
                Console.Out.WriteLine("[] - the list is empty");
            }

            break;
        case 'a':
            Console.Out.Write("Enter the number to add: ==> ");
            int input = Convert.ToInt32(Console.ReadLine());
            listOfNumber.Add(input);
            Console.Out.WriteLine($"{input} added");
            break;

        case 'm':
            int mean = 0;
            for (int i = 0; i < listOfNumber.Count; i++)
            {
                mean += listOfNumber[i];
            }
            Console.Out.WriteLine($"Mean is: {mean / listOfNumber.Count}");
            break;



        case 's':
            int small = int.MaxValue;
            for (int i = 0; i < listOfNumber.Count; i++)
            {
                small = listOfNumber[i] > small ? small : listOfNumber[i];
            }
            Console.WriteLine(listOfNumber.Count != 0 ? $"The smallest number is: {small}" : "[] - the list is empty");
            break;

        case 'l':
            int large = int.MinValue;
            for (int i = 0; i < listOfNumber.Count; i++)
            {
                large = listOfNumber[i] < large ? large : listOfNumber[i];
            }
            Console.WriteLine(listOfNumber.Count != 0 ? $"The largest number is: {large}" : "[] - the list is empty");
            break;



        case 'f':
            Console.Write("Enter the number to search: ==> ");
            int searchNumber = Convert.ToInt32(Console.ReadLine());
            bool isNumberExist = false;
            for (int i = 0; i < listOfNumber.Count; i++)
            {
                if (searchNumber == listOfNumber[i])
                {
                    Console.WriteLine($"Needed number in index: {i}");
                    isNumberExist = true;
                    break;
                }
            }
            if (!isNumberExist)
            {
                Console.WriteLine("Needed number not int the list!!!");
            }
            break;

        case 'c':
            listOfNumber.Clear();
            Console.WriteLine("List clear successfully");
            break;


        case 'q':
            exit = true;
            break;



    }
    Console.WriteLine();

}



