using System.Text;
using LabZeroOne.Data;
using LabZeroOne.Models.RequestModel;
using LabZeroOne.Models.ResponseModelCommon;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography;

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
                string decode = HashPassword(password);
                User targetUser = _zeroOneContext.Users.Where(x => x.Email == email && x.Password == decode).FirstOrDefault();
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

        [HttpPost]
        public string Registration([FromBody] ReqRegistration req) {
            JsonResponseModel<string> res = new JsonResponseModel<string>();
            try
            {
                User checkUser = _zeroOneContext.Users.Where(x => x.Email == req.Email).FirstOrDefault();
                if (checkUser != null)
                {
                    res.Message = "Email đã được dùng để tạo tài khoản";
                    res.Status = "WARNING";
                    return JsonConvert.SerializeObject(res);
                }
                else { 
                    User newitem = new User();
                    newitem.Email = req.Email;
                    newitem.UserName = req.UserName;
                    newitem.Password = HashPassword(req.Password);
                    newitem.PhoneNumber = req.PhoneNumber;
                    newitem.RoleId = 2;
                    _zeroOneContext.Users.Add(newitem);
                    _zeroOneContext.SaveChanges();

                    res.Message = "Tạo tài khoản thành công";
                    res.Status = "SUCCESS";
                    return JsonConvert.SerializeObject(res);
                }
            }
            catch (Exception ex) {
                res.Message = "Lỗi " + ex.Message;
                res.Status = "ERROR";
                return JsonConvert.SerializeObject(res);
            }
        }


        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte byteValue in data)
                {
                    sb.Append(byteValue.ToString("x2"));
                }
                return sb.ToString();
            }
        }


    }
}
