using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

public class Resume
{
    public string _name = "";
    public List<Job> _jobs = new List<Job>();

    public void DisplayJobs()
    {
        Console.WriteLine($"Name: {_name}\n");
        Console.WriteLine($"Jobs:");
        foreach (var job in _jobs)
        {
            job.Display();
        }
    }
}