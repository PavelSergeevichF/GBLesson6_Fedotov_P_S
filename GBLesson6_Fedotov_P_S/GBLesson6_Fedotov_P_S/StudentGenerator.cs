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
                sex= SexGeneric(),//в статичискую переменную не принимает значение в текущем контексте
                name = nameGeneric(sex, listNM, listNW),//this.sex не проходит требует ссылку или статичискую переменную
                lastName = listLN[rnd.Next(0, listLN.Count)],
                age= AgeGeneric()
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
                str = listLN[rnd.Next(0, listLN.Count)]+"а";
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
    class StudentGenerator
    {
        string nameNotClearWorld, lastnameNotClearWorld;
        List<string> nameList = new List<string>();
        public List<string> nameMenList = new List<string>();
        public List<string> nameWomenList = new List<string>();
        List<string> lastnameList = new List<string>();
        List<string[]> student = new List<string[]>();
        string[] studentStr = new string[10];

        public StudentGenerator(string strName, string strLastName)
        {
            nameNotClearWorld = strName;
            lastnameNotClearWorld = strLastName;
            nameList = seporet(nameNotClearWorld);
            lastnameList = seporet(lastnameNotClearWorld);
            seporetOnSex();
            creatSudent();
        }
        #region clerString
        List<string> seporet(string str)
        {
            List<string> list = new List<string>();
            string[] s = str.Split(',');
            for (int i = 0; i < s.Length; i++)
            {
                string temp = "";
                foreach (char ch in s[i])
                {
                    if (ch >= 'А' && ch <= 'я') temp += ch;
                }
                s[i] = temp;
                list.Add(temp);
            }
            return list;
        }
        #endregion
        #region seporetOnSex
        void seporetOnSex()
        {
            foreach (string strName in nameList)
            {
                if (strName.Length > 1)
                {
                    if
                    (
                    strName[strName.Length - 1] == 'а' ||
                    strName[strName.Length - 1] == 'ь' ||
                    strName[strName.Length - 1] == 'и' ||
                    strName[strName.Length - 1] == 'я'
                    )
                    {
                        if
                            (
                            strName == "Илья" ||
                            strName == "Фома" ||
                            strName == "Добрыня" ||
                            strName == "Игорь" ||
                            strName == "Камиль" ||
                            strName == "Кузьма")//
                        { nameMenList.Add(strName); }
                        else
                        { nameWomenList.Add(strName); }
                    }
                    else
                    {
                        if
                            (
                            strName == "Алсу" ||
                            strName == "Владлен" ||
                            strName == "Нелли" ||
                            strName == "Шолпан")//
                        { nameWomenList.Add(strName); }
                        else
                        { nameMenList.Add(strName); }
                    }
                }
            }
        }
        #endregion
        #region creatPerson
        string[] creatPerson(string university, string faculty, int course, string department, int group)
        {
            string[] person = new string[10];
            person[0] =
            person[1] =
            person[2] = university;
            person[3] = faculty;
            person[4] = course.ToString();
            person[5] = department;
            person[6] = group.ToString();
            person[7] = "Москва";
            string[] personGetRendom = Generic.StudentGeneric(nameMenList, nameWomenList, lastnameList).ToString().Split(' ');
            person[9] = personGetRendom[3];
            person[8] = personGetRendom[2];
            return person;
        }
        #endregion
        #region creatSudent
        void creatSudent()
        {
            string academyName = "РГГУ";
            string[] facultys = { "ИЭУиП", "ИФиИ", "СФ", "ФИИ", "ИМ" };
            string[,] department =
            {
                {"КОР","КУ", "КМиР", "КЭТ", "КФиК" },
                {"КСИЛ","КАФ", "КИТиК", "КТиПП", "КРФ"  },
                {"УКиСТ","СМиНИТ", "ПК", "УКиСТ", "СМиНИТ"  },
                {"ВМИ","ТиИРиСИ", "ИК", "КХП", "ИЗИ"  },
                {"МЖ1","МЖ2", "МЖ3", "МЖ4", "МЖ5"  }
            };
            int facultysInt = 0;
            foreach (string faculty in facultys)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 1; j < 7; j++)//курсы
                    {
                        for (int gr = 1; gr < 4; gr++)
                            for (int st = 0; st < 8; st++)
                            {
                                student.Add
                                    (
                                    creatPerson(
                                        academyName,
                                        faculty,
                                        j,
                                        department[facultysInt, i],
                                        gr
                                        )
                                    );
                            }
                    }
                }
                facultysInt++;
            }
        }
        #endregion
        #region ShowStudent
        public void ShowStudent()
        { 
            foreach(string[] strStudent in student)
            {
                foreach(string str in strStudent)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine(";");
            }
        }
        #endregion
    }
}
