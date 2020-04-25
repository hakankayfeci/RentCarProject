using RCP.BL;
using RCP.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RCP.UI.Controllers
{
    public class CarsController : Controller
    {
        // GET: Cars
        public ActionResult Cars()
        {
            AdvertRepository advertRepository = new AdvertRepository();
            CarsRepository carsRepository = new CarsRepository();
            CarPhotoRepository carPhotoRepository = new CarPhotoRepository();
            List<AdvertViewModel> advertViews = new List<AdvertViewModel>();
            var result = carsRepository.GetAll();
            var resultadvert = advertRepository.GetAll();
            foreach (var item in result)
            {
                advertViews.Add(new AdvertViewModel {
                    Carss = item,
                    Photo = carPhotoRepository.GetByFilterx(x=>x.CarId==item.Id).Photo
                });
            }
            foreach (var item in resultadvert)
            {
                advertViews.ForEach(x => x.Adverts = item);

            }

            return View(advertViews);
        }

        // POST : Cars
        [HttpPost]
        public ActionResult Cars(int id)
        {
            return View();
        }

        // GET: CarDetail
        public ActionResult CarDetail(int id)
        {
            CarsRepository carsRepository = new CarsRepository();
            var result = carsRepository.GetById(id);
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return View();
            }
        }
        public ActionResult CarGiveOffer()
        {
            return View();
        }
    }
}