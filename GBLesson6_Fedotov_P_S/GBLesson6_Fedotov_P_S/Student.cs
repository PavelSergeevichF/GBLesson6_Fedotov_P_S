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
        // Создаем конструктор
        public Student
            (
            string firstName,   //0
            string lastName,    //1
            string university,  //2
            string faculty,     //3
            string department,  //4
            int course,         //5
            int age,            //6
            int group,          //7
            string city         //8
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
        }

    }
}
