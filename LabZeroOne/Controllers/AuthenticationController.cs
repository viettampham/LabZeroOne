using LabZeroOne.Data;
using LabZeroOne.Models.ResponseModelCommon;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LabZeroOne.Controllers
{
    public class AuthenticationController : Controller
    {
        private ZeroOneContext _zeroOneContext;
        public AuthenticationController(ZeroOneContext zeroOneContext) { 
            _zeroOneContext = zeroOneContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string Signin(string email, string password) { 
            JsonResponseModel<User> res = new JsonResponseModel<User>();
            try
            {
                User targetUser = _zeroOneContext.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
                if (targetUser == null)
                {
                    res.Message = "Email hoặc mật khẩu không chính xác.";
                    res.Status = "WARNING";
                    return JsonConvert.SerializeObject(res);
                }
                else {
                    res.Message = "Thành công";
                    res.Status = "SUCCESS";
                    List<User> lstUser = new List<User>();
                    lstUser.Add(targetUser);
                    res.JsonData = lstUser;
                    return JsonConvert.SerializeObject(res);
                }
            }
            catch (Exception ex) {
                res.Message = "Lỗi " + ex.Message;
                res.Status = "ERROR";
                return JsonConvert.SerializeObject(res);
            }
        }
    }
}
