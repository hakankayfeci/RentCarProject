using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RCP.BL;
using RCP.UI.Filters;
using RCP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using RCP.UI.ViewModel;
using RCP.UI.Model;
using RCP.UI.Helper;

namespace RCP.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [AdminFilter]
        public ActionResult Dashboard()
        {
            return View();
        }
        [AdminFilter]
        // GET: Car
        public ActionResult CarAdd()
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
            return View();
        }

        [AdminFilter]
        [HttpPost]
        public ActionResult CarAdd(FormCollection model)
        {
            User user = (User)Session["LoginUser"];
            CarsRepository carsRepository = new CarsRepository();
            CarPhotoRepository photoRepository = new CarPhotoRepository();
            var resultcar = carsRepository.Add(new RCP.Model.Cars
            {
                UserId = user.Id,
                Brand = model["Brand"],
                Price = Convert.ToInt32(model["Price"]),
                Sherry = model["Sherry"],
                CarPlate = model["CarPlate"],
                CaseType = model["CaseType"],
                Color = model["Color"],
                Engine = model["Engine"],
                EnginePower = model["EnginePower"],
                Fuel = model["Fuel"],
                Gear = model["Gear"],
                IsDelete = false,
                Km = Convert.ToInt32(model["Km"]),
                Model = model["Model"],
                RegisterDate = DateTime.Now,
                Traction = model["Traction"],
                Waranty = model["Waranty"] == "1" ? true : false,
                Year = Convert.ToDateTime(model["Year"])
            });
            float deger = Convert.ToInt32(model["Km"]);
            var result = carsRepository.GetByFilter(x => x.UserId == user.Id && x.Km == deger).FirstOrDefault();
            photoRepository.Add(new RCP.Model.CarPhoto
            {
                Photo = model["Photo"],
                CarId = result.Id,
                IsDelete=false,
                RegisterDate=DateTime.Now
            });
            JsonData jsondot = new JsonData();
            string json = jsondot.data;
            List<Brand> jsonRequest = JsonConvert.DeserializeObject<List<Brand>>(json);
            // Gelen Değeri Modele Aktardım
            List<Brand> brand = jsonRequest;
            List<string> marka = new List<string>();
            foreach (var item in brand)
            {
                marka.Add(item.BrandName);
            }
            ViewBag.Markalar = marka;
            TempData["Mesaj"] = resultcar ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Kayıt başarıyla eklendi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Kayıt eklenemedi bilgilerini kontrol et." } };
            return View();
        }
        [AdminFilter]
        //Get CarList
        public ActionResult CarList()
        {
            CarsRepository carRepository = new CarsRepository();
            User user = (User)Session["LoginUser"];
            return View(carRepository.GetByFilter(x => x.UserId == user.Id));
    

        }
        [AdminFilter]
        // Get CarDelete
        public ActionResult CarDelete(int id)
        {
            CarsRepository carRepository = new CarsRepository();
            carRepository.DeleteById(id);
            return View(carRepository.GetById(id));
        }
        [AdminFilter]
        //Get CarUpdate
        public ActionResult CarUpdate(int id)
        {
            User user = (User)Session["LoginUser"];

            CarsRepository carRepository = new CarsRepository();
            CarPhotoRepository carPhotoRepository = new CarPhotoRepository();
            var result = carRepository.GetByFilter(x => x.UserId == user.Id && x.Id == id).FirstOrDefault();
            var photoresult = carPhotoRepository.GetByFilter(x => x.CarId == id).FirstOrDefault();
            CarViewModel carView = new CarViewModel();
            carView.Id = id;
            carView.Brand = result.Brand;
            carView.CarPlate = result.CarPlate;
            carView.CaseType = result.CaseType;
            carView.Color = result.Color;
            carView.Engine = result.Engine;
            carView.EnginePower = result.EnginePower;
            carView.Fuel = result.Fuel;
            carView.Gear = result.Gear;
            carView.Km = result.Km;
            carView.Model = result.Model;
            carView.Photo = photoresult.Photo;
            carView.Price = result.Price;
            carView.Sherry = result.Sherry;
            carView.Traction = result.Traction;
            carView.Waranty = result.Waranty;
            carView.Year = result.Year;
            return View();
        }
        [AdminFilter]
        [HttpPost]
        public ActionResult CarUpdate(CarViewModel model)
        {
            User user = (User)Session["LoginUser"];
            CarsRepository carsRepository = new CarsRepository();
            CarPhotoRepository carPhotoRepository = new CarPhotoRepository();
            var result = carsRepository.GetByFilter(x => x.UserId == user.Id && x.Id == model.Id).FirstOrDefault();
            var resultcar = carsRepository.UpdateCar(new Cars
            {
                Id = result.Id,
                Brand = result.Brand,
                CarPlate = result.CarPlate,
                CaseType = result.CaseType,
                Color = result.Color,
                Engine = result.Engine,
                EnginePower = result.EnginePower,
                Fuel = result.Fuel,
                Gear = result.Gear,
                Km = result.Km,
                Model = result.Model,
                Price = result.Price,
                Sherry = result.Sherry,
                Traction = result.Traction,
                Waranty = result.Waranty,
                Year = result.Year,
                RegisterDate=DateTime.Now,
                IsDelete=false

            });
            var carphotoresult = carPhotoRepository.GetByFilter(x => x.CarId == result.Id).FirstOrDefault();
            carPhotoRepository.UpdateCarPhoto(new CarPhoto
            {
                Id = carphotoresult.Id,
                CarId = result.Id,
                Photo=model.Photo
                
            });


            TempData["Mesaj"] = resultcar ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Kayıt başarıyla güncellendi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Kayıt güncellenemedi bilgilerini kontrol et." } };
            return View();
        }
        [AdminFilter]
        // Get BlogAdd
        public ActionResult BlogAdd()
        {
            return View();
        }
        [AdminFilter]
        // Get BlogUpdate
        public ActionResult BlogUpdate(int id)
        {
            User user = (User)Session["LoginUser"];

            BlogRepository blogRepository = new BlogRepository();
            BlogPhotoRepository blogPhotoRepository = new BlogPhotoRepository();
            var result = blogRepository.GetByFilter(x => x.UserId == user.Id && x.Id == id).FirstOrDefault();
            var photoresult = blogPhotoRepository.GetByFilter(x => x.BlogId == id).FirstOrDefault();
            BlogViewModel blogView = new BlogViewModel();
            blogView.Id = id;
            blogView.Photo = photoresult.Photo;
            blogView.Star = result.Star;
            blogView.Title = result.Title;
            blogView.Content = result.Content;
            return View();
        }
        [AdminFilter]
        [HttpPost]
        public ActionResult BlogUpdate(BlogViewModel model)
        {
            User user = (User)Session["LoginUser"];
            BlogRepository blogRepository = new BlogRepository();
            BlogPhotoRepository blogPhotoRepository = new BlogPhotoRepository();
            var result = blogRepository.GetByFilter(x => x.UserId == user.Id && x.Id == model.Id).FirstOrDefault();
            var resultblog = blogRepository.UpdateBlog(new Blog
            {
                Id = result.Id,
                Content = model.Content,
                Star = model.Star,
                UserId = user.Id,
                Title = model.Title,
                RegisterDate = DateTime.Now,
                IsDelete = false
            });
            var blogphotoresult = blogPhotoRepository.GetByFilter(x => x.BlogId == result.Id).FirstOrDefault();
            blogPhotoRepository.UpdateBlogPhoto(new BlogPhoto
            {
                Id = blogphotoresult.Id,
                BlogId = result.Id,
                Photo = model.Photo
            });

            TempData["Mesaj"] = resultblog ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Kayıt başarıyla güncellendi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Kayıt güncellenemedi bilgilerini kontrol et." } };
            return View();
        }
        [AdminFilter]
        // Get BlogList
        public ActionResult BlogList()
        {
            BlogRepository blogRepository = new BlogRepository();
            User user = (User)Session["LoginUser"];
            return View(blogRepository.GetByFilter(x => x.UserId == user.Id));
        }
        [AdminFilter]
        // Get BlogDelete
        public ActionResult BlogDelete(int id)
        {
            BlogRepository blogRepository = new BlogRepository();
            blogRepository.DeleteById(id);
            return View(blogRepository.GetById(id));
        }

        [AdminFilter]
        [HttpPost]
        public ActionResult BlogAdd(BlogViewModel model)
        {
            User user = (User)Session["LoginUser"];
            BlogRepository blogRepository = new BlogRepository();
            BlogPhotoRepository blogPhotoRepository = new BlogPhotoRepository();
            var resultblog = blogRepository.Add(new Blog
            {
                Content = model.Content,
                Star = model.Star,
                UserId = user.Id,
                Title = model.Title,
                RegisterDate = DateTime.Now,
                IsDelete = false
            });
            var blogresult = blogRepository.GetByFilter(x => x.Title == model.Title && x.UserId == user.Id).FirstOrDefault();
            blogPhotoRepository.Add(new BlogPhoto
            {
                BlogId = blogresult.Id,
                IsDelete = false,
                Photo = model.Photo,
                RegisterDate = DateTime.Now
            });

            TempData["Mesaj"] = resultblog ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Kayıt başarıyla eklendi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Kayıt eklenemedi bilgilerini kontrol et." } };
            return View();
        }
        [AdminFilter]
        // Get AdvertAdd
        public ActionResult AdvertAdd()
        {
            User user = (User)Session["LoginUser"];
            CarsRepository carsRepository = new CarsRepository();
            ViewBag.Araba = carsRepository.GetByFilter(x => x.UserId == user.Id);
            return View();
        }


        [AdminFilter]
        [HttpPost]
        // POST AdvertAdd
        public ActionResult AdvertAdd(AdvertViewModel model)
        {
            AdvertRepository advertRepository = new AdvertRepository();
            CarsRepository carsRepository = new CarsRepository();
            Random rnd = new Random();
            string deger = null;
            for (int i = 0; i < 4; i++)
            {
                var sayi = rnd.Next(0, 9);
                deger += sayi.ToString();
            }
            var advertn = Convert.ToInt16(deger);
            var result = advertRepository.GetByFilter(x => x.AdvertNo != advertn);

            var saveresult = advertRepository.Add(model.Adverts);
            TempData["Mesaj"] = saveresult ? new TempDataDictionary { { "class", "alert-success" }, { "Msg", "Kayıt başarıyla eklendi." } } : new TempDataDictionary { { "class", "alert-danger" }, { "Msg", "Kayıt eklenemedi bilgilerini kontrol et." } };
            return Redirect("ilanlar");
        }


        //[HttpPost]
        //public JsonResult MarkaModel(string Markaismi, string tip)
        //{
        //    JsonData jsondot = new JsonData();
        //    string json = jsondot.data;
        //    var client = new HttpClient();
        //    List<Brand> jsonRequest = JsonConvert.DeserializeObject<List<Brand>>(json);
        //    // Gelen Değeri Modele Aktardım
        //    List<Brand> marka = new List<Brand>();
        //    List<Brand> brand = jsonRequest;

        //    List<SelectListItem> sonuc = new List<SelectListItem>();
        //    //bu işlem başarılı bir şekilde gerçekleşti mi onun kontrolunnü yapıyorum
        //    bool basariliMi = true;
        //    try
        //    {
        //        switch (tip)
        //        {
        //            case "MarkaGetir":
        //                //veritabanımızdaki iller tablomuzdan illerimizi sonuc değişkenimze atıyoruz
                        
        //                foreach (var item in brand)
        //                {
        //                    sonuc.Add(new SelectListItem
        //                    {
        //                        Text = item.BrandName,
        //                        Value= item.Brandid.ToString()
        //                    });
        //                }
        //                break;
        //            case "ModelGetir":
        //                //ilcelerimizi getireceğiz ilimizi selecten seçilen ilID sine göre 
        //                foreach (var item in brand.Where(x=>x.BrandName==Markaismi))
        //                {
        //                    foreach (var itemx in item.ModelName)
        //                    {
        //                        sonuc.Add(new SelectListItem
        //                        {
        //                            Text = itemx.ModelName,
        //                            Value = itemx.ModelId.ToString()
        //                        });
        //                    }
                           
        //                }
        //                break;

        //            default:
        //                break;

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //hata ile karşılaşırsak buraya düşüyor
        //        basariliMi = false;
        //        sonuc = new List<SelectListItem>();
        //        sonuc.Add(new SelectListItem
        //        {
        //            Text = "Bir hata oluştu :(",
        //            Value = "Default"
        //        });

        //    }
        //    //Oluşturduğum sonucları json olarak geriye gönderiyorum
        //    return Json(new { ok = basariliMi, text = sonuc });
        //}

    }
}