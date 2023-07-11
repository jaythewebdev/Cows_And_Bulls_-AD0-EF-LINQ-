using System.Numerics;
using UsersModelLibrary;
using UserDALLibrary;
using System.Reflection.Metadata.Ecma335;
using Context;

namespace UserBLLibrary
{
    public class ManageUser
    {
        UserContext context = new UserContext();

        IRepo<User, int> _repo;

        static Stack<string> stack = new Stack<string>();

        public ManageUser()
        {

        }
        public ManageUser(IRepo<User, int> repo)
        {
            _repo = repo;
        }
        public User Add(User user)
        {
            return _repo.Add(user);
        }

        public void GiveWord(string giveword)
        {
            stack.Push(giveword); 
        }
        public int cows(string guessWord) {
            int cows = 0;
            var originalWord = stack.Peek();

            for (var i = 0; i < originalWord.Length; i++)
            {
                if (originalWord[i] == guessWord[i])
                {
                    cows = cows + 1;
                }
            }
            return cows;
        }
        public int bulls(string guessWord)
        {
            int bulls = 0;
            string orignalWord = stack.Peek();

            for (var i = 0; i < orignalWord.Length; i++)
            {
                for (var j = 0; j < orignalWord.Length; j++)
                {
                    if (i != j)
                    {
                        if (orignalWord[i] == guessWord[j])
                        {
                            bulls = bulls + 1;
                            break;
                        }
                    }
                }
            }
            return bulls;
        }
        public bool CheckloginCredentials(int userid, string password)
        {
            bool status=false;

            User user = new User();
            var users = (from u in context.Users select u).ToList();
            foreach (var user1 in users)
            {
                if (user1.Id == userid && user1.Password == password)
                {
                    status = true;
                    return status;
                }
            }
            return status;
        }

        public void updateAttemptDetails(int Id,int NoOfAttempts,string word ,string status)
        {

           AttemptDetails attemptDetails = new AttemptDetails();
           attemptDetails.Id = Id;
           attemptDetails.NumberOfAttempts = NoOfAttempts;
           attemptDetails.Word = word;
           attemptDetails.Status=status;
           context.AttemptDetails.Add(attemptDetails);
           context.SaveChanges();

        }
        public bool IsStackEmpty()
        {
            bool status = false;

            if (stack.Count == 0)
            {
                status=true;
            }
            return status;
        }
        public void PopStack()
        {
            stack.Pop();
        }
        public string PeekOfStack()
        {
            return stack.Peek();
        }
        }
    }