using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 1995;
        job1._endYear = 1999;

        Job job2 = new Job();
        job2._jobTitle = "IT Manager";
        job2._company = "Apple";
        job2._startYear = 1999;
        job2._endYear = 2016;


        Resume resume1 = new Resume();
        resume1._name = "Jason Bourne";

        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        resume1.DisplayJobs();
    }
}