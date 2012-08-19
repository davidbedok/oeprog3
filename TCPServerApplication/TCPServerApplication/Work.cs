using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace TCPServerApplication
{
    public class Work
    {
        public static readonly int MAXITEM = 20;
        private static readonly int MAXNUMBER = 9999;

        private WorkItem[] items;

        public WorkItem[] Items
        {
            get { return this.items; }
        }

        private Random rand;

        public Work(Random rand)
        {
            this.rand = rand;
            this.items = new WorkItem[Work.MAXITEM];
            for (int i = 0; i < Work.MAXITEM; i++)
            {
                this.items[i] = new WorkItem(this.rand.Next(Work.MAXNUMBER));
            }
        }

        private bool hasCreatedCount(){
            bool find = false;
            int i = 0;
            while ((i < Work.MAXITEM) && (!find))
            {
                if (WorkItemStatus.CREATED.Equals(this.items[i].Status))
                {
                    find = true;
                }
                i++;
            }
            return find;
        }

        public WorkItem GetRandomCreatedWorkItem()
        {
            WorkItem ret = null;
            if (this.hasCreatedCount())
            {
                int i = 0;
                do
                {
                    i = this.rand.Next(Work.MAXITEM);
                } while (!WorkItemStatus.CREATED.Equals(this.items[i].Status));
                ret = this.items[i];
            }
            return ret;
        }

        public WorkItem GetCreatedWorkItem(){
            WorkItem ret = null;
            bool find = false;
            int i = 0;
            while ((i < Work.MAXITEM) && (!find))
            {
                if (WorkItemStatus.CREATED.Equals(this.items[i].Status))
                {
                    find = true;
                    ret = this.items[i];
                }
                i++;
            }
            return ret;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder(200);
            str.Append("@@@@ Work actual state\n");
            for (int i = 0; i < Work.MAXITEM; i++)
            {
                str.Append(this.items[i]+"\n");
            }
            str.Append("@@@@@@@@@@@@@@@@@@@@@@@@@\n");
            return str.ToString();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Print(WorkItem[] items)
        {
            System.Console.SetCursorPosition(0, 0);
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("Work actual state"); 
            for (int i = 0; i < Work.MAXITEM; i++)
            {
                if (items[i].Status.Equals(WorkItemStatus.CREATED))
                {
                    System.Console.ForegroundColor = ConsoleColor.Gray;
                }
                if (items[i].Status.Equals(WorkItemStatus.PROGRESS))
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                }
                if (items[i].Status.Equals(WorkItemStatus.DONE))
                {
                    System.Console.ForegroundColor = ConsoleColor.Green;
                }
                System.Console.WriteLine(items[i]);
            }
        }


    }
}
