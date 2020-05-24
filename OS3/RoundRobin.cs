using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS3
{
    public class RoundRobin
    {

        static void FindWaitingTime(int[] processes, int n, int[] bt, int[] wt, int quantum)
        {
        
            int[] rem_bt = new int[n];

            for (int i = 0; i < n; i++)
                rem_bt[i] = bt[i];

            int t = 0; 

       
            while (true)
            {
                bool done = true;

       
                for (int i = 0; i < n; i++)
                {
                    if (rem_bt[i] > 0)
                    {
                        
                        done = false;

                        if (rem_bt[i] > quantum)
                        {
                         
                            t += quantum;

                        
                            rem_bt[i] -= quantum;
                        }
                        else
                        {

                    
                            t = t + rem_bt[i];

                     
                            wt[i] = t - bt[i];

                            rem_bt[i] = 0;
                        }
                    }
                }
 
                if (done == true)
                    break;
            }
        }


        static void FindTurnAroundTime(int[] processes, int n, int[] bt, int[] wt, int[] tat)
        {
            for (int i = 0; i < n; i++)
                tat[i] = bt[i] + wt[i];
        }

        public float[] FindAverageTime(int[] processes, int n, int[] bt, int quantum)
        {
            int[] wt = new int[n];
            int[] tat = new int[n];
            float[] results = new float[2];
            int total_wt = 0, total_tat = 0;

       
            FindWaitingTime(processes, n, bt, wt, quantum);

        
            FindTurnAroundTime(processes, n, bt, wt, tat);

            for (int i = 0; i < n; i++)
            {
                total_wt = total_wt + wt[i];
                total_tat = total_tat + tat[i];
            }

            results[0] = (float) total_wt / (float) n;
            results[1] = (float)total_tat / (float)n;

            return results;
        }
    }
}
