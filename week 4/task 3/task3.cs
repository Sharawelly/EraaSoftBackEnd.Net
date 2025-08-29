namespace task_3
{
    internal class Program
    {
        public class DuplicateNumberException
        {
            public List<int> NumberList = new List<int>();


            public bool CheckIfNumberExists(int number) {
              return NumberList.Contains(number);
            }

            public void AddNumber(int number)
            { 
                if(CheckIfNumberExists(number))
                {
                    throw new Exception("Number already exists in the list.");
                }

                NumberList.Add(number);
            }
        }


        static public void NoVowellsExceptions(string input)
        {
            string vowels = "aeiouAEIOU";
            foreach (char c in input)
            {
                if (vowels.Contains(c))
                {
                  return;
                }
            }
            throw new Exception("Input doesn't contain vowels.");
        }

        static void Main(string[] args)
        {
            // Program code one (DuplicateNumberException)
            try
            {
                DuplicateNumberException duplicateNumberException = new DuplicateNumberException();
                duplicateNumberException.AddNumber(5);
                duplicateNumberException.AddNumber(10);
                duplicateNumberException.AddNumber(5); // This will throw an exception
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The error message is: {ex.Message}");
            }
            Console.WriteLine("Hello, World1!");


            // Program code two (string does not contain vowels)
            try
            {
                NoVowellsExceptions("Hello");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The error message is: {ex.Message}");
            }

            Console.WriteLine("Hello, World2!");

        }
    }
}
