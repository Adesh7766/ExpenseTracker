using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.IServices;
using DAL;
using DAL.Interface;
using Entity.Common;
using Entity.Model;
using Entity.ViewModel;

namespace BAL.ServiceImplementation
{
    public class UsersServices : IUsersService
    {
        IUsersRepo _repo;

        public UsersServices(IUsersRepo repo)
        {
            _repo = repo;   
        }

        public ResponseData Save(UsersVM userVM)
        {
            Users user = new Users();

            user.UserGroupID = 1;
            user.FullName = userVM.FullName;
            user.UserName = userVM.UserName;
            user.Password = userVM.Password;
            user.Email = userVM.Email;
            if(userVM.IsActive == "true")
            {
                user.IsActive = true;
            }
            else
            {
                user.IsActive = false;
            }

            _repo.Save(user);

            return new ResponseData
            {
                Success = true,
                Message = "New user added successfully."
            };
        }

        public ResponseData<List<UsersVM>> GetAllData(string name)
        {
            var data = _repo.GetAllUsers(name).Data
                        .Select(x => new UsersVM
                        {
                            UserID = x.UserID,
                            FullName = x.FullName,
                            UserGroup = "Admin",
                            IsActive = x.IsActive.ToString()
                        }).ToList();

            return new ResponseData<List<UsersVM>>
            {
                Data = data,
                Success = true,
                Message = "Successfully got all user data."
            };

            
        }

        public ResponseData Delete(int id)
        {
            _repo.Delete(id);

            return new ResponseData
            {
                Success = true,
                Message = "User Deleted Successfully."
            };
        }
    }
}
