using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using Entity.Common;
using Entity.Model;
using Entity.ViewModel;

namespace DAL.Implementation
{
    public class UsersRepo : IUsersRepo
    {
        ApplicationDbContext _context;

        public UsersRepo(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public ResponseData Save(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();

            return new ResponseData
            {
                Success = true,
                Message = "New user added successfully."
            };
        }

        public ResponseData<List<Users>> GetAllUsers(string name)
        {
            List<Users> data = _context.Users.Where(x => x.IsActive == true
                                                    && (string.IsNullOrEmpty(name) || x.FullName.Contains(name))
                                                    ).ToList();

            return new ResponseData<List<Users>>
            {
                Data = data,
                Success = true,
                Message = "Users Fetched successfully."
            };
        }
    }
}
