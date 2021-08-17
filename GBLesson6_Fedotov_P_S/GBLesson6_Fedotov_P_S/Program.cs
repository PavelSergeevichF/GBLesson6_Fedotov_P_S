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
            int[] studentOnCourse = new int[6];
            List<Student> list = new List<Student>();                             // Создаем список студентов
            List<string[]> listTest = new List<string[]>();
            DateTime dt = DateTime.Now;
            StreamReader nameStreamReader = new StreamReader("names.txt");
            StreamReader lastnameStreamReader = new StreamReader("lastnames.txt");
            StreamReader sr = new StreamReader("students_6.csv");
            //StreamReader sr2 = new StreamReader("students_test.csv");
            //StreamWriter sw = new StreamWriter("C:\\Test.txt");
            GBLesson6_Fedotov_P_S.StudentGenerator GS = new StudentGenerator
                (
                WriteFile(nameStreamReader), 
                WriteFile(lastnameStreamReader)
                );
            nameStreamReader.Close();
            lastnameStreamReader.Close();

            GS.ShowStudent();

            string WriteFile(StreamReader stream)
            {
                List<string> listStr = new List<string>();
                string s = "Не принял строку!";
                while (!stream.EndOfStream)
                {
                    try
                    {
                        s = stream.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                        // Выход из Main
                        
                        if (Console.ReadKey().Key == ConsoleKey.Escape) return s;
                        
                    }
                    listStr.Add(s);
                }
                s = "";
                foreach(string str in listStr)
                {
                    s += str;
                }
                return s;
            }
            //sr2.Close();
            foreach (string[] stTemp in listTest)
            {
                foreach (string st in stTemp)
                {
                    Console.WriteLine(st);
                }
            }
            Console.ReadLine();
            //while (!sr.EndOfStream)//
            //{
            //    try
            //    {
            //        string[] s = sr.ReadLine().Split(';');
            //        // Добавляем в список новый экземпляр класса Student
            //        list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8], s[9]));
            //        // Одновременно подсчитываем количество бакалавров и магистров
            //        if (int.Parse(s[5]) < 5) bakalavr++; else magistr++;
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //        Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
            //        // Выход из Main
            //        if (Console.ReadKey().Key == ConsoleKey.Escape) return;
            //    }
            //}
            //sr.Close();
            ////Подсчитать количество студентов учащихся на 5 и 6 курсах;
            //string student18_20Cours = "";
            //foreach (var v in list)
            //{
            //    if (v.age > 17 && v.age < 21)
            //    {
            //        studentOnCourse[v.course]++;
            //        student18_20++; 
            //    }
            //}
            //int tmp = 0;
            //foreach (var SOC in studentOnCourse)
            //{
            //    tmp++;
            //    if (SOC>0)
            //    {
            //        student18_20Cours += " " + tmp + ", ";
            //    }
            //}
            ////отсортировать список по возрасту студента;
            //list.Sort(new Comparison<Student>(DelegatForSortByAge));
            //Console.WriteLine("Всего студентов:" + list.Count);
            //Console.WriteLine("Магистров: {0}", magistr);
            //Console.WriteLine("Бакалавров: {0}", bakalavr);
            //Console.WriteLine("Студентов учащихся на 4-5 курсе: {0}", magistr);
            //Console.WriteLine("Студентов в возросте от 18 до 20: {0}", student18_20);
            //Console.WriteLine("Студенты в возросте от 18 до 20 учатся на: {0} курсах.", student18_20Cours);
            //foreach (var v in list) Console.WriteLine(v.firstName);
            //Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();
        }
    }
}
