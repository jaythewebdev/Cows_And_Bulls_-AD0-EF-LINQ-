namespace UsersModelLibrary
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age;
        public string Phone { get; set; }
        public string Password { get;set; }
        

        public User()
        {

        }
        public User(int id, string name, int age,string phone,String password)
        {
            Id = id;
            Name = name;
            Age = age;
            Phone = phone;
            Password = password;
        }

        public virtual void TakeUserDetails()
        {

            Console.Write("Enter your Name  : ");

            Name = Console.ReadLine();


            Console.Write("Enter your Age  : ");
            while (!int.TryParse(Console.ReadLine(), out Age))
            {
                Console.WriteLine("Age must be a Number");
            }


            Console.Write("Enter your Phone Number  : ");

            Phone = Console.ReadLine();

        }

        public override string ToString()
        {
            string UserDetails = "";

            UserDetails += "User Details";
            UserDetails += $"\nUser  Id : {Id}";//Interpollation
            UserDetails += $"\nUser Name : {Name}";//Interpollation
            UserDetails += $"\nAge : {Age}";//Interpollation

            UserDetails += $"\nPhone Number  :{Phone}";
       
            UserDetails += $"\n----------------";

            return UserDetails;
        }


    }

}