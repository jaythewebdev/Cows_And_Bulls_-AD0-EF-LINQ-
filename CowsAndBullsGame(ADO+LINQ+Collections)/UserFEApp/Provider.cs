using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UserFEApp;
using UsersModelLibrary;
using UserBLLibrary;
using UserDALLibrary;
using Context;
namespace UserFEApp
    {
        public class Provider
        {
            ManageUser manageuser;
            IRepo<User, int> UserRepo;
            private int userid;
            int Id;

        public Provider()
            {
                UserRepo = new UserRepository();
                manageuser = new ManageUser(UserRepo);
            }

        public void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("***********************************");
                Console.WriteLine("Welcome to the Game");
                Console.WriteLine("1.Register\n2.Login\n0.Exit");
                Console.WriteLine("Choose an Option :");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice");
                }

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye...");
                        break;
                    case 1:
                        AddNewUser();
                        GameMenu();

                        break;
                    case 2:
                        Login();
                        break;

                    default:
                        Console.WriteLine("Enter a Valid Choice ");
                        break;
                }
            } while (choice != 0);
        }
        public void AddNewUser()
        {
            User user = new User();
            user.TakeUserDetails();
            try
            {
                Console.WriteLine(manageuser.Add(user));
                Console.WriteLine($"Welcome- your password is your name and age together{user.Name + Convert.ToString(user.Age)}\r\n");
                Console.WriteLine($"Your Id is {user.Id}");
                Console.WriteLine("***********************************");
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            Id = user.Id;
        }
        public void GameMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("***********************************");
                Console.WriteLine("Welcome to the Game");
                Console.WriteLine("1.Give Word\n2.Guess Word\n0.Exit");
                Console.WriteLine("Choose an Option :");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice");
                }
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye...");
                        break;
                    case 1:
                        GiveAword();
                        break;
                    case 2:
                        GuessWord();
                        if (manageuser.IsStackEmpty()) 
                        {
                        }
                        else { 
                        manageuser.PopStack();
                        }
                        break;

                    default:
                        Console.WriteLine("Enter a Valid Choice ");
                        break;

                }
            } while (choice != 0);

        }

        public void GiveAword()
        {
            Console.WriteLine("Please Enter the Word :");
            string givenword;
            givenword =Console.ReadLine();
            manageuser.GiveWord(givenword);
            Console.WriteLine("Thank you the word is added to the queue");
        }
        public void GuessWord()
        {          
            if (manageuser.IsStackEmpty())
            {
                Console.WriteLine("Sorry there are currently no words to guess");
            }
            else
            {
                string guessword="s";
                Console.WriteLine("The Word id ready ");
                Console.WriteLine("Start Guessing");
                Console.WriteLine("Press 0 to exit from the Game anytime inbetween the play :) ");
                int cows = 0, bulls = 1;
                bool status = true;
                int NoOfattempts=0;
                string StatusOfAttempt="Lost";
                while (status)
                {
                    guessword = Console.ReadLine();
                    if (guessword == "0")
                    {
                        Console.WriteLine("Bye...");
                        break;
                    }

                    cows = manageuser.cows(guessword);
                    bulls = manageuser.bulls(guessword);
                    Console.WriteLine($"Cows - {cows} Bulls - {bulls}");
                    NoOfattempts += 1;
                    if (cows == guessword.Length && bulls == 0)
                    {
                        Console.WriteLine("Yayyyy you Won");
                        StatusOfAttempt = "Won";
                        NoOfattempts += 1;
                        status = false;
                    }
                }
                manageuser.updateAttemptDetails(Id, NoOfattempts, manageuser.PeekOfStack(), StatusOfAttempt);

            }

        }
        public void Login()
        {
            Console.WriteLine("Enter your UserId : ");
            while (!int.TryParse(Console.ReadLine(),out userid))
            {
                Console.WriteLine("User Id must be an integer");
            }

            Console.WriteLine("Enter your Password : ");
            string password=Console.ReadLine();
            bool status =manageuser.CheckloginCredentials(userid,password);
            if (status == true)
            {
                Console.WriteLine("You are Successfully Logged In");
                Id = userid;
                GameMenu();
            }
            else
            {
                Console.WriteLine("Invalid Credentials");
            }
        }
    }
    }



