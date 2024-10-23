using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    internal class Practice
    {
        public class Meeting
        {
            public int Start;
            public int End;
            public Meeting(int start, int end)
            {
                this.Start = start;
                this.End = end;
            }
        }
        public static void ArrangeMeeting(List<Meeting> meetings)
        {
            meetings.Sort((m1,m2)=>m1.End.CompareTo(m2.End));
            int count = 0;
            int lastEndTime = 0;
            foreach(Meeting meeting in meetings)
            {
                if(meeting.Start > lastEndTime)
                {
                    count++;
                    lastEndTime = meeting.End;
                    Console.WriteLine("("+meeting.Start+"."+meeting.End+")");
                }
            }
            Console.WriteLine(count+"개의 회의가 배정");
        }
    }
}
