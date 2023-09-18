using System;
using Xceed.Words.NET;

public class WordDocumentEditor
{
    
    public static void EditResume(string role, string[] keywords)
    {
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
                "Leadership & Team Management",
                "Web Development & Back-End Development",
                "Integrating Distributed Systems & Rest APIs",
                "Developing User-Facing Front-End Websites",
                "Scaling Applications & Managing High-User Loads",
                "Agile Project Management & Agile Frameworks",
                "Software Development & Issue Troubleshooting",
                "SQL Database Design & Query Formation",
                "Leading Developments from Concept to Completion",
                "Software Development Lifecycle (SDLC)",
                "Excellent Verbal & Written Communication",
                "Overhauling Front-End Applications",
                "Data Structures & Efficient Design",
                "Technical Education & Problem Solving"
            };

            for (int i = 0; i < 14 - keywords.Length; i++)
            {
                document.ReplaceText("[Keyword" + (i + keywords.Length +  1) + "]", defaultSkills[i]);
            }

            // Replace other placeholders as needed (e.g., [JobTitle], [Comments])
            document.ReplaceText("[Role]", role);

            // Save the edited resume
            document.SaveAs("edited_resume.docx");
        }
    }

    public static void EditCoverLetter(string role, string jobTitle, string company)
    {
        // Load the cover letter template
        using (DocX document = DocX.Load("word templates/cover_letter_template.docx"))
        {
            // Find and replace placeholders with user-inputted data
            document.ReplaceText("[Role]", role);
            document.ReplaceText("[JobTitle]", jobTitle);
            document.ReplaceText("[Company]", company);

            
            // Save the edited cover letter
            document.SaveAs("edited_cover_letter.docx");
        }
    }
}
