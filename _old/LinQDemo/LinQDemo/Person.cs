using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinQDemo
{
    public enum Gender {
        MAN,
        WOMAN
    }

    public class Person
    {
        private string name;
        private int age;
        private Gender gender;

        public string Name
        {
            get { return this.name; }
        }

        public int Age {
            get { return this.age; }
        }

        public Gender Gender
        {
            get { return this.gender; }
        }

        public Person(string name, int age, Gender gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public override string ToString()
        {
            return this.Name + " " + this.Age + " " + this.Gender;
        }

    }
}
