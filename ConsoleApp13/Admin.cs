using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using static ConsoleApp13.Employer;


namespace ConsoleApp13
{
    public class Admin
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public void admin_menu()
        {
            int select = 1;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t   ______     __                         __     ");
                Console.WriteLine("\t  /      \\   |  \\                       |  \\    ");
                Console.WriteLine("\t |  $$$$$$\\ _| $$_    ______    ______ _| $$_   ");
                Console.WriteLine("\t | $$___\\$$|   $$ \\  |      \\  /      \\   $$ \\  ");
                Console.WriteLine("\t  \\$$    \\  \\$$$$$$   \\$$$$$$\\|  $$$$$$\\$$$$$$  ");
                Console.WriteLine("\t  _\\$$$$$$\\  | $$ __ /      $$| $$   \\$$| $$ __ ");
                Console.WriteLine("\t |  \\__| $$  | $$|  \\  $$$$$$$| $$      | $$|  \\");
                Console.WriteLine("\t  \\$$    $$   \\$$  $$\\$$    $$| $$       \\$$  $$");
                Console.WriteLine("\t   \\$$$$$$     \\$$$$  \\$$$$$$$ \\$$        \\$$$$ ");
                Console.WriteLine("\t                                                  ");
                Console.WriteLine("\t                                                  ");
                Console.WriteLine("\t                                                  ");
                Console.ForegroundColor = ConsoleColor.White;

                if (select == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t[1] => Login");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\t\t[2] => Exit");
                }
                else if (select == 2)
                {
                    Console.WriteLine("\t\t[1] => Login");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\t[2] => Exit");
                    Console.ForegroundColor = ConsoleColor.White;

                }

                ConsoleKeyInfo info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.UpArrow)
                {
                    if (select == 1) select = 2;
                    else select--;
                }
                else if (info.Key == ConsoleKey.DownArrow)
                {
                    if (select == 2) select = 1;
                    else select++;
                }

                if (info.Key == ConsoleKey.Enter)
                {
                    if (select == 2)
                    {
                        Main_Menu menu = new Main_Menu();
                        menu.main_menu();
                    }
                    else if (select == 1)
                    {   
                        write_file();
                        Login();    
                        admin_menu2();
                    }
                }
            } while (true);
        }
        public void admin_menu2()
        {
            int select1 = 1;

            do
            {
                Console.Clear();
                if (select1 == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[1] => Show Vacancies");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[2] => Show Workers");
                    Console.WriteLine("[3] => Exit");
                }
                else if (select1 == 2)
                {
                    Console.WriteLine("[1] => Show Vacancies");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[2] => Show Workers");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[3] => Exit");
                }
                else if (select1 == 3)
                {
                    Console.WriteLine("[1] => Show Vacancies");
                    Console.WriteLine("[2] => Show Workers");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[3] => Exit");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                ConsoleKeyInfo info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.UpArrow)
                {
                    if (select1 == 1) select1 = 3;
                    else select1--;
                }
                else if (info.Key == ConsoleKey.DownArrow)
                {
                    if (select1 == 3) select1 = 1;
                    else select1++;
                }

                if (info.Key == ConsoleKey.Enter)
                {
                    if (select1 == 3)
                    {
                        break;
                    }
                    else if (select1 == 1)
                    {
                        SameCode same = new SameCode();
                        same.ActivVacancies(true);

                    }
                    else if (select1 == 2)
                    {
                        string filePath = "workers.json";

                        if (File.Exists(filePath))
                        {
                            string[] lines = File.ReadAllLines(filePath);

                            foreach (string line in lines)
                            {
                                Console.WriteLine(line);
                                Console.WriteLine();
                            }
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("File not found: " + filePath);
                        }
                    }
                }
            } while (true);
        }
        public void Login()
        {
            string adminFile = "admin_login.json";

            string json;
            try
            {
                json = File.ReadAllText(adminFile);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Admin login file not found.");
                return;
            }

            Admin admin;
            try
            {
                admin = JsonConvert.DeserializeObject<Admin>(json);
            }
            catch (JsonException)
            {
                Console.WriteLine("Invalid admin login file format");
                return;
            }

            int select = 1;
            do
            {
                Console.Clear();
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                if (admin.Username == username && admin.Password == password)
                {
                    Console.WriteLine("Login successful");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");

                    Console.WriteLine("[1] => Continue");
                    Console.WriteLine("[2] => Exit");
                    ConsoleKeyInfo info;

                    do
                    {
                        info = Console.ReadKey(true);
                        if (info.Key == ConsoleKey.UpArrow)
                        {
                            select = select == 1 ? 2 : 1;
                        }
                        else if (info.Key == ConsoleKey.DownArrow)
                        {
                            select = select == 2 ? 1 : 2;
                        }

                        Console.Clear();

                        if (select == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[1] => Continue");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("[2] => Exit");
                        }
                        else if (select == 2)
                        {
                            Console.WriteLine("[1] => Continue");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("[2] => Exit");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    } while (info.Key != ConsoleKey.Enter);

                    if (select == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Exit");
                        Console.ForegroundColor = ConsoleColor.White;
                        admin_menu();
                    }
                }
            } while (true);
        }

        public void write_file()
        {
            Admin admin = new Admin { Username = "hasanavs", Password = "hasan123" };
            string json = JsonConvert.SerializeObject(admin);
            File.WriteAllText("admin_login.json", json);
        }

    }
}