using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegratedQueryDemo
{
    public class Student
    {
        private readonly String name;
        private readonly String neptunCode;
        private readonly int enrollmentYear;
        private readonly List<String> certificates;
        private readonly List<Subject> subjects;

        public String Name
        {
            get { return this.name; }
        }

        public String NeptunCode
        {
            get { return this.neptunCode; }
        }

        public int EnrollmentYear
        {
            get { return this.enrollmentYear; }
        }

        public List<Subject> Subjects
        {
            get { return this.subjects; }
        }

        public Student(String name, String neptunCode, int enrollmentYear)
        {
            this.name = name;
            this.neptunCode = neptunCode;
            this.enrollmentYear = enrollmentYear;
            this.certificates = new List<String>();
            this.subjects = new List<Subject>();
        }

        public void addCertificate( String certificate )
        {
            this.certificates.Add(certificate);
        }

        public void addSubject( Subject subject )
        {
            this.subjects.Add(subject);
        }

        public bool hasCertificate(String certificate)
        {
            return this.certificates.Contains(certificate);
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder(50);
            info.AppendLine(this.name + " (neptunCode: " + this.neptunCode + ", enrollmentYear: " + this.enrollmentYear + ")");
            info.Append(" - Certificates: ");
            foreach( String certificate in this.certificates ) {
                info.Append(certificate).Append(" ");
            }
            info.AppendLine();
            info.AppendLine(" - Subjects: ");
            foreach (Subject subject in this.subjects)
            {
                info.AppendLine(subject.ToString());
            }
            return info.ToString();
        }

    }
}
