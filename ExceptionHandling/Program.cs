﻿namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicExceptionHandling();
            MultipleExceptionTypes();
            FinalyBlockUsage();
            CustomExceptionClass();
            ExceptionPropagation();
            UsingThrowAndCatch();
        }

        static void BasicExceptionHandling()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Convert the input to an integer using int.Parse().
            // Use a try-catch block to handle FormatException if the user enters a non-numeric value.
            // Display an error message in case of an exception.
            // Output the input if correct
            int number;
            try
            {
                string userInput = Console.ReadLine();
                number = int.Parse(userInput);
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException) 
            {
                Console.WriteLine("You have entered non-numeric letters");
            }
        }

        static void MultipleExceptionTypes()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Include a catch block for OverflowException to handle cases where the number is too large or small for an int.
            // Display appropriate error messages for different exceptions.

            try
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("You have entered non-numeric letters");
            }
            catch (OverflowException e) 
            { 
                Console.WriteLine(e.ToString());
            }
        }

        static void FinalyBlockUsage()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Add a finally block to the program.
            // Use the finally block to display a message whether an exception was caught or not.
            bool exceptionCaught = false;
            try
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException f)
            {
                Console.WriteLine(f.ToString());
                exceptionCaught = true;
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.ToString());
                exceptionCaught = true;
            }
            finally
            {
                if (exceptionCaught)
                {
                    Console.WriteLine("An exception was caught");
                }
                else
                {
                    Console.WriteLine("No exception was caught");
                }

            }
        }

        // Class for custom exception type
        class NegativeNumberException : ApplicationException
        {
            public NegativeNumberException(string message) : base(message) { }
        }

        static void CustomExceptionClass()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Modify your number input program to throw NegativeNumberException if the user enters a negative number.
            // Handle this exception in a separate catch block and display an appropriate message.

            string userInput;
            try
            {
                userInput = Console.ReadLine();
                int number = int.Parse(userInput);
                Console.WriteLine($"You have entered {number}");

                if (number < 0)
                {
                    throw new NegativeNumberException("Error: you cannot enter a negative number");
                }
            }
            catch (FormatException f)
            {
                Console.WriteLine(f.ToString());
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (NegativeNumberException ne)
            {
                Console.WriteLine(ne.ToString());
            }
        }

        static void ExceptionPropagation()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Write a function CheckNumber that takes an integer and throws ArgumentOutOfRangeException if the number is greater than 100.
            // In this function, call CheckNumber inside a try block and handle the exception.

            string userInput;
            try
            {
                userInput = Console.ReadLine();
                int number = int.Parse(userInput);
                CheckNumber(number);
                Console.WriteLine($"You have entered {number}");
            }
            catch (FormatException f)
            {
                Console.WriteLine(f.ToString());
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (ArgumentOutOfRangeException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }

        // NOTE: You can implement the CheckNumber here
        public static void CheckNumber (int number) {
            if (number > 100)
            {
                throw new ArgumentOutOfRangeException("Error: the input is greater than 100");
            }
        }

        static void UsingThrowAndCatch()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Write a function CheckNumberWithLogging that takes an integer and throws ArgumentOutOfRangeException if the number is greater than 100.
            // Modify the CheckNumberWithLogging function to log the exception message before throwing it.
            // In this function, catch the exception in the main program and display the logged message.

            string userInput;
            try
            {
                userInput = Console.ReadLine();
                int number = int.Parse(userInput);
                CheckNumberWithLogging(number);
                Console.WriteLine($"You have entered {number}");
            }
            catch (FormatException f)
            {
                Console.WriteLine(f.ToString());
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception f)
            {
                Console.WriteLine("Caught exception:" + f.Message);
            }

        }

        // NOTE: You can implement the CheckNumberWithLogging here

        public static void CheckNumberWithLogging(int number)
        {
            try
            {
                if (number > 100)
                {
                    throw new ArgumentOutOfRangeException("Error: the input is greater than 100");
                }

            }
            catch (Exception f)
            {
                Console.WriteLine("Error:" + f.Message);
                throw;
            }
        }
    }
}