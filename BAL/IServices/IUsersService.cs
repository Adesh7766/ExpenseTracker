using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Entity.Common;
using Entity.Model;
using Entity.ViewModel;

namespace BAL.IServices
{
    public interface IUsersService
    {
        ResponseData Save(UsersVM user);

        ResponseData<List<UsersVM>> GetAllData(string name);

        ResponseData Delete(int id);
    }
}
