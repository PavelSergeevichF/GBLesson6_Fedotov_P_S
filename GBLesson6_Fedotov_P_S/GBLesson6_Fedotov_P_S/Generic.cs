using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBLesson6_Fedotov_P_S
{
    class Generic
    {
        public String name { get; set; }
        public String lastName { get; set; }
        public int age { get; set; }
        public char sex { get; set; }
        public override string ToString()
        {
            return $"{name} {lastName} {age} {sex}";
        }
        static Random rnd = new Random();
        public static Generic StudentGeneric(List<string> listNM, List<string> listNW, List<string> listLN)
        {
            return new Generic()
            {
                sex = SexGeneric(),//в статичискую переменную не принимает значение в текущем контексте
                name = nameGeneric(sex, listNM, listNW),//this.sex не проходит требует ссылку или статичискую переменную
                lastName = listLN[rnd.Next(0, listLN.Count)],
                age = AgeGeneric()
            };
        }
        static int AgeGeneric()
        {
            int tempChanceAge = rnd.Next(0, 100);
            int str = 0;
            if (tempChanceAge > 80) { str = rnd.Next(21, 40); }
            else { str = rnd.Next(18, 21); }
            return str;
        }
        static string nameGeneric(char sx, List<string> listNM, List<string> listNW)
        {
            string str;
            if (sx == 'm')
            {
                str = listNM[rnd.Next(0, listNM.Count)];
            }
            else
            {
                str = listNW[rnd.Next(0, listNW.Count)];
            }
            return str;
        }
        static string lastNameGeneric(char sx, List<string> listLN)
        {
            string str;
            if (sx == 'm')
            {
                str = listLN[rnd.Next(0, listLN.Count)];
            }
            else
            {
                str = listLN[rnd.Next(0, listLN.Count)] + "а";
            }
            return str;
        }
        static char SexGeneric()
        {
            char sex;
            if (rnd.Next(0, 100) > 50) { sex = 'm'; }
            else { sex = 'w'; }
            return sex;
        }
    }
}
