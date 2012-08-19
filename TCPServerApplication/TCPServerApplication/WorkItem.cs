using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPServerApplication
{
    public class WorkItem : System.Object
    {
        private WorkItemStatus status;
        private int parameter;
        private string result;

        public WorkItemStatus Status
        {
            get
            {
                return this.status;
            }
        }

        public string Result
        {
            get
            {
                return this.result;
            }
            set
            {
                if (!"".Equals(value))
                {
                    this.result = value;
                    this.DoneWork();
                }
                else
                {
                    this.RestoredWork();
                }
            }
        }

        public int Parameter
        {
            get
            {
                return this.parameter;
            }
        }

        public WorkItem( int parameter )
        {
            this.status = WorkItemStatus.CREATED;
            this.parameter = parameter;
        }

        public void DoWork()
        {
            this.status = WorkItemStatus.PROGRESS;
        }

        private void RestoredWork()
        {
            this.status = WorkItemStatus.CREATED;
        }

        private void DoneWork()
        {
            this.status = WorkItemStatus.DONE;
        }

        public override string ToString()
        {
            string str = null;
            switch (this.status)
            {
                case WorkItemStatus.CREATED:
                    str = "CREATED (" + this.parameter + ")";
                    break;
                case WorkItemStatus.PROGRESS:
                    str = "PROGRESS (" + this.parameter + ")";
                    break;
                case WorkItemStatus.DONE:
                    str = "DONE (" + this.parameter + " = " + this.result + ")";
                    break;
            }
            return str;
        }

    }
}
