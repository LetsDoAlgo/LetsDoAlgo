using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetArray
{
    //   https://www.techiedelight.com/job-sequencing-problem-deadlines/
    //ime Complexity of the above solution is O(n2).
    public class Job :IComparable<Job>
    {
        public int Id { get; set; }     // Job Id 
        public int dead { get; set; }      // Deadline of job 
        public int profit { get; set; }   // Profit if job is over before or on deadline 
        public Job()
        {
                
        }
        public Job(char id, int deadline, int profit)
        {
            this.Id = id;
            this.dead = deadline;
            this.profit = profit;
        }
     
        public int CompareTo(Job other)
        {
            int returnVal;

            if (this.profit < other.profit)
                returnVal = 1;
            else
                if (this.profit > other.profit)
                returnVal = -1;
            else
                returnVal = 0;

            return returnVal;

        }
    };
    public class JobSequencingProblem
    {
      
        //greedy algo 
        //1. sort all jobs in decreasing order of profit
        //2. initialize the result sequence as first job in sorted jobs 
        //3. do the followin  for n-1 jobs 
        //if current job can fit in the current result sequence without missing the deadline ...add current job to the result else ignore the current job 

        public static void printJobScheduling(Job[] arr , int t)
        {
            //array , no of jobs to schedule 
            int n = arr.Length;
            //sort all jobs according to profit
            Array.Sort(arr);

            //array for storing the result           
            int[] Timeslot = new int[n];

            //profit calculation
            int profit = 0;
            //find the max deadline 
            var deadlineMax = arr.Max(x => x.dead);
            for (int i = 0; i < deadlineMax; i++)
            {
                Timeslot[i] = -1;
            }
          
           

            //iterate through all jobs 
            foreach (var item in arr)
            {
                for (int j = item.dead-1;j>=0 ;j--)
                {
                    if (Timeslot[j]==-1 && j<deadlineMax)
                    {
                        Timeslot[j] = item.Id;
                        profit += item.profit;
                        break;
                    }
                }
            }

            //print
            for (int i = 0; i <deadlineMax; i++)
            {
              
                if (Timeslot[i]!=-1)
                {
                    Console.WriteLine(Timeslot[i]+"-->");
                }
            }
        }
    }
}
