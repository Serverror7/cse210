using System;
using System.Reflection;


class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        
        job1._jobTitle = "White-hat Hacker";
        job1._company = "ACME CO.";
        job1._startYear = 2005;
        job1._endYear = 2021;

        Job job2 = new Job();

        job2._jobTitle = "Electical Engineer";
        job2._company = "Department of Energy";
        job2._startYear = 2009;
        job2._endYear = 2011;

        Resume myResume = new Resume();

        myResume._name = "Joesph Smith";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}

