using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Numerics;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public class Game
    {
        public void RunFizzBuzz()
        {
            int max = 100;
            for (int i = 1; i <= max; i++)
            {
                bool shouldBeFizzBuzz = (i % 3 == 0 && i % 5 == 0); // Check if it qualifies as FizzBuzz

                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");

                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else { Console.WriteLine(i); }

                if (shouldBeFizzBuzz)
                {
                    Console.WriteLine($"Warning: {i} should be FizzBuzz but wasn't!");
                }
            }
        }
        public void GuessNumber()
        {
            int correctNumber = new Random().Next(0, 3);

            Console.WriteLine("Guess a number");
            int userInput = Convert.ToInt32(Console.ReadLine());

            while (userInput != correctNumber)
            {

                if (userInput < correctNumber)
                {
                    Console.WriteLine("The number you input is lower, give something higher.");
                }
                else if (userInput > correctNumber)
                {
                    Console.WriteLine("The number you input is higher, give something lower.");
                }
                Console.WriteLine("Guess a number");
                userInput = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine($"Congratulations! You guessed the correct number {correctNumber}");
        }

        public void starsDiamond()
        {

            int max = 5;
            for (int i = 1; i <= max; ++i)
            {
                //spaces print
                for (int j = 0; j <= (max - i); j++)
                {
                    Console.Write(" ");
                }
                //stars
                for (int j = 0; j < (2 * i) - 1; ++j)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public void birthday(DateOnly date)
        {
            // Get today's date as a DateOnly
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            // Calculate the difference
            TimeSpan timeSpan = today.ToDateTime(TimeOnly.MinValue) - date.ToDateTime(TimeOnly.MinValue);
            // Get the total days lived
            int daysLived = timeSpan.Days;
            Console.WriteLine($"You have lived {daysLived} days.");

            int daysToNextAnniversary = 10000 - (daysLived % 10000);
            Console.WriteLine($"You will live 10k days in {daysToNextAnniversary} days");

        }

        public void greeting()
        {
            TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
            Console.WriteLine("Time is " + TimeOnly.FromDateTime(DateTime.Now));
            // Define time periods
            TimeOnly morningEnd = new TimeOnly(11, 59); // 11:59 AM
            TimeOnly afternoonEnd = new TimeOnly(5, 59); // 5:59 PM
            TimeOnly eveningEnd = new TimeOnly(8, 59); // 8:59 PM

            if (currentTime < morningEnd)
            {
                Console.WriteLine("Good Morning !!!");
            }
            else if (morningEnd > currentTime && currentTime < afternoonEnd)
            {
                Console.WriteLine("Good Afternoon !!!");
            }
            else if (afternoonEnd > currentTime && eveningEnd < afternoonEnd)
            {
                Console.WriteLine("Good Evening !!!");
            }
            else
            {
                Console.WriteLine("Good Night !!!");
            }
        }

        public void print24()
        {
             for (int i = 1; i <= 4; i++)
        {
            // Inner loop to count up to 24 with increments based on the outer loop
            for (int j = 0; j <= 24; j +=i)
            {
                // Print the current value with a comma, unless it's the last number
                if (j== 24)
                {
                    Console.Write(j);
                }
                else
                {
                    Console.Write(j + ",");
                }
            }
            // Move to the next line after finishing one sequence
            Console.WriteLine();
        }

        }

        //copy and paste the values from one array to the other and print
        public int[] arrayCopy(int[] numbers)
        {
            //int[] numbers = new int[10];
            //int[] numbers = { 1,2,3,4,5,6,7,8,9,10};
            int[] newArray = new int[numbers.Length];
            for (int i = 0; i < newArray.Length; ++i)
            {
                newArray[i] = numbers[i];
            }
            return newArray;
        }

        public List<string> AddToDoList(List<string> todos, string elementToAdd)
        {
            todos.Add(elementToAdd);
            return todos;
        }
        public List<string> RemoveToDoList(List<string> todos, string elementToRemove)
        {
            if (todos.Contains(elementToRemove))
            {
                todos.Remove(elementToRemove);
            }
            else { Console.WriteLine($"{elementToRemove} doesnt exist to remove."); }
            return todos;
        }
        public void ClearToDoList(List<string> todos)
        {
            todos.Clear();
        }

        public static int[] FindPrimesInRange(int startNum, int endNum)
        {
            int[] returningArray = new int[endNum];
            List<int> returningList = new List<int>();
            for (int i = startNum; i <= endNum; ++i)
            {
                bool check = IsPrime(i);
                if (check)
                {
                    returningList.Add(i);
                }
            }
            //Console.WriteLine(string.Join(",",returningList));

            return returningArray = returningList.ToArray();


        }
        public static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false; // Numbers <= 1 are not prime
            }

            if (number == 2)
            {
                return true; // 2 is the only even prime number
            }

            // Check divisors from 2 to √number
            for (int i = 2; i * i <= number; ++i)
            {
                if (number % i == 0)
                {
                    return false; // Found a divisor, number is not prime
                }
            }

            return true; // No divisors found, number is prime
        }

        public static int[] RotationArray(int[] rawArray, int rotationTime)
        {
            // (I + r) % n
            //i is the index of the element.
            //r is the current rotation.
            //n is the size of the array
            int arraySize = rawArray.Length;
            int[] sumArray = new int[arraySize];
            int[] newArray = new int[arraySize];

            for (int j = 1; j <= rotationTime; ++j)
            {
                for (int i = 0; i < rawArray.Length; ++i)
                {
                    int index = i;
                    //int currentRotation = rotationTime;
                    int finalIndexPlacing = (index + j) % arraySize;

                    newArray[finalIndexPlacing] = rawArray[i];
                }
                Console.WriteLine(string.Join(",", newArray));
                for (int s = 0; s < arraySize; ++s)
                {
                    sumArray[s] = newArray[s] + sumArray[s];
                }

            }
            return sumArray;



        }

        public static int[] StringToArray(string userInput)
        {
            //converting string into array
            string[] intSequence = userInput.Split(' ');
            int[] integerSequence = new int[intSequence.Length];
            for (int i = 0; i < intSequence.Length; ++i)
            {
                integerSequence[i] = Convert.ToInt32(intSequence[i]);
            }
            return integerSequence;
        }
        public int[] Sequence(int[] arrayInts)
        {

            int countA = 1;
            int countB = 1;
            int indexHighest = 0;
            for (int i = 0; i < arrayInts.Length - 1; ++i)
            {

                if (arrayInts[i] == arrayInts[i + 1])
                {
                    countA++;
                }
                else
                {
                    if (countA > countB)
                    {
                        countB = countA;
                        countA = 1;
                        indexHighest = i;
                    }
                }
            }
            if (countA > countB)
            {
                countB = countA;
                indexHighest = arrayInts.Length - 1;
            }
            int[] subArray = new int[countB];
            Array.Copy(arrayInts, indexHighest - countB + 1, subArray, 0, countB);
            return subArray;

        }

        public void countNumbers(int[] arrayInts)
        {
            List<int> integers = arrayInts.ToList();
            integers.Sort();

            int countA = 1;
            int countB = 1;
            int index = 0;

            for (int i = 0; i < integers.Count() - 1; ++i)
            {
                if (integers[i] == integers[i + 1])
                {
                    countA += 1;
                }
                else
                {
                    if (countA > countB)
                    {
                        countB = countA;//b is highest
                        index = i;
                    }
                }
            }
            if (countA > countB)
            {
                countB = countA;//b is highest
                index = integers.Count()-1;
            }
            Console.WriteLine($"{integers[index]} is the highest repeated number, repeated {countB} times. ");
        }

        public void ReverseString(string a)
        {
            string b = "";
            char[] charElements = a.ToCharArray();

            for (int i = charElements.Length - 1; i >= 0; --i)
            {
                b += charElements[i];
            }
            Console.WriteLine(b);
        }

        public static bool IsPalindrome(string checkWord)
        {
            bool isPalindrome = false;
            char[] a = checkWord.ToLower().ToCharArray();
            for (int i = 0; i < a.Length / 2; ++i)
            {
                if (a[i] != a[a.Length - 1 - i])
                {
                    isPalindrome = false;
                    return false;
                }
            }
            return true;
        }
        public string[] GetPalindrome(string sentence)
        {
            sentence = sentence.Replace('!', ' ').Replace(',', ' ').Replace(':', ' ').Replace('?', ' ').Replace('.', ' ');
            string[] words = sentence.Split(" ");
            List<string> palindromeWords = new List<string>();
            for (int i = 0; i < words.Length; ++i)
            {
                if (IsPalindrome(words[i].Trim()))
                {
                    palindromeWords.Add(words[i].Trim());
                }
            }
            string[] palindromeConfirmedWords = palindromeWords.ToArray();
            return palindromeConfirmedWords;
        }

        public string[] DissectNetwork(string url)
        { //[protocol]://[server]/[resource]
            //https://www.apple.com/iphone
            string[] ashley = url.Replace(':', ' ').Split('/');
            string[] protocols = new string[ashley.Length];
            for (int i = 0; i < ashley.Length; ++i)
            {
                if (ashley[i] != "")
                {
                    protocols[i] = ashley[i].Trim();
                }
            }

            Console.WriteLine(string.Join(" ", ashley));
            Console.WriteLine($"[protocol]= \"{protocols[0]}\"");
            Console.WriteLine($"[server]= \"{protocols[2]}\"");
            Console.WriteLine($"[resource]= \"{protocols[3]}\"");
            return protocols;
        

        }

        public string ReverseSentenceWords(string rawSentence)
        {
            // Define separators
            string separators = @"[.,:;=\(\)&\[\]""'\\/!? ]";


            // Split the sentence into words and separators
            string[] words = Regex.Split(rawSentence, separators);
            string[] separatorsArray = Regex.Matches(rawSentence, separators).Select(m => m.Value).ToArray();

            // Reverse the words while keeping separators intact
            string[] reversedWords = words.Where(word => !string.IsNullOrEmpty(word)).Reverse().ToArray();

            // Rebuild the sentence
            string result = "";
            int wordIndex = 0;
            for (int i = 0; i < separatorsArray.Length; i++)
            {
                if (wordIndex < reversedWords.Length)
                {
                    result += reversedWords[wordIndex++];
                }
                result += separatorsArray[i];
            }

            // Handle remaining words (if any)
            if (wordIndex < reversedWords.Length)
            {
                result += reversedWords[wordIndex++];
            }
            Console.WriteLine(result);
            return result;
            
        }




    }
}
