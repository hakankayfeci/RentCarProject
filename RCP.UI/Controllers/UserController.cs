using RCP.BL;
using RCP.Model;
using RCP.UI.Filters;
using RCP.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RCP.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }
        // GET: Profile
        [AdminFilter]
        public ActionResult Profile()
        {
            User user = (User)Session["LoginUser"];
            UserRepository userRepository = new UserRepository();
            var userr = userRepository.GetByFilter(x => x.Id == user.Id).FirstOrDefault();
            TempData["Mesaj"] = null;
            return View(userr);
        }
        // GET: ForgetPassword
        public ActionResult ForgetPassword()
        {
            return View();
        }
        [AdminFilter]
        [HttpPost]
        public ActionResult Profile(User model)
        {
            User user = (User)Session["LoginUser"];
            UserRepository userRepository = new UserRepository();
            var userr = userRepository.GetByFilter(x => x.Id == user.Id).FirstOrDefault();
            var resultuser = userRepository.UpdateUser(new User
            {
                Id=userr.Id,
                Name = model.Name,
                Surname = model.Surname,
                Password = model.Password,
                Email = model.Email,
                Phone = model.Phone,
                Username = model.Username,
                IsDelete=false,
                RegisterDate=DateTime.Now
            });
            TempData["Mesaj"] = resultuser ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Kullanıcı bilgileriniz güncelendi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Kayıt güncellenemedi bilgilerini kontrol et." } };
            return View(model);
            
        }

        // Post : Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            UserRepository repo = new UserRepository();
            var user = repo.Login(model.Email,model.Password,model.Username);
            if (user != null)
            {
                //
                Session["LoginUser"] = user;
                return Redirect("http://localhost:51155/Anasayfa");
            }
            else
            {
                TempData["Mesaj"] = new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Kullanıcı Adı veya şifre hatalı!" } };
                return View();
            }
        }
        // Post : Register
        [HttpPost]
        public ActionResult Register(User model)
        {
            UserRepository repo = new UserRepository();
            RoleRepository rolRepo = new RoleRepository();
            bool result = repo.Add(new User { Name = model.Name, Password = model.Password, Surname = model.Surname, Email = model.Email, IsDelete = false, RegisterDate = DateTime.Now, Username=model.Username });
            var userId = repo.GetByFilter(x => x.Email == model.Email).FirstOrDefault().Id;
            var roleId = rolRepo.GetByFilter(x => x.RoleName == "Admin").FirstOrDefault().Id;
            repo.AddRole(userId, roleId);
            TempData["Mesaj"] = result ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Kayıt başarıyla eklendi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Kayıt eklenemedi bilgilerini kontrol et." } };
            return Redirect("http://localhost:51155/Kayitol");
        }
        // POST: ForgetPassword
        [HttpPost]
        public ActionResult ForgetPassword(string email)
        {
            UserRepository repo = new UserRepository();
            var user = repo.GetByFilter(x => x.Email == email).FirstOrDefault();
            TempData["Mesaj"] = user != null ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Şifreniz Mailinize Gönderildi" } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Böyle Bir E-Posta Bulunamadı bilgilerini kontrol et." } };

            MailMessage _mm = new MailMessage();
            _mm.SubjectEncoding = Encoding.Default;
            _mm.Subject = "Şifremi Unuttum - Cardoor";
            _mm.BodyEncoding = Encoding.Default;
            _mm.Body = "Merhabalar"+user.Name+"\n Şifreniz :"+user.Password +"\n Şifrenizi Kolay Hatırlanabilir Bir şifre koymanızı Tercih Ederiz \n \n \n İyi Günler Dileriz..";

            _mm.From = new MailAddress(ConfigurationManager.AppSettings["emailAccount"]);
            _mm.To.Add(email);


            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.Host = ConfigurationManager.AppSettings["emailHost"];
            _smtpClient.Port = int.Parse(ConfigurationManager.AppSettings["emailPort"]);
            _smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailAccount"], ConfigurationManager.AppSettings["emailPassword"]);
            _smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["emailSLLEnable"]);

            _smtpClient.Send(_mm);
            return View();
        }
    }
}