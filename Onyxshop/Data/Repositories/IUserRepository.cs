using Onyxshop.Models;
using Onyxshop.Data;

namespace Onyxshop.Data.Repositories
{
    public interface IUserRepository
    {
        void Adduser(User user);
        public bool isexistuserbyphone(string phone);

        //برای لاگین کردن ابتدا باید یوزر لاگین اعتبارسنجی بشه
        public User getuserforlogin(string loginstr, string pass);
    }


    public class UserRepository : IUserRepository
    {
        OnyxContext _context;
        public UserRepository(OnyxContext context)
        {
            _context = context;
        }

 

        public bool isexistuserbyphone(string phone)
        {
           return _context.users.Any(c=>c.PhoneNo == phone);
        }

        void IUserRepository.Adduser(User user)
        {
            if ((_context.users.Contains(user)) == false)              
            _context.Add(user);
            _context.SaveChanges();
        }

        public User getuserforlogin(string loginstr, string pass)
        {
            User v = _context.users.SingleOrDefault(v => v.UserName == loginstr || v.PhoneNo == loginstr && v.Password == pass);
            return v;
        }

        


    }
}
