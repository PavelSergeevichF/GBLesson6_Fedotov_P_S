using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBLesson6_Fedotov_P_S
{
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;
        public char sex;
        // Создаем конструктор
        public Student
            (
            string firstName, 
            string lastName, 
            string university, 
            string faculty, 
            string department, 
            int course, 
            int age, 
            int group, 
            string city,
            char sex
            )
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
            this.sex = sex;
        }

    }
}
