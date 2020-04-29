using System;

namespace GC_Lab8_GetToKnowYourClassmates
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] studentDossiers = { { "Kim", "Driscoll", "Detroit, MI", "Falafel" }, { "Kim", "Wexler", "Albuqueruqe, NM", "Takeout"}, { "Saul", "Goodman", "Albuquerque, NM", "Lobster" }, { "Tomás", "Calvo", "Bay City, MI", "Cheddar Bay Biscuits" }, { "Cary", "Grant", "Hollywood, CA", "Chicken Almondine" }, { "Tyler", "Van Eck", "Wyoming, MI", "Shrimp Scampi" }, { "Andy", "Balash", "Auburn, MI", "Turkey Drumsticks" }, { "Michael", "Jarema", "Bay City, MI", "Tater Tots" }, { "Evan", "Doorshorst", "Kansas City, MO", "Fish Tacos" }, { "Alvaro", "Romero-Gibu", "Lima, Peru", "Avocado Toast" }, { "Colby", "Roanhorse", "Rochester, MI", "Coffee" }, { "Sofía", "Ramirez-Hernandez", "Rochester, MI", "Hamburgers" }, { "Kimmy", "Snyder", "Zeeland, MI", "Risotto" }, { "Mychal", "Hilken", "Jackson, MI", "Ham" }, { "Paul", "Clarke", "St. Augustine, FL", "Lap Song Su Chi" }, { "Kelly", "Meyer", "Luddington, MI", "Fish and Chips" }, { "Laurie", "Reeves", "Grand Rapids, MI", "Saffron Steak" }, { "Diego", "Calvo", "Bay City, MI", "Bone Broth" }, { "Salma", "Hayek", "Mexico City, MX", "Bone Broth" }, { "Laura", "Dern", "Santa Clara, CA", "Anything Jell-O" } };

            Console.Write("Welcome to our C# class.");
            bool loop = true;
            while (loop)
            {
                int index = ValidateStudentNumber(studentDossiers);
                ValidateInfoSelection(index, studentDossiers);
                ValidateLoop("another student");
            }

            Console.WriteLine("Thanks!");
        }

        public static int ValidateStudentNumber(string[,] array)
        {
            int response = 0;
            bool validation = false;
            while (!validation)
            {
                try
                {
                    Console.WriteLine("Which student would you like to learn more about? Enter a number 1-20.");
                    response = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Student {response} is {array[response - 1, 0]} {array[response -1, 1]}.");
                }
                catch (FormatException e1)
                {
                    Console.WriteLine(e1.Message);
                }
                catch (ArithmeticException e2)
                {
                    Console.WriteLine(e2.Message);
                }
                catch (IndexOutOfRangeException e3)
                {
                    Console.WriteLine(e3.Message);
                }
                finally
                {
                    validation = true;
                }
            }
            return response - 1;
        }

        public static void ValidateInfoSelection(int index, string[,] array)
        {
            string infoType;
            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine($"What would you like to know about {array[index, 0]}? Enter \"hometown\" or \"favorite food\".");
                    infoType = Console.ReadLine().ToLower().Trim();
                    if (infoType == "hometown")
                    {
                        Console.WriteLine($"{array[index, 0]} is from {array[index, 2]}.");
                        loop = false;
                    }
                    else if (infoType == "favorite food")
                    {
                        Console.WriteLine($"{array[index, 0]}'s favorite food is {array[index, 3]}.");
                        loop = false;
                    } else
                    {
                        Console.WriteLine("Enter \"hometown\" or \"favorite food\".");
                    }
                }
                catch (FormatException e1)
                {
                    Console.WriteLine(e1.Message);
                }
                catch (IndexOutOfRangeException e2)
                {
                    Console.WriteLine(e2.Message);
                }
                finally
                {
                    loop = ValidateLoop(array[index, 0]);
                }
            }
        }

        public static bool ValidateLoop(string studentName)
        {
            bool valid = false;
            while (!valid)
            {
                try
                {
                    Console.WriteLine($"Would you like to know more about {studentName}? Enter \"yes\" or \"no\".");
                    string response = Console.ReadLine().ToLower().Trim();
                    if (response == "yes")
                    {
                        return true;
                    }
                    else if (response == "no")
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry.");
                    }
                }
                catch (FormatException e1)
                {
                    Console.WriteLine(e1.Message);
                }
            }
            return true;
        }
    }
}
