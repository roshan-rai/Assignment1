namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Game fizzBuzz = new Game();
            
            fizzBuzz.RunFizzBuzz();
            fizzBuzz.GuessNumber();
            fizzBuzz.starsDiamond();
            fizzBuzz.birthday(new DateOnly (2000, 2,16));
            fizzBuzz.greeting();
            fizzBuzz.print24();
            int[] numbers = new int[] {1,2,3,4,5,6,7,8,9,10 };
            Console.WriteLine("old numbers = "+string.Join(",", numbers));
            int[] newNumbers  = fizzBuzz.arrayCopy(numbers);
            Console.WriteLine("new numbers = " + string.Join(",", newNumbers));

            //list<string>
            
            List<string> toDoList = new List<string>();
            Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
            string userInput = Console.ReadLine();
            while (userInput == "+" || userInput=="-" || userInput=="--"){

                if (userInput == "+")
                {
                    Console.WriteLine("What do you want to add ?");
                    string add = Console.ReadLine();
                    List<string> stringList = fizzBuzz.AddToDoList(toDoList, add);
                    Console.WriteLine(string.Join(",", stringList));
                }
                else if (userInput == "-")
                {
                    Console.WriteLine("What do you want to remove ?");
                    string remove = Console.ReadLine();
                    List<string> stringList = fizzBuzz.RemoveToDoList(toDoList, remove);
                    Console.WriteLine(string.Join(",", stringList));

                }
                else if (userInput == "--")
                {
                    fizzBuzz.ClearToDoList(toDoList);
                    Console.WriteLine("Cleared");
                }

                else { Console.WriteLine("OUT"); }
                Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
                 userInput = Console.ReadLine();
            }

            int[] primeArray = Game.FindPrimesInRange(1,10);
            Console.WriteLine("The array of prime number is " + string.Join(",", primeArray));

            int[] numbers1 = new int[] { 1, 2, 3, 4 };
            int[] sumArray = Game.RotationArray(numbers1,2);
            Console.WriteLine(string.Join(",",sumArray));

            Console.WriteLine("Enter numbers in form of 2 3 4 5 8");
            string userGivenValue = Console.ReadLine();
            int[] arrayToCheckSequence = Game.StringToArray(userGivenValue);
            int[] array = fizzBuzz.Sequence(arrayToCheckSequence);
            Console.WriteLine(string.Join(",",array));

            fizzBuzz.countNumbers(arrayToCheckSequence);

            fizzBuzz.ReverseString("string");

            bool a = Game.IsPalindrome("ABBA");
            Console.WriteLine( a);
            string[] returnPalindrome = fizzBuzz.GetPalindrome("Hi,exe? ABBA! Hog fully a string: ExE. Bob");
            var apple = string.Join(" ", returnPalindrome);
            Console.WriteLine(apple);

            fizzBuzz.DissectNetwork("https://www.apple.com/iphone");
            fizzBuzz.ReverseSentenceWords("C# is not C++, and PHP is not Delphi!");



        }
    }
}
