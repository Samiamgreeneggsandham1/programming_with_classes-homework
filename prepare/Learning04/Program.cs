using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment();
        assignment1.SetStudentName("Sammyljacksonboi");
        assignment1.SetTopic("Trigonometry");

        Console.WriteLine(assignment1.GetSummary());


        MathAssignment math1 = new MathAssignment();
        math1.SetStudentName("Sammyljacksonboi");
        math1.SetTopic("Trigonometry");
        math1.SetTextbookSection("Section 7.3");
        math1.SetProblems("Problems 1-11");

        Console.WriteLine(math1.GetHomeworkList());


        WritingAssignment writing1 = new WritingAssignment();
        writing1.SetStudentName("Sammyljacksonboi");
        writing1.SetTopic("European History");
        writing1.SetTitle("The Causes of World War II by Mary Waters");

        Console.WriteLine(writing1.GetWritingInformation());
    }
}