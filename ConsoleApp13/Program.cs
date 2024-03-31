using ConsoleApp13;

Main_Menu menu = new Main_Menu();
menu.main_menu();

class Main_Menu
{
    public void main_menu()
    {
        int select = 1;

        do
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t _______                                        ______            ");
            Console.WriteLine("\t|       \\                                      /      \\           ");
            Console.WriteLine("\t| $$$$$$$\\  ______    _______   _______       |  $$$$$$\\ ________ ");
            Console.WriteLine("\t| $$__/ $$ /      \\  /       \\ /       \\      | $$__| $$|        \\");
            Console.WriteLine("\t| $$    $$|  $$$$$$\\|  $$$$$$$|  $$$$$$$      | $$    $$ \\$$$$$$$$");
            Console.WriteLine("\t| $$$$$$$\\| $$  | $$ \\$$    \\  \\$$    \\       | $$$$$$$$  /    $$ ");
            Console.WriteLine("\t| $$__/ $$| $$__/ $$ _\\$$$$$$\\ _\\$$$$$$\\      | $$  | $$ /  $$$$_ ");
            Console.WriteLine("\t| $$    $$ \\$$    $$|       $$|       $$      | $$  | $$|  $$    \\");
            Console.WriteLine("\t \\$$$$$$$   \\$$$$$$  \\$$$$$$$  \\$$$$$$$        \\$$   \\$$ \\$$$$$$$$");
            Console.WriteLine("\t                                                                 ");
            Console.WriteLine("\t                                                                 ");
            Console.WriteLine("\t                                                                 ");
            Console.ForegroundColor = ConsoleColor.White;

            if (select == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t[1] => Admin");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t[2] => User");
                Console.WriteLine("\t\t[3] => Exit");
            }
            else if (select == 2)
            {
                Console.WriteLine("\t\t[1] => Admin");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t[2] => User");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t[3] => Exit");
            }
            else if (select == 3)
            {
                Console.WriteLine("\t\t[1] => Admin");
                Console.WriteLine("\t\t[2] => User");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t[3] => Exit");
                Console.ForegroundColor = ConsoleColor.White;

            }
            ConsoleKeyInfo info = Console.ReadKey(true);
            if (info.Key == ConsoleKey.UpArrow)
            {
                if (select == 1) select = 3;
                else select--;
            }
            else if (info.Key == ConsoleKey.DownArrow)
            {
                if (select == 3) select = 1;
                else select++;
            }

            if (info.Key == ConsoleKey.Enter)
            {
                if (select == 3)
                {
                    Environment.Exit(0);
                }
                else if (select == 1)
                {
                    Admin admin = new Admin();
                    admin.admin_menu();
                }
                else if (select == 2)
                {
                    User user = new User();
                    user.user_menu();
                }
            }
        } while (true);
    }
}