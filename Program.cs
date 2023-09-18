using System;

namespace JobApplicationManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Job Application Manager!");
            
            Console.Write("Enter the job title (enter 'q' to quit): ");
            
            string jobTitle = Console.ReadLine();

            if (jobTitle == "q")
            {
                // Exit the program
            }
            else
            {
                Console.Write("Enter the company: ");
                string company = Console.ReadLine();
                
                Console.Write("Enter three keywords: ");
                string keywords = Console.ReadLine();
                
                Console.Write("Enter special comments: ");
                string comments = Console.ReadLine();
                
                // TODO: Call Excel and PDF functions and manage the directory structure
            }


            Console.WriteLine("Thank you for using Job Application Manager!");
        }
    }
}
