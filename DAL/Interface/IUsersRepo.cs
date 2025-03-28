using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Common;
using Entity.Model;
using Entity.ViewModel;

namespace DAL.Interface
{
    public interface IUsersRepo
    {
        ResponseData Save(Users user);

        ResponseData Delete(int id);

        //ResponseData Update(UsersVM user);

        //ResponseData<Users> GetUser(int id);

        ResponseData<List<Users>> GetAllUsers(string name);
    }
}
