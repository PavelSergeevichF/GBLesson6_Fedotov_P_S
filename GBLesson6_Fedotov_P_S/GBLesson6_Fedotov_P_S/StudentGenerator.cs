using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GBLesson6_Fedotov_P_S
{
    class StudentGenerator
    {
        string nameNotClearWorld, lastnameNotClearWorld;
        List<string> nameList = new List<string>();
        public List<string> nameMenList = new List<string>();
        public List<string> nameWomenList = new List<string>();
        List<string> lastnameList = new List<string>();
        List<string[]> student = new List<string[]>();
        public List<string[]> students => student;
        string[] studentStr = new string[10];
        Generic Gen = new Generic();

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
            string[] personGetRendom = Gen.StudentGeneric(nameMenList, nameWomenList, lastnameList).ToString().Split(' ');
            person[0] = personGetRendom[0];
            person[1] = personGetRendom[1];
            person[2] = university;
            person[3] = faculty;
            person[4] = course.ToString();
            person[5] = department;
            person[6] = group.ToString();
            person[7] = "Москва";
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
