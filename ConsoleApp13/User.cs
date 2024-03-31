using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static ConsoleApp13.Employer;
namespace ConsoleApp13
{
    public class User
    {
        public void user_menu()
        {
            int select = 1;

            do
            {
                Console.Clear();
                if (select == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[1] => Worker");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[2] => Employer");
                    Console.WriteLine("[3] => Exit");
                }
                else if (select == 2)
                {
                    Console.WriteLine("[1] => Worker");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[2] => Employer");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[3] => Exit");
                }
                else if (select == 3)
                {
                    Console.WriteLine("[1] => Worker");

                    Console.WriteLine("[2] => Employer");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[3] => Exit");
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
                        break;
                    }
                    else if (select == 1)
                    {
                        Worker worker = new Worker();
                        worker.WorkerMenu();
                    }
                    else if (select == 2)
                    {
                        Employer employer = new Employer();
                        employer.EmployerMenu();
                    }
                }
            } while (true);
        }
    }
    public class SameCode
    {
        public SameCode()
        {
            Vacancies = new List<VacancyDetails>();
        }

        public List<VacancyDetails> Vacancies { get; private set; }

        public void CreateVacancy(string title, DateTime deadline)
        {
            VacancyDetails vacancy = new VacancyDetails()
            {
                Guid = Guid.NewGuid(),
                JobTitle = title,
                Deadline = deadline
            };

            Vacancies.Add(vacancy);
        }

        public List<VacancyDetails> GetVacancies()
        {
            return Vacancies.Where(v => v.IsActive).ToList();
        }

        static public List<User> Users = new List<User>();
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                while (true)
                {
                    try
                    {
                        string pattern = @"^[a-zA-Z0-9_]{3,16}$";
                        Regex regex = new Regex(pattern);
                        if (regex.IsMatch(value))
                        {
                            username = value;
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("The username is not entered correctly!");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.Clear();
                        Console.Write("Please enter a valid username: ");
                        value = Console.ReadLine();
                    }
                }
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                while (true)
                {
                    try
                    {
                        string pattern = @"^[a-z\d]{8,}$";
                        Regex regex = new Regex(pattern);
                        if (regex.IsMatch(value))
                        {
                            password = value;
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("The password is not entered correctly!");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.Clear();
                        Console.Write("Please enter a valid password: ");
                        value = Console.ReadLine();
                    }
                }
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                while (true)
                {
                    try
                    {
                        string pattern = @"^([A-Z][a-z]+(\s|$))+";
                        Regex regex = new Regex(pattern);
                        if (regex.IsMatch(value))
                        {
                            name = value;
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("The name is not entered correctly!");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.Clear();
                        Console.Write("Please enter a valid name: ");
                        value = Console.ReadLine();
                    }
                }
            }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                while (true)
                {
                    try
                    {
                        string pattern = @"^([A-Z][a-z]+(\s|$))+";
                        Regex regex = new Regex(pattern);
                        if (regex.IsMatch(value))
                        {
                            surname = value;
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("The surname is not entered correctly!");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.Clear();
                        Console.Write("Please enter a valid surname: ");
                        value = Console.ReadLine();
                    }
                }
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                while (true)
                {
                    try
                    {
                        string pattern = @"^([A-Z][a-z]+(\s|$))+";
                        Regex regex = new Regex(pattern);
                        if (regex.IsMatch(value))
                        {
                            city = value;
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("The city is not entered correctly!");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.Clear();
                        Console.Write("Please enter a valid city: ");
                        value = Console.ReadLine();
                    }
                }
            }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                while (true)
                {
                    try
                    {
                        if (value >= 1 && value <= 100)
                        {
                            age = value;
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("The age is not entered correctly!");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.Clear();
                        Console.Write("Please enter a valid age: ");
                        value = int.Parse(Console.ReadLine());
                    }
                }
            }
        }


        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                while (true)
                {
                    try
                    {
                        string pattern = @"^\+994 (055|050|070|077|010|099) \d{3} \d{2} \d{2}$";
                        Regex regex = new Regex(pattern);
                        if (regex.IsMatch(value))
                        {
                            phoneNumber = value;
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("The phone number is not entered correctly!");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        Console.Clear();
                        Console.Write("Please enter a valid phone number: ");
                        value = Console.ReadLine();
                    }
                }
            }

        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                while (true)
                {
                    try
                    {
                        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                        Regex regex = new Regex(pattern);
                        if (regex.IsMatch(value))
                        {
                            email = value;
                            break;
                        }
                        else
                        {
                            throw new ArgumentException("The email is not entered correctly!");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.Clear();
                        Console.Write("Please enter a valid email: ");
                        value = Console.ReadLine();
                    }
                }
            }
        }

        public List<VacancyDetails> GetActiveVacancies()
        {
            List<VacancyDetails> vacancies = ReadVacanciesFromFile();
            DateTime now = DateTime.Now;

            foreach (var vacancy in vacancies)
            {
                vacancy.IsActive = vacancy.Deadline >= now;
            }
            UpdateVacanciesFile(vacancies);
            return vacancies.Where(v => v.IsActive).ToList();
        }
        public void UpdateVacanciesFile(List<VacancyDetails> vacancies)
        {
            try
            {
                File.WriteAllLines("vacancies.json", vacancies.Select(v => JsonSerializer.Serialize(v)));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }
        }

        public void ActivVacancies(bool isEmployer)
        {
            Console.Clear();
            Console.WriteLine("Active Vacancies:");
            List<VacancyDetails> activeVacancies = GetActiveVacancies();

            foreach (var vacancy in activeVacancies)
            {
                Console.WriteLine($"- {vacancy.Guid}: {vacancy.JobTitle} (Deadline: {vacancy.Deadline})");
            }
            if (isEmployer)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        public List<VacancyDetails> ReadVacanciesFromFile()
        {
            try
            {
                string[] lines = File.ReadAllLines("vacancies.json");
                List<VacancyDetails> vacancies = new List<VacancyDetails>();
                foreach (string line in lines)
                {
                    VacancyDetails vacancy = JsonSerializer.Deserialize<VacancyDetails>(line);
                    vacancy.IsActive = vacancy.Deadline > DateTime.Now;
                    vacancies.Add(vacancy);
                }
                return vacancies;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Vacancies file not found.");
                return new List<VacancyDetails>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Error deserializing JSON: " + ex.Message);
                return new List<VacancyDetails>();
            }
        }
    }

    class Worker
    {

        private static int idCounter = 1;

        private int id;
        public int Id
        {
            get { return id; }
            private set { id = value; }
        }
        public Guid Guid { get; private set; }

        public Worker()
        {
            Id = idCounter++;
            Guid = Guid.NewGuid();
        }
        public void WorkerMenu()
        {
            int select = 1;

            do
            {
                Console.Clear();
                if (select == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[1] => Login");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[2] => Sign up");
                    Console.WriteLine("[3] => Exit");
                }
                else if (select == 2)
                {
                    Console.WriteLine("[1] => Login");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[2] => Sign up");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[3] => Exit");
                }
                else if (select == 3)
                {
                    Console.WriteLine("[1] => Login");
                    Console.WriteLine("[2] => Sign up");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[3] => Exit");
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
                        User user = new User();
                        user.user_menu();
                    }
                    else if (select == 1)
                    {
                        Login();
                        WorkerMenu2();

                    }
                    else if (select == 2)
                    {
                        SignUp();
                        WorkerMenu2();
                    }
                }
            } while (true);
        }
        class UserData
        {
            private string cv;
            public string CV
            {
                get { return cv; }
                set
                {
                    while (true)
                    {
                        try
                        {
                            if (value != null)
                            {
                                cv = value;
                                break;
                            }
                            else
                            {
                                throw new ArgumentException("The Cv is not entered correctly!");
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.Clear();
                            Console.Write("Please enter a valid Cv: ");
                            value = Console.ReadLine();
                        }
                    }
                }
            }
        }

        public void Login()
        {
            do
            {
                Console.Clear();
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                try
                {
                    string[] lines = File.ReadAllLines("workers.json");

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 2)
                        {
                            SameCode same = JsonSerializer.Deserialize<SameCode>(parts[0]);
                            UserData data = JsonSerializer.Deserialize<UserData>(parts[1]);

                            if (same != null && string.Equals(username, same.Username, StringComparison.OrdinalIgnoreCase) && string.Equals(password, same.Password))
                            {
                                loggedInUsername = username;
                                Console.WriteLine("Login successful!");
                                Console.WriteLine("Press Enter to continue...");
                                Console.ReadLine();
                                return;
                            }
                        }
                    }
                    Console.WriteLine("Invalid username or password. Please try again.");

                    Console.WriteLine("[1] => Continue");
                    Console.WriteLine("[2] => Exit");
                    ConsoleKeyInfo info;


                    int select = 1;
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
                        WorkerMenu();

                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("User database not found. Please sign up first");
                    Console.ReadLine();
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Error deserializing JSON: " + ex.Message);
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.ReadLine();
                }
            } while (true);
        }

        public void SignUp()
        {
            Console.Clear();
            UserData data = new UserData();
            SameCode same = new SameCode();
            Console.Write("Enter your username: ");
            same.Username = Console.ReadLine();

            Console.Write("Enter your password: ");
            same.Password = Console.ReadLine();

            Console.Write("Enter your name: ");
            same.Name = Console.ReadLine();

            Console.Write("Enter your surname: ");
            same.Surname = Console.ReadLine();

            Console.Write("Enter your city: ");
            same.City = Console.ReadLine();

            Console.Write("Enter your phone number: ");
            same.PhoneNumber = Console.ReadLine();

            Console.Write("Enter your age: ");
            same.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter your CV: ");
            data.CV = Console.ReadLine();

            Console.WriteLine("Enter email: ");
            same.Email = Console.ReadLine();
            string recipientEmail = same.Email;
            string password1 = "123456";

            Network network = new Network();
            network.SendMail(recipientEmail);

            Console.WriteLine("Enter the code sent to Gmail: ");
            string code = Console.ReadLine();

            if (code == password1)
            {
                try
                {
                    string jsonString = JsonSerializer.Serialize(same);
                    string json = JsonSerializer.Serialize(data);
                    File.AppendAllText("workers.json", jsonString + "|" + json + "\n");
                    Console.WriteLine("Sign up successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error writing to file: " + ex.Message);
                }
                Console.ReadKey();
            }
        }

        public void WorkerMenu2()
        {
            int select = 1;

            do
            {
                Console.Clear();
                if (select == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[1] => Notification");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[2] => Edit Profil");
                    Console.WriteLine("[3] => Show Vacancies");
                    Console.WriteLine("[4] => Exit");
                }
                else if (select == 2)
                {
                    Console.WriteLine("[1] => Notification");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[2] => Edit Profil");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[3] => Show Vacancies");
                    Console.WriteLine("[4] => Exit");
                }
                else if (select == 3)
                {
                    Console.WriteLine("[1] => Notification");
                    Console.WriteLine("[2] => Edit Profil");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[3] => Show Vacancies");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[4] => Exit");
                }
                else if (select == 4)
                {
                    Console.WriteLine("[1] => Notification");
                    Console.WriteLine("[2] => Edit Profil");
                    Console.WriteLine("[3] => Show Vacancies");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[4] => Exit");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                ConsoleKeyInfo info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.UpArrow)
                {
                    if (select == 1) select = 4;
                    else select--;
                }
                else if (info.Key == ConsoleKey.DownArrow)
                {
                    if (select == 4) select = 1;
                    else select++;
                }

                if (info.Key == ConsoleKey.Enter)
                {
                    if (select == 4)
                    {
                        break;
                    }
                    else if (select == 3)
                    {
                        ShowVacancies();
                    }
                    else if (select == 2)
                    {
                        EditProfil();
                    }
                    else if (select == 1)
                    {
                        bool IsCheck = false;
                        Ischeck(IsCheck);
                    }
                }
            } while (true);
        }
        public void Ischeck(bool IsCheck)
        {
            if (IsCheck)
            {
                Console.WriteLine("Your job application has been accepted");
            }
            else
            {
                Console.WriteLine("Your request has been rejected");
            }
            Console.ReadLine();
        }

        public void ShowVacancies()
        {
            SameCode same = new SameCode();
            same.ActivVacancies(true);
            Console.Clear();
            Console.WriteLine("Active Vacancies:");
            List<VacancyDetails> activeVacancies = same.GetActiveVacancies();

            foreach (var vacancy in activeVacancies)
            {
                Console.WriteLine($"- {vacancy.Guid}: {vacancy.JobTitle} (Deadline: {vacancy.Deadline})");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            Console.WriteLine("Enter Vacancy Guid: ");
            string guidString = Console.ReadLine();
            Guid vacancyGuid;
            if (Guid.TryParse(guidString, out vacancyGuid))
            {
                VacancyDetails selectedVacancy = activeVacancies.FirstOrDefault(v => v.Guid == vacancyGuid);
                if (selectedVacancy != null)
                {
                    Console.WriteLine($"Selected Vacancy: {selectedVacancy.JobTitle}");
                    Console.WriteLine("Enter your email address to receive notification: ");
                    string email = Console.ReadLine();

                    Notification2(email, $"He applied for your vacancy: {selectedVacancy.JobTitle}", "Application Confirmation");
                }
                else
                {
                    Console.WriteLine("No vacancy found with the entered Guid.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Guid format. Please enter a valid Guid.");
            }
        }

        private string loggedInUsername;
        public void Notification()
        {
            try
            {
                string[] lines = File.ReadAllLines("workers.json");

                if (lines.Length == 0)
                {
                    Console.WriteLine("No data found in the workers file.");
                    return;
                }

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        SameCode same = JsonSerializer.Deserialize<SameCode>(parts[0]);
                        UserData data = JsonSerializer.Deserialize<UserData>(parts[1]);
                        if (same != null && string.Equals(same.Username, loggedInUsername, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.Clear();
                            Console.WriteLine("\nWorkers Information:");
                            Console.WriteLine($"Guid: {Guid}");
                            Console.WriteLine($"Name: {same.Name}");
                            Console.WriteLine($"Surname: {same.Surname}");
                            Console.WriteLine($"City: {same.City}");
                            Console.WriteLine($"Phone Number: {same.PhoneNumber}");
                            Console.WriteLine($"Age: {same.Age}");
                            Console.WriteLine($"Email: {same.Email}");
                            Console.WriteLine($"CV: {data.CV}");
                            Console.ReadLine();
                            return;
                        }
                    }
                }

                Console.WriteLine("Your profile not found.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("User database not found. Please sign up first");
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Error deserializing JSON: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        void Notification2(string mail, string ms, string subject)
        {

            string senderEmail = "hesenavs1@gmail.com";
            string senderPassword = "nyvc brqn ttec pbsv";


            string recipientEmail = mail;

            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;

            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.EnableSsl = true;

                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

                using (MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail))
                {
                    mailMessage.Subject = subject;


                    Random random = new Random();
                    int msg = random.Next(0, 100);
                    mailMessage.Body = ms;


                    try
                    {
                        smtpClient.Send(mailMessage);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to send email. Error's message: {ex.Message}");
                    }
                }
            }
        }

        public void Choice()
        {
            int select = 1;

            do
            {
                Console.Clear();
                if (select == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[1] => Accept");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[2] => Reject");
                    Console.WriteLine("[3] => Exit");
                }
                else if (select == 2)
                {
                    Console.WriteLine("[1] => Accept");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[2] => Reject");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[3] => Exit");
                }
                else if (select == 3)
                {
                    Console.WriteLine("[1] => Accept");
                    Console.WriteLine("[2] => Reject");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[3] => Exit");
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
                        Employer employer = new Employer();
                        employer.EmployerMenu2();
                    }
                    else if (select == 2)
                    {

                        Console.WriteLine("Your request has been rejected");
                        Console.ReadLine();
                        Ischeck(false);
                        break;
                    }
                    else if (select == 1)
                    {

                        Console.WriteLine("Your job application has been accepted");
                        Console.ReadLine();
                        Ischeck(true);
                    }
                }
            } while (true);
        }

        private void EditProfil()
        {
            try
            {
                string[] lines = File.ReadAllLines("workers.json");
                List<string> updatedLines = new List<string>();

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        SameCode same = JsonSerializer.Deserialize<SameCode>(parts[0]);
                        UserData data = JsonSerializer.Deserialize<UserData>(parts[1]);

                        if (same != null && same.Username == loggedInUsername)
                        {
                            Console.WriteLine("\nYour Profile Information:");
                            Console.WriteLine($"Name: {same.Name}");
                            Console.WriteLine($"Surname: {same.Surname}");
                            Console.WriteLine($"City: {same.City}");
                            Console.WriteLine($"Phone Number: {same.PhoneNumber}");
                            Console.WriteLine($"Age: {same.Age}");
                            Console.WriteLine($"Email: {same.Email}");
                            Console.WriteLine($"CV: {data.CV}");

                            Console.WriteLine("\nDo you want to update your profile? (Y/N)");
                            string response = Console.ReadLine();
                            if (response.ToUpper() == "Y")
                            {
                                int select = 1;

                                do
                                {
                                    Console.Clear();
                                    if (select == 1)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("[1] => Name");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("[2] => Surname");
                                        Console.WriteLine("[3] => City");
                                        Console.WriteLine("[4] => Phone number");
                                        Console.WriteLine("[5] => Age");
                                        Console.WriteLine("[6] => Email");
                                        Console.WriteLine("[7] => Exit");
                                    }
                                    else if (select == 2)
                                    {
                                        Console.WriteLine("[1] => Name");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("[2] => Surname");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("[3] => City");
                                        Console.WriteLine("[4] => Phone number");
                                        Console.WriteLine("[5] => Age");
                                        Console.WriteLine("[6] => Email");
                                        Console.WriteLine("[7] => Exit");
                                    }
                                    else if (select == 3)
                                    {
                                        Console.WriteLine("[1] => Name");
                                        Console.WriteLine("[2] => Surname");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("[3] => City");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("[4] => Phone number");
                                        Console.WriteLine("[5] => Age");
                                        Console.WriteLine("[6] => Email");
                                        Console.WriteLine("[7] => Exit");
                                    }
                                    else if (select == 4)
                                    {
                                        Console.WriteLine("[1] => Name");
                                        Console.WriteLine("[2] => Surname");
                                        Console.WriteLine("[3] => City");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("[4] => Phone number");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("[5] => Age");
                                        Console.WriteLine("[6] => Email");
                                        Console.WriteLine("[7] => Exit");
                                    }
                                    else if (select == 5)
                                    {
                                        Console.WriteLine("[1] => Name");
                                        Console.WriteLine("[2] => Surname");
                                        Console.WriteLine("[3] => City");
                                        Console.WriteLine("[4] => Phone number");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("[5] => Age");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("[6] => Email");
                                        Console.WriteLine("[7] => Exit");
                                    }
                                    else if (select == 6)
                                    {
                                        Console.WriteLine("[1] => Name");
                                        Console.WriteLine("[2] => Surname");
                                        Console.WriteLine("[3] => City");
                                        Console.WriteLine("[4] => Phone number");
                                        Console.WriteLine("[5] => Age");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("[6] => Email");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("[7] => Exit");
                                    }
                                    else if (select == 7)
                                    {
                                        Console.WriteLine("[1] => Name");
                                        Console.WriteLine("[2] => Surname");
                                        Console.WriteLine("[3] => City");
                                        Console.WriteLine("[4] => Phone number");
                                        Console.WriteLine("[5] => Age");
                                        Console.WriteLine("[6] => Email");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("[7] => Exit");
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }

                                    ConsoleKeyInfo info = Console.ReadKey(true);
                                    if (info.Key == ConsoleKey.UpArrow)
                                    {
                                        if (select == 1) select = 7;
                                        else select--;
                                    }
                                    else if (info.Key == ConsoleKey.DownArrow)
                                    {
                                        if (select == 7) select = 1;
                                        else select++;
                                    }

                                    if (info.Key == ConsoleKey.Enter)
                                    {
                                        if (select == 7)
                                        {
                                            break;
                                        }
                                        else if (select == 6)
                                        {
                                            Console.Write("Enter your new email: ");
                                            same.Email = Console.ReadLine();
                                            Console.WriteLine("Email successfully change");
                                            Console.WriteLine("Press Enter to continue...");
                                            Console.ReadLine();
                                        }
                                        else if (select == 5)
                                        {
                                            Console.Write("Enter your new age: ");
                                            same.Age = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Age successfully change");
                                            Console.WriteLine("Press Enter to continue...");
                                            Console.ReadLine();
                                        }
                                        else if (select == 4)
                                        {
                                            Console.Write("Enter your phone new number: ");
                                            same.PhoneNumber = Console.ReadLine();
                                            Console.WriteLine("Phone number successfully change");
                                            Console.WriteLine("Press Enter to continue...");
                                            Console.ReadLine();
                                        }
                                        else if (select == 3)
                                        {
                                            Console.Write("Enter your new city: ");
                                            same.City = Console.ReadLine();
                                            Console.WriteLine("City successfully change");
                                            Console.WriteLine("Press Enter to continue...");
                                            Console.ReadLine();
                                        }
                                        else if (select == 2)
                                        {
                                            Console.Write("Enter your new surname: ");
                                            same.Surname = Console.ReadLine();
                                            Console.WriteLine("Surname successfully change");
                                            Console.WriteLine("Press Enter to continue...");
                                            Console.ReadLine();
                                        }
                                        else if (select == 1)
                                        {
                                            Console.Write("Enter your new name: ");
                                            same.Name = Console.ReadLine();
                                            Console.WriteLine("Name successfully change");
                                            Console.WriteLine("Press Enter to continue...");
                                            Console.ReadLine();
                                        }
                                    }
                                } while (true);
                                UpdateProfile(same);
                            }
                        }
                    }
                }
                Console.WriteLine("Your profile not found.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("User database not found. Please sign up first");
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Error deserializing JSON: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void UpdateProfile(SameCode updatedProfile)
        {
            try
            {
                string[] lines = File.ReadAllLines("workers.json");
                List<string> updatedLines = new List<string>();
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        SameCode same = JsonSerializer.Deserialize<SameCode>(parts[0]);
                        UserData data = JsonSerializer.Deserialize<UserData>(parts[1]);
                        if (same.Username == updatedProfile.Username)
                        {
                            updatedLines.Add(JsonSerializer.Serialize(updatedProfile) + "|" + JsonSerializer.Serialize(data));
                        }
                        else
                        {
                            updatedLines.Add(line);
                        }
                    }
                }
                File.WriteAllLines("workers.json", updatedLines);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("User database not found. Please sign up first");
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Error deserializing JSON: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    public class Employer
    {
        private static int idCounter = 1;

        private int id;
        public int Id
        {
            get { return id; }
            private set { id = value; }
        }

        public Employer()
        {
            Id = idCounter++;
        }

        public void EmployerMenu()
        {
            int select = 1;

            do
            {
                Console.Clear();
                if (select == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[1] => Login");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[2] => Sign up");
                    Console.WriteLine("[3] => Exit");
                }
                else if (select == 2)
                {
                    Console.WriteLine("[1] => Login");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[2] => Sign up");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[3] => Exit");
                }
                else if (select == 3)
                {
                    Console.WriteLine("[1] => Login");
                    Console.WriteLine("[2] => Sign up");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[3] => Exit");
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
                        User user = new User();
                        user.user_menu();
                    }
                    else if (select == 1)
                    {
                        Login();
                        EmployerMenu2();
                    }
                    else if (select == 2)
                    {
                        SignUp();
                        EmployerMenu2();
                    }
                }
            } while (true);
        }
        class UserData
        {
            public VacancyDetails Vacancies { get; set; }
        }

        public class VacancyDetails
        {
            public Guid Guid { get; set; } = Guid.NewGuid();
            public string JobTitle { get; set; }
            public string Description { get; set; }
            public string Requirements { get; set; }
            public string Location { get; set; }
            public int Salary { get; set; }
            public DateTime Deadline { get; set; }
            public bool IsActive { get; set; }
        }
        private string loggedInUsername;
        public void Login()
        {
            do
            {
                Console.Clear();
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                try
                {
                    string[] lines = File.ReadAllLines("employers.json");

                    foreach (string line in lines)
                    {
                        SameCode same = JsonSerializer.Deserialize<SameCode>(line);

                        if (same != null && string.Equals(username, same.Username, StringComparison.OrdinalIgnoreCase) && string.Equals(password, same.Password))
                        {
                            loggedInUsername = username;
                            Console.WriteLine("Login successful!");
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                            return;
                        }
                    }

                    Console.WriteLine("Invalid username or password. Please try again.");

                    Console.WriteLine("[1] => Continue");
                    Console.WriteLine("[2] => Exit");
                    ConsoleKeyInfo info;

                    int select = 1;
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
                        EmployerMenu();

                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("User database not found. Please sign up first");
                    Console.ReadLine();
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Error deserializing JSON: " + ex.Message);
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.ReadLine();
                }
            } while (true);
        }

        public void SignUp()
        {
            Console.Clear();
            SameCode same = new SameCode();
            Console.Write("Enter your username: ");
            same.Username = Console.ReadLine();

            Console.Write("Enter your password: ");
            same.Password = Console.ReadLine();

            Console.Write("Enter your name: ");
            same.Name = Console.ReadLine();

            Console.Write("Enter your surname: ");
            same.Surname = Console.ReadLine();

            Console.Write("Enter your city: ");
            same.City = Console.ReadLine();

            Console.Write("Enter your phone number: ");
            same.PhoneNumber = Console.ReadLine();

            Console.Write("Enter your age: ");
            same.Age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter email: ");
            same.Email = Console.ReadLine();
            string recipientEmail = same.Email;
            string password1 = "123456";

            Network network = new Network();
            network.SendMail(recipientEmail);

            Console.WriteLine("Enter the code sent to Gmail: ");
            string code = Console.ReadLine();

            if (code == password1)
            {

                string jsonString = JsonSerializer.Serialize(same);

                try
                {
                    File.AppendAllText("employers.json", jsonString + "\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error writing to file: " + ex.Message);
                }

                Console.WriteLine("Sign up successful!");
                Console.ReadKey();
            }
        }
        public void EmployerMenu2()
        {
            int select = 1;

            do
            {
                Console.Clear();
                if (select == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[1] => Edit Profil");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[2] => Activ Vacancies");
                    Console.WriteLine("[3] => Add Vacancies");
                    Console.WriteLine("[4] => Delete Vacancies");
                    Console.WriteLine("[5] => Notification");
                    Console.WriteLine("[6] => Exit");
                }
                else if (select == 2)
                {
                    Console.WriteLine("[1] => Edit Profil");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[2] => Activ Vacancies");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[3] => Add Vacancies");
                    Console.WriteLine("[4] => Delete Vacancies");
                    Console.WriteLine("[5] => Notification");
                    Console.WriteLine("[6] => Exit");
                }
                else if (select == 3)
                {
                    Console.WriteLine("[1] => Edit Profil");
                    Console.WriteLine("[2] => Activ Vacancies");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[3] => Add Vacancies");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[4] => Delete Vacancies");
                    Console.WriteLine("[5] => Notification");
                    Console.WriteLine("[6] => Exit");
                }
                else if (select == 4)
                {
                    Console.WriteLine("[1] => Edit Profil");
                    Console.WriteLine("[2] => Activ Vacancies");
                    Console.WriteLine("[3] => Add Vacancies");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[4] => Delete Vacancies");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[5] => Notification");
                    Console.WriteLine("[6] => Exit");
                }
                else if (select == 5)
                {
                    Console.WriteLine("[1] => Edit Profil");
                    Console.WriteLine("[2] => Activ Vacancies");
                    Console.WriteLine("[3] => Add Vacancies");
                    Console.WriteLine("[4] => Delete Vacancies");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[5] => Notification");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("[6] => Exit");
                }
                else if (select == 6)
                {
                    Console.WriteLine("[1] => Edit Profil");
                    Console.WriteLine("[2] => Activ Vacancies");
                    Console.WriteLine("[3] => Add Vacancies");
                    Console.WriteLine("[4] => Delete Vacancies");
                    Console.WriteLine("[5] => Notification");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[6] => Exit");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                ConsoleKeyInfo info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.UpArrow)
                {
                    if (select == 1) select = 6;
                    else select--;
                }
                else if (info.Key == ConsoleKey.DownArrow)
                {
                    if (select == 6) select = 1;
                    else select++;
                }
                SameCode same = new SameCode();
                if (info.Key == ConsoleKey.Enter)
                {
                    if (select == 6)
                    {
                        break;
                    }
                    else if (select == 1)
                    {
                        EditProfil();
                    }
                    else if (select == 2)
                    {
                        same.ActivVacancies(true);
                    }
                    else if (select == 3)
                    {
                        AddVacancy();
                    }
                    else if (select == 4)
                    {
                        DeleteVacancy();
                    }
                    else if (select == 5)
                    {
                        Worker worker = new Worker();
                        worker.Notification();
                        worker.Choice();
                    }

                    same.ReadVacanciesFromFile();
                }
            } while (true);
        }
        public void AddVacancy()
        {
            Console.Clear();
            VacancyDetails vacancy = new VacancyDetails();

            Console.Write("Enter job title: ");
            vacancy.JobTitle = Console.ReadLine();

            Console.Write("Enter description: ");
            vacancy.Description = Console.ReadLine();

            Console.Write("Enter requirements: ");
            vacancy.Requirements = Console.ReadLine();

            Console.Write("Enter location: ");
            vacancy.Location = Console.ReadLine();

            Console.Write("Enter salary: ");
            vacancy.Salary = int.Parse(Console.ReadLine());

            Console.Write("Enter deadline (yyyy-MM-dd HH:mm:ss): ");
            vacancy.Deadline = DateTime.Parse(Console.ReadLine());

            vacancy.Guid = Guid.NewGuid();
            string jsonString = JsonSerializer.Serialize(vacancy);

            try
            {
                File.AppendAllText("vacancies.json", jsonString + "\n");
                Console.WriteLine("Vacancy added successfully!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
                Console.ReadKey();
            }
        }
        public void DeleteVacancy()
        {
            Console.Clear();
            SameCode same = new SameCode();

            List<VacancyDetails> vacancies = same.ReadVacanciesFromFile();

            Console.WriteLine("Existing vacancies:");
            foreach (var vacancy in vacancies)
            {
                Console.WriteLine($"- {vacancy.JobTitle} ({vacancy.Guid})");
            }

            Console.Write("\nEnter the GUID of the vacancy to delete: ");
            string guidString = Console.ReadLine();


            if (Guid.TryParse(guidString, out Guid guid))
            {
                var vacancyToDelete = vacancies.FirstOrDefault(v => v.Guid == guid);
                if (vacancyToDelete != null)
                {
                    vacancies.Remove(vacancyToDelete);
                    same.UpdateVacanciesFile(vacancies);
                    Console.WriteLine("Vacancy deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Vacancy not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid GUID format.");
            }

            Console.ReadKey();
        }


        private void EditProfil()
        {
            try
            {
                string[] lines = File.ReadAllLines("employers.json");

                foreach (string line in lines)
                {
                    SameCode same = JsonSerializer.Deserialize<SameCode>(line);
                    if (same != null && same.Username == loggedInUsername)
                    {
                        Console.WriteLine("\nYour Profile Information:");
                        Console.WriteLine($"Name: {same.Name}");
                        Console.WriteLine($"Surname: {same.Surname}");
                        Console.WriteLine($"City: {same.City}");
                        Console.WriteLine($"Phone Number: {same.PhoneNumber}");
                        Console.WriteLine($"Age: {same.Age}");
                        Console.WriteLine($"Email: {same.Email}");

                        Console.WriteLine("\nDo you want to update your profile? (Y/N)");
                        string response = Console.ReadLine();
                        if (response.ToUpper() == "Y")
                        {
                            int select = 1;

                            do
                            {
                                Console.Clear();
                                if (select == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("[1] => Name");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("[2] => Surname");
                                    Console.WriteLine("[3] => City");
                                    Console.WriteLine("[4] => Phone number");
                                    Console.WriteLine("[5] => Age");
                                    Console.WriteLine("[6] => Email");
                                    Console.WriteLine("[7] => Exit");
                                }
                                else if (select == 2)
                                {
                                    Console.WriteLine("[1] => Name");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("[2] => Surname");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("[3] => City");
                                    Console.WriteLine("[4] => Phone number");
                                    Console.WriteLine("[5] => Age");
                                    Console.WriteLine("[6] => Email");
                                    Console.WriteLine("[7] => Exit");
                                }
                                else if (select == 3)
                                {
                                    Console.WriteLine("[1] => Name");
                                    Console.WriteLine("[2] => Surname");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("[3] => City");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("[4] => Phone number");
                                    Console.WriteLine("[5] => Age");
                                    Console.WriteLine("[6] => Email");
                                    Console.WriteLine("[7] => Exit");
                                }
                                else if (select == 4)
                                {
                                    Console.WriteLine("[1] => Name");
                                    Console.WriteLine("[2] => Surname");
                                    Console.WriteLine("[3] => City");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("[4] => Phone number");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("[5] => Age");
                                    Console.WriteLine("[6] => Email");
                                    Console.WriteLine("[7] => Exit");
                                }
                                else if (select == 5)
                                {
                                    Console.WriteLine("[1] => Name");
                                    Console.WriteLine("[2] => Surname");
                                    Console.WriteLine("[3] => City");
                                    Console.WriteLine("[4] => Phone number");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("[5] => Age");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("[6] => Email");
                                    Console.WriteLine("[7] => Exit");
                                }
                                else if (select == 6)
                                {
                                    Console.WriteLine("[1] => Name");
                                    Console.WriteLine("[2] => Surname");
                                    Console.WriteLine("[3] => City");
                                    Console.WriteLine("[4] => Phone number");
                                    Console.WriteLine("[5] => Age");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("[6] => Email");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("[7] => Exit");
                                }
                                else if (select == 7)
                                {
                                    Console.WriteLine("[1] => Name");
                                    Console.WriteLine("[2] => Surname");
                                    Console.WriteLine("[3] => City");
                                    Console.WriteLine("[4] => Phone number");
                                    Console.WriteLine("[5] => Age");
                                    Console.WriteLine("[6] => Email");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("[7] => Exit");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }

                                ConsoleKeyInfo info = Console.ReadKey(true);
                                if (info.Key == ConsoleKey.UpArrow)
                                {
                                    if (select == 1) select = 7;
                                    else select--;
                                }
                                else if (info.Key == ConsoleKey.DownArrow)
                                {
                                    if (select == 7) select = 1;
                                    else select++;
                                }

                                if (info.Key == ConsoleKey.Enter)
                                {
                                    if (select == 7)
                                    {
                                        break;
                                    }
                                    else if (select == 6)
                                    {
                                        Console.Write("Enter your new email: ");
                                        same.Email = Console.ReadLine();
                                        Console.WriteLine("Email successfully change");
                                        Console.WriteLine("Press Enter to continue...");
                                        Console.ReadLine();
                                    }
                                    else if (select == 5)
                                    {
                                        Console.Write("Enter your new age: ");
                                        same.Age = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Age successfully change");
                                        Console.WriteLine("Press Enter to continue...");
                                        Console.ReadLine();
                                    }
                                    else if (select == 4)
                                    {
                                        Console.Write("Enter your phone new number: ");
                                        same.PhoneNumber = Console.ReadLine();
                                        Console.WriteLine("Phone number successfully change");
                                        Console.WriteLine("Press Enter to continue...");
                                        Console.ReadLine();
                                    }
                                    else if (select == 3)
                                    {
                                        Console.Write("Enter your new city: ");
                                        same.City = Console.ReadLine();
                                        Console.WriteLine("City successfully change");
                                        Console.WriteLine("Press Enter to continue...");
                                        Console.ReadLine();
                                    }
                                    else if (select == 2)
                                    {
                                        Console.Write("Enter your new surname: ");
                                        same.Surname = Console.ReadLine();
                                        Console.WriteLine("Surname successfully change");
                                        Console.WriteLine("Press Enter to continue...");
                                        Console.ReadLine();
                                    }
                                    else if (select == 1)
                                    {
                                        Console.Write("Enter your new name: ");
                                        same.Name = Console.ReadLine();
                                        Console.WriteLine("Name successfully change");
                                        Console.WriteLine("Press Enter to continue...");
                                        Console.ReadLine();
                                    }
                                }
                            } while (true);
                            UpdateProfile(same);
                        }
                    }
                }

                Console.WriteLine("Your profile not found.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("User database not found. Please sign up first");
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Error deserializing JSON: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void UpdateProfile(SameCode updatedProfile)
        {
            try
            {
                string[] lines = File.ReadAllLines("employers.json");
                List<SameCode> profiles = new List<SameCode>();
                foreach (string line in lines)
                {
                    SameCode profile = JsonSerializer.Deserialize<SameCode>(line);
                    if (profile.Username == updatedProfile.Username)
                    {
                        profiles.Add(updatedProfile);
                    }
                    else
                    {
                        profiles.Add(profile);
                    }
                }

                File.WriteAllLines("employers.json", profiles.Select(p => JsonSerializer.Serialize(p)));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("User database not found. Please sign up first");
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Error deserializing JSON: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}