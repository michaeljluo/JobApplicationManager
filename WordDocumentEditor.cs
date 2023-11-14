using Xceed.Words.NET;


public class WordDocumentEditor
{
    
    public static void EditResume(string jobTitle, string[] keywords, string company)
    {
        // Create a folder for the company if it doesn't exist
        string companyFolder = Path.Combine("C:/Users/mjl82/Desktop/RESUME APPS/CUSTOMIZED/", company);
        Directory.CreateDirectory(companyFolder);

        // Define the file paths for the edited resume and cover letter
        string jobFolder = Path.Combine(companyFolder, jobTitle);
        Directory.CreateDirectory(jobFolder);

        string editedResumePath = Path.Combine(companyFolder, jobTitle);
        editedResumePath = Path.Combine(editedResumePath, "Michael_Luo_resume.docx");

        


        // Load the modified resume template with placeholders for all 14 skills
        using (DocX document = DocX.Load("word templates/resume_template.docx"))
        {

            if (keywords.Length == 0 || keywords[0] == "" ){
                keywords = new string[0];
            }

            // Place user-entered keywords at the top of the list
            for (int i = 0; i < keywords.Length; i++)
            {
                document.ReplaceText("[Keyword" + (i + 1) + "]", keywords[i]);
            }

            // Add default values for the remaining skills to maintain a total of 14 skills.
            string[] defaultSkills = new string[]
            {
                "Full-Stack Web Development",
                "Microservices & RESTful APIs",
                "Object Oriented Programming with Java",
                "Front-end Development with HTML & CSS ",
                "Problem Solving & Issue Troubleshooting",
                "Excellent Communication and Leadership",

                "Agile Sprints and Code Reviews",
                "Driving Projects from Idea to Completion",
                "Database Integration and Data ETL",
                "Deployment with Kubernetes",
                "Event Driven Architecture with Kafka",
                "Data Structures & Efficient Design"
                
            };

            for (int i = 0; i < 12 - keywords.Length; i++)
            {
                document.ReplaceText("[Keyword" + (i + keywords.Length +  1) + "]", defaultSkills[i]);
            }

            // document.ReplaceText("[Role]", role);
            // document.ReplaceText("[JobTitle]", jobTitle);

            
            // Save the edited resume
            document.SaveAs(editedResumePath);

        }
    }

    public static void EditCoverLetter(string role, string jobTitle, string company)
    {

        // Create a folder for the company if it doesn't exist
        string companyFolder = Path.Combine("C:/Users/mjl82/Desktop/RESUME APPS/CUSTOMIZED/", company);
        Directory.CreateDirectory(companyFolder);

        // Define the file paths for the edited resume and cover letter
        string jobFolder = Path.Combine(companyFolder, jobTitle);
        Directory.CreateDirectory(jobFolder);

        string editedResumePath = Path.Combine(companyFolder, jobTitle);
        editedResumePath = Path.Combine(editedResumePath, "Michael J Luo Cover Letter.docx");

        // Load the cover letter template
        using (DocX document = DocX.Load("word templates/cover_letter_template.docx"))
        {
            // Find and replace placeholders with user-inputted data
            document.ReplaceText("[Role]", role);
            document.ReplaceText("[JobTitle]", jobTitle);
            document.ReplaceText("[Company]", company);

            
            // Save the edited cover letter
            document.SaveAs(editedResumePath);
        }
    }


}
