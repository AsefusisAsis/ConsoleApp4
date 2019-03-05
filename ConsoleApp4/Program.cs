using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace ConsoleApp4
{
    enum status
    {
        новый = 1, постоянный, выселяющийся
    }
    class person
    {
        public delegate void del(decimal b);
        public event del Izm2;
        
        public int ID;
        public string name;
        public string room;
        public string pasp;
        public decimal Sum;
        public status state;
        public person()//по умолчанию
        {
            ID = 1;
            name = "Steeve Rojers";
            room = "A1";
            Sum = 2000;
            state = (status)1;
            pasp = "AB1234567";
        }
        public person(int _id, string _name, string _room, string _pasp, status _status, decimal _Sum)//статический конструктор 
        {
            this.ID = _id;
            this.name = _name;
            this.room = _room;
            this.state = _status;
            this.pasp = _pasp;
            this.Sum = _Sum;
        }
        public person(person PrPerson)//конструктор копирования
        {
            this.ID = PrPerson.ID + 1;
            this.name = "Vanessa Rojers";
            this.room = PrPerson.room;
            this.state = PrPerson.state;
            this.pasp = "AF1122334";
            this.Sum = 2500;
        }
        public virtual void Izm(int a)
        {
            this.state = (status)a;
            if (Izm2 != null)
            {
                if (this.state == (status)2)
                {
                    Izm2(this.Sum = this.Sum - (this.Sum * (decimal)0.15));
                }
            }

        }

    }
    class Program
    {
        
        static void Main(string[] args)
        {
            
            
            

            Regex regex = new Regex(@"\w\w\b\b\b\b\b\b\b");
            Console.WriteLine("Меню вывода данных" + "\n" + "1.Вывести всех посетителей..." + "\n" + "2.Вывести высляющихся..." + "\n" + "3.Добавить посетителя..." + "\n" + "4.Статус жильцов по номеру комнаты..." + "\n" + "5.ФИО и номер комнаты по паспортным данным..."+ "\n" + "6.Изменить статус проживающего..." + "\n" + "7.Выход...");
            int count = 3;
            int VAL = 100;
            person[] Clients = new person[VAL];
            Clients[0] = new person();
            Clients[1] = new person(3, "Robert Radriges", "A212", "AB7654321", (status)2, 2500);
            Clients[2] = new person(Clients[0]);
            string pattern = @"[A-Z]{2}[0-9]{7}";
            int menu = 0;
            for (; ; )
            {
                try
                {
                    menu = Convert.ToInt32(Console.ReadLine());
                    if (menu <= 0)
                    {
                        throw new Exception("Переменная меню не должна быть отрицательна или ровна нулю...");
                    }


                    {
                        switch (menu)
                        {

                            case 1:
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("ВЫвод всех посетителей:");
                                    for (int i = 0; i < count; i++)
                                    {
                                        Console.WriteLine("ID клиента:" + Clients[i].ID + "\n"
                                                        + "ФИО клиента:" + Clients[i].name + "\n"
                                                        + "Номер комнаты:" + Clients[i].room + "\n"
                                                        + "Паспортные данные клиента:" + Clients[i].pasp + "\n"
                                                        + "Статус клиента:" + Clients[i].state + "\n"
                                                        + "Внесенная сумма:" + Clients[i].Sum);
                                        Console.WriteLine("***");
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Вывод всех выселяющихся:");
                                    Vis(Clients, count);
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("***Добавление посетителя***");
                                    {
                                        Console.Write("Введите ID клиента:");
                                        int ID = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Введите ФИО клиента:");
                                        string name = Console.ReadLine();
                                        Console.Write("Введите номер комнаты клиента:");
                                        string room = (Console.ReadLine());
                                        Console.Write("Введите паспортные данные клиента:");
                                        {
                                            string fpass = null;

                                            while (true)
                                            {
                                                string pass = Console.ReadLine();

                                                if (pass.Length > 9)
                                                    Console.WriteLine("Вы ввели неверное колличество символов...");
                                                else
                                                {
                                                    if (Regex.IsMatch(pass, pattern))
                                                    {
                                                        fpass = pass;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Некорректные паспортные данные, повторите попытку ввода...");
                                                    }
                                                }
                                            }
                                            Console.Write("Статус клиента(1-Новый,2-Постоянный,3-Выселяющийся)");
                                            status state = (status)Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Внесенная сумма:");
                                            decimal sum = Convert.ToDecimal(Console.ReadLine());
                                            Clients[count] = new person(ID, name, room, fpass, state, sum);
                                            fpass = null;
                                        }
                                        count += 1;
                                        break;
                                    }
                                }
                            case 4:
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Статус жильцов по номеру комнаты...");
                                    Console.Write("Введите номер комнаты:");
                                    string room = (Console.ReadLine());
                                    person person = new person(1, "name", room, "AA0000000", (status)3, 0);
                                    Rom(person.room, Clients, count);
                                    break;
                                }
                            case 5:
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Вывод ФИО и номера комнаты по паспортным данным...");
                                    Console.Write("Введите паспортные данные:");
                                    string str = "";
                                    while (true)
                                    {
                                        string pass = Console.ReadLine();
                                        if (pass.Length > 9)
                                            Console.WriteLine("Вы ввели неверное колличество символов...");
                                        else
                                        {
                                            if (Regex.IsMatch(pass, pattern))
                                            {
                                                str = pass;
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Некорректные паспортные данные, повторите попытку ввода...");
                                            }

                                        }
                                    }
                                    person person = new person(1, "name", "000", str, (status)3, 0);
                                    pass(str, Clients, count);

                                    break;
                                }
                            case 6:
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Изменение статуса и смена оплаты...");
                                    Console.Write("Введите паспортные данные:");
                                    string str = "";
                                    while (true)
                                    {
                                        string pass = Console.ReadLine();
                                        if (pass.Length > 9)
                                            Console.WriteLine("Вы ввели неверное колличество символов...");
                                        else
                                        {
                                            if (Regex.IsMatch(pass, pattern))
                                            {
                                                str = pass;
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Некорректные паспортные данные, повторите попытку ввода...");
                                            }

                                        }
                                    }
                                    // person person = new person(1, "name", "000", str, (status)3, 0);
                                    pass2(str, Clients, count);
                                    break;
                                }
                            case 7:

                                {
                                    Environment.Exit(0);
                                    break;
                                }
                            default:
                                {
                                    Console.Write("Введите номер пункта из списка сверху...");
                                    break;
                                }

                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine("Ошибка:" + ex.Message); }
            }
        }

        static void Vis(person[] people, int count)//ссылка на обьект не указывает на экземпляр обьекта
        {
            int count1 = 0;
            person person = new person(1, "name", "000", "AA0000000", status.выселяющийся, 0);
            for (int i = 0; i < count; i++)
            {

                if (people[i].state == person.state)
                {
                    count1 += 1;

                    Console.WriteLine("ID:" + people[i].ID + "\n" +
                                       "Фио:" + people[i].name + "\n" +
                                       "Номер комнаты:" + people[i].room + "\n" +
                                       "Паспортные данные:" + people[i].pasp + "\n" +
                                       "Статус:" + people[i].state + "\n" +
                                       "Внесенная сумма:" + people[i].Sum
                                       );
                }
            }
            if (count1 == 0)
                Console.WriteLine("Таких записей нет...");
            Console.WriteLine();
        }
        static public void Rom(string num, person[] people, int count)//ссылка на обьект не указывает на экземпляр обьекта
        {

            int count1 = 0;
            person person = new person(1, "name", num, "AA0000000", status.выселяющийся, 0);
            for (int i = 0; i < count; i++)
            {

                if ((string)people[i].room == person.room)
                {
                    count1 += 1;
                    Console.WriteLine("Статус жильцов комнаты №" + num);
                    Console.WriteLine("Статус:" + people[i].state);
                }
            }
            if (count1 == 0)
                Console.WriteLine("Таких записей нет...");
            Console.WriteLine();
        }
        static void pass(string str, person[] people, int count)//ссылка на обьект не указывает на экземпляр обьекта
        {
            person person = new person(1, "name", "000", str, status.выселяющийся, 0);
            int count1 = 0;
            for (int i = 0; i < count; i++)
            {
                if (people[i].pasp == person.pasp)
                {
                    count1 += 1;
                    Console.WriteLine("По паспортным данным...");
                    Console.WriteLine("Номер комнаты:" + people[i].room + "\n" + "ФИО:" + people[i].name);


                }
            }
            if (count1 == 0)
                Console.WriteLine("Таких записей нет...");
            Console.WriteLine();
        }
        static void pass2(string str, person[] people, int count)//ссылка на обьект не указывает на экземпляр обьекта
        {
            person person = new person(1, "name", "000", str, status.выселяющийся, 0);
            int count1 = 0;
            for (int i = 0; i < count; i++)
            {
                if (people[i].pasp == person.pasp)
                {
                    count1 += 1;
                    Console.WriteLine("По паспортным данным...");
                    Console.WriteLine("Номер комнаты:" + people[i].room + "\n" + "ФИО:" + people[i].name + "\n" + people[i].Sum + "\n" + people[i].state);
                    Console.WriteLine("Введите новый статус"+"\n"+"1-новый" + "\n" + "2-постоянный" + "\n" + "3-выселяющийся");
                    people[i].Izm2 += av;
                    int a = Convert.ToInt32(Console.ReadLine());
                    people[i].Izm(a);
                    Console.WriteLine("После смены статауса...");
                    Console.WriteLine("Номер комнаты:" + people[i].room + "\n" + "ФИО:" + people[i].name + "\n" + people[i].Sum + "\n" + people[i].state);

                }
            }
            if (count1 == 0)
                Console.WriteLine("Таких записей нет...");
            Console.WriteLine();
        }
        public static void av(decimal b)
        {

        }
    }
}

