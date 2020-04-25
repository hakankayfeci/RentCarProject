using Newtonsoft.Json;
using RCP.BL;
using RCP.Model;
using RCP.UI.Helper;
using RCP.UI.Model;
using RCP.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RCP.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
           
            JsonData jsondot = new JsonData();
            string json = jsondot.data;
            using (var client = new HttpClient())
            {
                List<Brand> jsonRequest = JsonConvert.DeserializeObject<List<Brand>>(json);
                // Gelen Değeri Modele Aktardım
                List<Brand> brand = jsonRequest;
                List<string> marka = new List<string>();
                foreach (var item in brand)
                {
                    marka.Add(item.BrandName);
                }
                ViewBag.Markalar = marka;
            }

            BlogRepository blogRepository = new BlogRepository();
            BlogPhotoRepository blogPhotoRepository = new BlogPhotoRepository();
            BlogCommentRepository blogCommentRepository = new BlogCommentRepository();
            UserRepository userRepository = new UserRepository();

            List<BlogViewModel> blogView = new List<BlogViewModel>();
            var blogresult = blogRepository.GetAll();
            var blogphotoresult = blogPhotoRepository.GetAll();
            var blogcommentresult = blogCommentRepository.GetAll();

            foreach (var item in blogresult)
            {
                blogView.Add(new BlogViewModel
                {
                    Id = item.Id,
                    Content = item.Content,
                    Star = item.Star,
                    Title = item.Title,
                    RegisterDate = item.RegisterDate,
                    UserId = item.UserId,
                    Users = userRepository.GetById(item.UserId),
                });
            }

            foreach (var item in blogphotoresult)
            {
                blogView.ForEach(x => x.Photo = item.Photo);
            }
            ViewData["Blog"] = blogView;
            return View();
        }
        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact model)
        {
            MailMessage _mm = new MailMessage();
            _mm.SubjectEncoding = Encoding.Default;
            _mm.Subject = model.Title;
            _mm.BodyEncoding = Encoding.Default;
            _mm.Body = "Maili Gönderen : "+ model.Email + "\n" +model.Message;

            _mm.From = new MailAddress(ConfigurationManager.AppSettings["emailAccount"]);
            _mm.To.Add("cardoor2019@outlook.com");


            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.Host = ConfigurationManager.AppSettings["emailHost"];
            _smtpClient.Port = int.Parse(ConfigurationManager.AppSettings["emailPort"]);
            _smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailAccount"], ConfigurationManager.AppSettings["emailPassword"]);
            _smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["emailSLLEnable"]);

            _smtpClient.Send(_mm);

            TempData["Success"] = "Teşekürler en kısa zamanda tarafınıza dönüş yapılacaktır.";

            return RedirectToAction("Contact");
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
    }
}