namespace Assignment
{
    public class AssignmentConfig
    {
        /// <summary>
        /// Name of the assignment.
        /// </summary>  
        public const string AssignmentName = "Assignment 06 (Midterm 1)";

        /// <summary>
        /// Description of the assignment.
        /// </summary>
        public const string AssignmentDescription = "Midterm Exam 1 for GI262 Data Structure and Algorithm";

        public const string AssignmentResourceID = "bu.2025.sem-1.gi262.as06";

        /// <summary>
        /// Version of the assignment.
        /// </summary>  
        public const string AssignmentVersion = "1.0.0";

        /// <summary>
        /// List of files containing assignment test cases. These files' contents are used to calculate the assignment checksum during submission.
        /// Add any additional configuration settings here ...
        /// </summary> 
        public static string[] AssignmentTestcaseFiles = new string[]
        {
            "Assets/Scripts/Workspace/Assignment/Assignment_Testcase.cs"
        };

        /// <summary>
        /// Checksum for the combined all assignment testcase files. This is used to verify the integrity of the assignment files.
        /// for preventing tampering or accidental changes of the assignment files.
        /// </summary>
        public const string AssignmentTestcaseFilesChecksum = "d41d8cd98f00b204e9800998ecf8427e";

        public const string ApiBaseUrl = "https://grading-system-bu.happygocoding.com";
    }
}
