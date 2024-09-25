using System;
using static System.Console;

namespace Program
{
    class MainApp
    {
        abstract class Worker
        {
            protected string Name;
            protected DateTime JoinDay;

            public Worker(string name, DateTime joinDay)
            {
                Name = name;
                JoinDay = joinDay;
            }

            public abstract void CalSalary();
        }
        class RegularWorker : Worker
        {
            public RegularWorker(string name, DateTime joinDay) : base(name, joinDay) { }
            public override void CalSalary()
            {
                WriteLine("3달라!!");
            }
        }
        class PartTimeWorker : Worker
        {
            int workingHour;
            public PartTimeWorker(string name, DateTime joinDay, int workingHour) : base(name, joinDay)
            {
                this.workingHour = workingHour;
            }
            public override void CalSalary()
            {
                WriteLine(workingHour * 0.3);
            }
        }

        //#3
        static void Main(string[] args)
        {
            RegularWorker Rworker = new RegularWorker("Kim", new DateTime(2000, 01, 01));
            PartTimeWorker Pworker = new PartTimeWorker("Lee", new DateTime(2000, 01, 01), 8);

            Rworker.CalSalary();
            Pworker.CalSalary();
        }
    }
}