using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GBLesson6_Fedotov_P_S
{
    class ReadWriterStudents
    {
        //StreamWriter sw = new StreamWriter("students_6.csv");
        public string ReadFile(StreamReader stream)
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
            foreach (string str in listStr)
            {
                s += str;
            }
            return s;
        }
        public string WriterInString(List<string[]> student)
        {
            string temp="";
            foreach (string[] strs in student)
            {
                foreach(string str in strs)
                {
                    temp+=str + ";";
                }
                temp += "\n";
            }
            return temp;
        }

    }
}
