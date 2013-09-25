using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegratedQueryDemo
{
    public class School
    {

        private readonly List<Subject> subjects;
        private readonly List<Student> students;

        public School()
        {
            this.subjects = new List<Subject>();
            this.students = new List<Student>();
        }

        public void addSubject(String name, Instructor instructor, int credits)
        {
            this.subjects.Add(new Subject(name, instructor, credits));
        }

        public void addStudent(String name, String neptunCode, int enrollmentYear)
        {
            this.students.Add(new Student(name, neptunCode, enrollmentYear));
        }

        public void linkCertificate(String neptunCode, String certificate)
        {
            IEnumerable<Student> selectedStudents = this.students.Where(x => x.NeptunCode.Equals(neptunCode));
            foreach (Student student in selectedStudents)
            {
                student.addCertificate(certificate);
            }
        }

        public void linkSubject(String neptunCode, String subjectName)
        {
            IEnumerable<Subject> selectedSubjects = this.subjects.Where(x => x.Name.Equals(subjectName));
            //IEnumerable<Subject> selectedSubject = from s in this.subjects where s.Name.Equals(subjectName) select s;
            IEnumerable<Student> selectedStudents = this.students.Where(x => x.NeptunCode.Equals(neptunCode));
            foreach (Subject subject in selectedSubjects)
            {
                foreach (Student student in selectedStudents)
                {
                    student.addSubject(subject);
                }
            }
        }

        public List<String> list(int enrollmentYear)
        {
            // Anonymous type demo
            List<String> neptunCodes = new List<String>();
            var items = this.students.Where(x => x.EnrollmentYear == enrollmentYear).Select(x => new { StudentName = x.Name, StudentNeptun = x.NeptunCode });
            foreach ( var item in items ) {
                neptunCodes.Add(item.StudentName);
            }
            return neptunCodes;
        }

        public List<Student> listByCertificate(String certificate)
        {
            return this.students.Where(x => x.hasCertificate(certificate)).ToList();
        }

        public List<Student> listBySubject(String subjectName)
        {
            // Subject subject = this.subjects.Where(x => x.Name.Equals(subjectName)).First();
            // Subject subject = this.subjects.First(x => x.Name.Equals(subjectName));
            // return this.students.Where(x => x.Subjects.Contains(subject)).ToList();

            return this.students.Where(x => x.Subjects.Exists( y => y.Name.Equals(subjectName))).ToList();
        }

        public List<Student> listByNumberOfSubjects(int numberOfSubjects)
        {
            return this.students.Where(x => x.Subjects.Count == numberOfSubjects).ToList();
        }

        public List<Student> listByInstructor(Instructor instructor)
        {
            return this.students.Where (x => x.Subjects.Exists (y => y.Instructor == instructor) ).ToList();
        }

        public List<Student> listByMinimumCredits(int minimumCredits)
        {
            return this.students.Where(x => x.Subjects.Sum(y => y.Credits) >= minimumCredits).ToList();
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder(100);
            foreach ( Student student in this.students ) {
                info.Append(student);
            }
            return info.ToString();
        }


    }
}
