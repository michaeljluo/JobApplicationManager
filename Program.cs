﻿using System;

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

                if(jobTitle == ""){
                    jobTitle = "Software Engineer";
                    Console.WriteLine("Job title defaulted to Software Engineer!");
                }
                if(jobTitle == "1"){
                    jobTitle = "Associate Software Engineer";
                    Console.WriteLine("Job title defaulted to Associate Software Engineer!");
                }

                // Console.Write("Enter your declared role (often same as job title): ");
                // string role = Console.ReadLine();

                // if(role == ""){
                //     role = jobTitle;
                //     Console.WriteLine("Role defaulted to " + jobTitle);
                // }
                // if(role == "1"){
                //     role = "Software Engineer";
                //     Console.WriteLine("Role defaulted to Software Engineer");
                // }


                Console.Write("Enter the company: ");
                string company = Console.ReadLine();

                if (Directory.Exists(Path.Combine("C:/Users/mjl82/Desktop/RESUME APPS/CUSTOMIZED/", company))){
                    Console.Write("Company already applied to BTW!\n");
                }

                Console.Write("Do you want to customize keywords? (Enter 1 for yes)");
                string customize = Console.ReadLine();
                if(customize == "1"){
                    Console.Write("Enter keywords (separate with commas): ");
                    string keywordsInput = Console.ReadLine();

                    // Split the input into individual keywords, trim extra spaces
                    string[] keywords = keywordsInput.Split(',')
                        .Select(keyword => keyword.Trim())
                        .ToArray();

                    // Edit the resume and cover letters using the provided data
                    WordDocumentEditor.EditResume(jobTitle, keywords, company);
                    // WordDocumentEditor.EditCoverLetter(role, jobTitle, company);

                    // Now, you can continue with Excel and PDF operations and folder management as needed.
                    // For now, let's just print a message indicating success.
                    Console.WriteLine("Resume has been edited and saved.");
                }


                // our priority is to get the resume and cover letter and then add any comments to excel
                Console.Write("Enter special comments: ");
                string comments = Console.ReadLine();

                ExcelManager.AddJobApplication(jobTitle, company, comments);

                Console.WriteLine("Successfully added job to spreadsheet!");

                // Optionally, you can loop to process more job applications or exit.
            }
        }
    }
}
