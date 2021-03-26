using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1                                              // Баг заметки : Обработать корректный ввод для даты рождения (выполнено)
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int action=99;
            int countid=0;
            
            List<Note> data = new List<Note>();
            string vvod;
            
        
            
            while (action!=0)
            {
                PrintDefaultInfo();
                vvod = Console.ReadLine();
                if (vvod != null && vvod != "")
                {

                action =Convert.ToInt32(vvod);
                switch(action)
                {
                    case 1:
                        data.Add(new Note());
                        countid++;
                        break;
                    case 2:
                            Console.WriteLine("Введите ID записи для редактирования");
                            int idr = Convert.ToInt32(Console.ReadLine());
                            data[idr] = new Note(idr);
                            break;
                    case 3:
                          Console.WriteLine("Ведите ID удаляемой записи");
                            int id = Convert.ToInt32(Console.ReadLine());
                            data[id]=null;
                            Console.WriteLine();
                            Console.WriteLine("Запись успешно удалена \n");
                        break;
                    case 4:
                            Console.WriteLine();
                        for (int i=0; i < countid; i++)
                        {
                                if (data[i]!=null)
                            Console.WriteLine(data[i]);
                        }
                        break;

                    case 5:
                            Console.WriteLine();
                        for (int i=0; i < countid; i++)
                        {
                                if (data[i]!=null)
                                {
                                    Console.WriteLine($"Фамилия-{data[i].Surname},имя-{data[i].Name},телефон-{data[i].Telephone} ");
                                }
                        }
                            Console.WriteLine();
                        break;
                    default:
                        PrintDefaultInfo();
                        break;
                }
                }
            }

            void PrintDefaultInfo()
            {
                Console.WriteLine("Список команд для программы:");
                Console.WriteLine("1-Создание новой записи");
                Console.WriteLine("2-Редактирование выбранной записи.");
                Console.WriteLine("3-Удаление созданной записи.");
                Console.WriteLine("4-Просмотр созданных записей");
                Console.WriteLine("5-Просмотр краткой информации.");
                Console.WriteLine("0-Выход из программы");
            }

        }
    }
    public class Note
    {
        public static DateTime datenull = new DateTime(0001, 1, 1, 0, 00, 00);
        public int id;
        public static int num=0;
        protected int year, month, day;
        int check = 1;
        /*
                private string surname;
                private string name;
                private string midddlename;
                private int telephone;
                private string country;
                private DateTime datebirth;
                private string organization;
                private string position;
                private string other;
        */
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string Telephone { get; set; }
        public string Organization { get; set; }
        public string Position { get; set; }
        public string Other { get; set; }
        public string Country { get; set; }
        public DateTime Datebirth { get; set; }

        public void SetInfo(int id)
        {
            this.id = id;
            do
            {
                Console.WriteLine("Введите фамилию");
                Surname = Console.ReadLine();
                if (Surname == null || Surname == "")
                    Console.WriteLine("Это поле обязательно для заполнения! Попробуйте ещё раз");
            } while (Surname == null || Surname == "");

            do
            {
                Console.WriteLine("Введите имя");
                Name = Console.ReadLine();
                if (Name == null || Name == "")
                    Console.WriteLine("Это поле обязательно для заполнения! Попробуйте ещё раз");
            } while (Name == null || Name == "");


            Console.WriteLine("Введите отчество (необязательно)");
            Middlename = Console.ReadLine();

            do
            {
                Console.WriteLine("Введите номер телефона");
                Telephone = (Console.ReadLine());
                if (Telephone == null||Telephone=="")
                    Console.WriteLine("Это поле обязательно для заполнения! Попробуйте ещё раз");
            } while (Telephone == null || Telephone == "");

            do
            {
                Console.WriteLine("Введите страну");
                Country = Console.ReadLine();
                if (Country == null || Country == "")
                    Console.WriteLine("Это поле обязательно для заполнения! Попробуйте ещё раз");
            } while (Country == null || Country == "");

            do
            {

                try
                {
                    check = 1;
                    Console.WriteLine("Введите дату рождения в следующем формате (год-месяц-день)(необязательно)");
                    string data = Console.ReadLine();
                    if (data != "" && data != null)
                    {
                        year = Convert.ToInt32(data);
                        month = Convert.ToInt32(Console.ReadLine());
                        day = Convert.ToInt32(Console.ReadLine());
                        Datebirth = new DateTime(year, month, day);
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("НЕВЕРНЫЙ ФОРМАТ\n");
                    check = 0;
                }
            } while (check == 0);


            Console.WriteLine("Введите организацию (необязательно)");
            string org = Console.ReadLine();
            if (org!=null&&org!="")
            {
                Organization = org;
            }
            Console.WriteLine("Введите должность (необязательно)");
            string pos = Console.ReadLine();
            if (pos != null && pos != "")
            {
                Position = pos;
            }
            Console.WriteLine("Введите прочие заметки (необязательно)");
            string otheri = Console.ReadLine();
            if (otheri != null && otheri != "")
            {
                Other = otheri;
            }
            Console.WriteLine("Запись успешно добавлена\n");
        }


        public Note()
        {
            SetInfo(num);
            num++;
            
        }
        public Note(int id)
        {
            SetInfo(id);
            

        }

        public override string ToString() // в конце добавить пропуск строки
        {

            string output = $"ID:{id}\nФамилия: {Surname}\nИмя: {Name}\n";
            if (Middlename != null)
                output += $"Отчество: {Middlename}\n";
            output += $"Номер телефона {Telephone}\nСтрана:{Country}\n";
            if ((Datebirth != null) && (Datebirth != datenull)) 
                output += $"Дата рождения:{Datebirth}\n";
            if (Organization != null)
                output += $"Организация:{Organization}\n";
            if (Position != null)
                output += $"Должность:{Position}\n";
            if (Other != null)
                output += $"Прочее:{Other}";
            output += "\n";

            return output;
        }

    }
}
