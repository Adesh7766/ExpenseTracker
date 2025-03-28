using BAL.IServices;
using Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrakcer.Controllers
{
    public class UsersController : Controller
    {
        IUsersService _usersServices;

        public UsersController(IUsersService usersService)
        {
            _usersServices = usersService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveUser([FromBody] UsersVM usersVM)
        {
            _usersServices.Save(usersVM);

            return Json(new
            {
                Success = true,
                Message = "New user added successfully."
            });
        }

        public JsonResult GetAllUsers(string name)
        {
            List<UsersVM> data = _usersServices.GetAllData(name).Data;

            return Json(new
            {
                Data = data,
                Success = true
            });
        }

        public JsonResult Delete(int id)
        {
            _usersServices.Delete(id);

            return Json(new
            {
                Success = true,
                Message = "User Deleted Successfully."
            });
        }
    }
}
