using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GBLesson6_Fedotov_P_S
{
    class Program
    {
        static int MyDelegat(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
        {
            return String.Compare(st1.firstName, st2.firstName);          // Сравниваем две строки
        }
        static int DelegatForSortByAge(Student st1, Student st2)
        {
            return st1.age.CompareTo(st2.age);
        }

        static void Main(string[] args)
        {
            int bakalavr = 0;
            int magistr = 0;
            int student18_20 = 0;
            int[] studentOnCourse = new int[7];
            List<Student> list = new List<Student>();                             // Создаем список студентов
            List<string[]> listTest = new List<string[]>();


            DateTime dt = DateTime.Now;
            #region creatList
            ReadWriterStudents readWriterStudents = new ReadWriterStudents();
            StreamReader nameStreamReader = new StreamReader("names.txt");
            StreamReader lastnameStreamReader = new StreamReader("lastnames.txt");
            StreamWriter sw = new StreamWriter("students_6.csv");
            GBLesson6_Fedotov_P_S.StudentGenerator GS = new StudentGenerator
                (
                readWriterStudents.ReadFile(nameStreamReader),
                readWriterStudents.ReadFile(lastnameStreamReader)
                );
            nameStreamReader.Close();
            lastnameStreamReader.Close();
            sw.Write(readWriterStudents.WriterInString(GS.students));
            sw.Close();
            #endregion

            StreamReader sr = new StreamReader("students_6.csv");
            Console.WriteLine("Список студентов. Для продолжения нажмите ввод.");
            Console.ReadLine();
            while (!sr.EndOfStream)//
            {
                try
                {
                    string temp = sr.ReadLine();
                    string[] s = temp.Split(';');
                    Console.WriteLine(temp);
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student
                        (
                        s[0], s[1], s[2], s[3], s[4], 
                        int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), 
                        s[8])
                        );
                    // Одновременно подсчитываем количество бакалавров и магистров
                    if (int.Parse(s[5]) < 5) bakalavr++; else magistr++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();

            //Подсчитать количество студентов учащихся на 5 и 6 курсах;
            string student18_20Cours = "";
            foreach (var v in list)
            {
                if (v.age > 17 && v.age < 21)
                {
                    studentOnCourse[v.course-1]++;
                    student18_20++;
                }
            }
            int tmp = 0;
            foreach (var SOC in studentOnCourse)
            {
                tmp++;
                if (SOC > 0)
                {
                    student18_20Cours += " " + tmp + ", ";
                }
            }
            Console.WriteLine("\nДанные. Для продолжения нажмите ввод.");
            Console.ReadLine();
            //отсортировать список по возрасту студента;
            list.Sort(new Comparison<Student>(DelegatForSortByAge));
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров: {0}", magistr);
            Console.WriteLine("Бакалавров: {0}", bakalavr);
            Console.WriteLine("Студентов учащихся на 4-5 курсе: {0}", magistr);
            Console.WriteLine("Студентов в возросте от 18 до 20: {0}", student18_20);
            Console.WriteLine("Студенты в возросте от 18 до 20 учатся на: {0} курсах.", student18_20Cours);
            Console.WriteLine("\nСписок студентов отсортированный по возросту. Для продолжения нажмите ввод.");
            Console.ReadLine();
            foreach (var v in list) Console.WriteLine(v.firstName+" "+v.age);
            Console.WriteLine(DateTime.Now - dt);
            Console.WriteLine("\n Для выхода нажмите ввод.");
            Console.ReadLine();
        }
    }
}
