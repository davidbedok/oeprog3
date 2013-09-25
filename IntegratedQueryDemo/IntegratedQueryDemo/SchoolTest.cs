using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegratedQueryDemo
{
    public class SchoolTest
    {

        private readonly School school;

        public SchoolTest()
        {
            this.school = new School();
            init();
        }

        private void init()
        {
            school.addSubject("Mathematics", Instructor.Alice, 2);
            school.addSubject("Literature", Instructor.Bob, 3);
            school.addSubject("Physics", Instructor.Charlie, 2);
            school.addSubject("History", Instructor.Alice, 4);

            school.addStudent("Mason Gardiner", "MASGAR", 2012);
            school.addStudent("Leo Bradley", "LEOBRA", 2013);
            school.addStudent("Louie Crawford", "LOUCRA", 2012);
            school.addStudent("Tilly Richardson", "TILRIC", 2011);
            school.addStudent("Amelia Chamberlain", "AMECHA", 2008);
            school.addStudent("Mollie Mann", "MOLMAN", 2013);

            school.linkCertificate("MASGAR", "Excel");
            school.linkCertificate("MASGAR", "PHP");
            school.linkCertificate("LEOBRA", "PHP");
            school.linkCertificate("LOUCRA", "Word");
            school.linkCertificate("LOUCRA", "Excel");
            school.linkCertificate("LOUCRA", "PHP");
            school.linkCertificate("TILRIC", "Word");
            school.linkCertificate("TILRIC", "PHP");
            school.linkCertificate("MOLMAN", "Excel");
            school.linkCertificate("MOLMAN", "Word");

            school.linkSubject("MASGAR", "Mathematics");
            school.linkSubject("MASGAR", "Literature");
            school.linkSubject("LEOBRA", "Literature");
            school.linkSubject("LEOBRA", "Physics");
            school.linkSubject("LOUCRA", "Mathematics");
            school.linkSubject("LOUCRA", "History");
            school.linkSubject("LOUCRA", "Physics");
            school.linkSubject("TILRIC", "Literature");
            school.linkSubject("TILRIC", "Mathematics");
            school.linkSubject("TILRIC", "Physics");
            school.linkSubject("AMECHA", "Literature");
            school.linkSubject("AMECHA", "Mathematics");
            school.linkSubject("MOLMAN", "History");
        }

        public String listStudentWithCertificate(String certificate)
        {
            List<Student> students = school.listByCertificate(certificate);
            return "\n\n# List students with certificate (" + certificate + ")\n" + this.printStudents(students);
        }

        public String listStudentWithSubject(String subject)
        {
            List<Student> students = school.listBySubject(subject);
            return "\n\n# List students with subject (" + subject + ")\n" + this.printStudents(students);
        }

        public String listStudentWithInstructors(Instructor instructor)
        {
            List<Student> students = school.listByInstructor(instructor);
            return "\n\n# List students with instructors (" + instructor + ")\n" + this.printStudents(students);
        }

        public String listStudentWithMinimumCredits(int minimumCredits)
        {
            List<Student> students = school.listByMinimumCredits(minimumCredits);
            return "\n\n# List students with minimum credits (" + minimumCredits + ")\n" + this.printStudents(students);
        }

        private String printStudents(List<Student> students )
        {
            StringBuilder result = new StringBuilder(200);
            foreach (Student student in students)
            {
                result.AppendLine(student.ToString());
            }
            return result.ToString();
        }

        public override string ToString()
        {
            return this.school.ToString();
        }

    }
}
