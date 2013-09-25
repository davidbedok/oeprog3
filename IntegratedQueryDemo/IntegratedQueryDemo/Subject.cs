using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegratedQueryDemo
{
    public class Subject
    {
        private readonly String name;
        private readonly Instructor instructor;
        private readonly int credits;

        public String Name
        {
            get { return this.name; }
        }

        public Instructor Instructor
        {
            get { return this.instructor; }
        }

        public int Credits
        {
            get { return this.credits; }
        }

        public Subject(String name, Instructor instructor, int credits)
        {
            this.name = name;
            this.instructor = instructor;
            this.credits = credits;
        }

        public override string ToString()
        {
            return "        " + this.name + " (instructor: " + instructor + ", credits: " + credits + ")";
        }

    }
}
