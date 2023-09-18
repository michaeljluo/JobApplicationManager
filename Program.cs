using System;

namespace JobApplicationManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Job Application Manager!");

            while (true)
            {
                Console.Write("Enter the job title (enter 'q' to quit): ");
                string jobTitle = Console.ReadLine();

                if (jobTitle.ToLower() == "q")
                {
                    Console.WriteLine("Thank you for using Job Application Manager!");
                    break;
                }

                Console.Write("Enter your declared role (often same as job title): ");
                string role = Console.ReadLine();

                Console.Write("Enter the company: ");
                string company = Console.ReadLine();

                Console.Write("Enter keywords (separate with commas): ");
                string keywordsInput = Console.ReadLine();

                // Split the input into individ ual keywords, trim extra spaces
                string[] keywords = keywordsInput.Split(',')
                    .Select(keyword => keyword.Trim())
                    .ToArray();


                // TO-DO: allow for empty value
                Console.Write("Enter special comments: ");
                string comments = Console.ReadLine();

                // Edit the resume and cover letters using the provided data
                WordDocumentEditor.EditResume(role, keywords);
                WordDocumentEditor.EditCoverLetter(role, jobTitle, company);

                // Now, you can continue with Excel and PDF operations and folder management as needed.
                // For now, let's just print a message indicating success.
                Console.WriteLine("Resume and cover letter have been edited and saved.");

                // Optionally, you can loop to process more job applications or exit.
            }
        }
    }
}
