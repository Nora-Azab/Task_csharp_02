using System;
using System.Collections;
using System.Collections.Generic;

class NumberMenu
{
    static List<int> numbers = new List<int>();
    //menu ──────────────────────────────
    static void PrintMenu()
    {
        Console.WriteLine("=============================");
        Console.WriteLine("         Main Menu           ");
        Console.WriteLine("=============================");
        Console.WriteLine(" P - Print numbers");
        Console.WriteLine(" A - Add a number");
        Console.WriteLine(" M - Display mean of the numbers");
        Console.WriteLine(" S - Display the smallest number");
        Console.WriteLine(" L - Display the largest number");
        Console.WriteLine(" F - Find a number");
        Console.WriteLine(" C - Clear the whole list");
        Console.WriteLine(" G - Add a group of numbers");
        Console.WriteLine(" Q - Quit");
        Console.WriteLine("=============================");
        Console.Write("Enter your choice: ");
    }

    //print all numbers 
    static void PrintNumbers()
    {
        if (numbers.Count == 0)
        {
            Console.WriteLine("\n[] - The list is empty \n");
            return;
        }

        Console.WriteLine("\n--- Numbers in the list : ---");
        Console.Write("\n[");
        for (int i = 0; i < numbers.Count; i++)
        {
            if (i == numbers.Count - 1)//last one
                Console.Write(numbers[i]);
            else
                Console.Write($"{numbers[i]} ");

        }
        Console.Write("]\n");

        
    }

    //add a number 
    static void AddNumber()
    {
        while (true)
        {
            Console.Write("\nEnter a number to add (or 'q' to go back): ");
            string input = Console.ReadLine();

            
            //if (input != null && input.Trim().ToLower() == "q")
            if (input.Trim().ToLower() == "q")
            {
                Console.WriteLine("Cancelled.\n");
                return;
                // return => i will end the function , and go back to the while of display the menu
                // but break => i will leave the "while only .. and still inside the fun of AddNumber so "wrong solution"
            }

            if (int.TryParse(input, out int num))
            {
                numbers.Add(num);
                Console.WriteLine($"    {num} added     \n");
                return;
            }
            else
            {
                Console.WriteLine("  ** Invalid input. Please enter a numeric value only. **");
            }
        }
    }

    //mean
    static void DisplayMean()
    {
        if (numbers.Count == 0)
        {
            Console.WriteLine("\nEnable to calculate the mean  -  no data\n");
            return;
        }

        int sum = 0;
        for (int i = 0; i < numbers.Count; i++)
            sum += numbers[i];

        int mean = sum / numbers.Count;
        Console.WriteLine($"\n  Mean: {mean}\n");
    }

    //smallest number 
    static void DisplaySmallest()
    {
        if (numbers.Count == 0)
        {
            Console.WriteLine("\nunable to determine the smallest number  -  list is empty\n");
            return;
        }

        int smallest = numbers[0];
        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] < smallest)
                smallest = numbers[i];
        }

        Console.WriteLine($"\nthe smallest number is {smallest}\n");
    }

    //largest number 
    static void DisplayLargest()
    {
        if (numbers.Count == 0)
        {
            Console.WriteLine("\nunable to determine the largest number  -  list is empty\n");
            return;
        }

        int largest = numbers[0];
        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] > largest)
                largest = numbers[i];
        }

        Console.WriteLine($"\nthe largest number is {largest}\n");
    }

    //find a number 
    static void FindNumber()
    {
        while (true)
        {
            Console.Write("\nEnter the number to search for (or 'q' to go back): ");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "q")
            {
                Console.WriteLine("Cancelled.\n");
                return;
            }

            if (int.TryParse(input, out int target))
            {
                bool found = false;
                int index;
                for (index = 0; index < numbers.Count; index++)
                {
                    if (numbers[index] == target)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                    Console.WriteLine($"\n   Needed number in index {index}.\n");
                else
                    Console.WriteLine($"\n   Needed number not in the list!!\n");

                return;
            }
            else
            {
                Console.WriteLine("  ** Invalid input. Please enter a numeric value only. **");
            }
        }
    }

    // ── g : add group of integers 
    static void AddGroup()
    {
        Console.WriteLine("\nEnter numbers separated by spaces like : 5 12 7 3");
        Console.Write("or 'q' to go back: ");
        string input = Console.ReadLine();

        
        if (input != null && input.Trim().ToLower() == "q")
        {
            Console.WriteLine("Cancelled.\n");
            return;
        }

        if (input == null || input.Trim() == "")
        {
            Console.WriteLine("  ** No input entered. **\n");
            return;
        }

        string[] parts = input.Trim().Split(' ');

        int addedCount = 0;
        int failedCount = 0;

        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i] == "")
                continue;  // skip extra spaces

            if (int.TryParse(parts[i], out int num))
            {
                numbers.Add(num);
                addedCount++;
            }
            else
            {
                Console.WriteLine($"  ** '{parts[i]}' is not a valid number — skipped. **");
                failedCount++;
            }
        }

        Console.WriteLine($"\n  {addedCount} numbers added, {failedCount} skipped \n");
    }


    // ── C : Clear the list 
    static void ClearList()
    {
        numbers.Clear();
        Console.WriteLine("\n    list clear successed   \n");
    }

    static void Main(string[] args)
    {
        char choice = ' ';

        while (choice != 'q')
        {
            PrintMenu();
            string input = Console.ReadLine();

            
            if (input == null || input.Length != 1)
            {
                Console.WriteLine("\n** Invalid option. Please choose from the menu only. **\n");
                continue;
            }

            choice = char.ToLower(input[0]);//input[0] => because input "string" and choice "char"

            switch (choice)
            {
                case 'p': 
                    PrintNumbers();
                    break;
                case 'a':
                    AddNumber(); 
                    break;
                case 'm':
                    DisplayMean();
                    break;
                case 's':
                    DisplaySmallest(); 
                    break;
                case 'l': 
                    DisplayLargest(); 
                    break;
                case 'f': 
                    FindNumber(); 
                    break;
                case 'c': 
                    ClearList(); 
                    break;
                case 'g':
                    AddGroup();
                    break;
                case 'q': 
                    Console.WriteLine("\nGoodbye"); 
                    break;
                default:
                    Console.WriteLine("\n** Invalid option. Please choose from the menu only. **\n");
                    break;
            }
        }
    }

    
}