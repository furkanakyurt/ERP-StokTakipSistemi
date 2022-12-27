using DaimaProje2.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaimaProje2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            return View(DP.ReturnList<KullaniciModel>("KullaniciListele"));
        }

        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            List<KullaniciModel> li = new List<KullaniciModel>();
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@KullaniciNo", id);
                return View(DP.ReturnList<KullaniciModel>("KullaniciGetir", param).FirstOrDefault<KullaniciModel>());
            }


        }
        [HttpPost]
        public ActionResult EY(KullaniciModel kullanici)
        {
            //View olustururken edit olanı seciyoruz.
            DynamicParameters param = new DynamicParameters();
            param.Add("@KullaniciNo", kullanici.KullaniciNo);
            param.Add("@AdSoyad", kullanici.AdSoyad);
            param.Add("@Email", kullanici.Email);
            param.Add("@Sifre", kullanici.Sifre);
            param.Add("@Rol", kullanici.Rol);


            DP.ExecuteWReturn("KullaniciEY  ", param);
            return RedirectToAction("Index");

        }

        
        public ActionResult Delete(int id=0 )
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@KullaniciNo", id);
            DP.ExecuteWReturn("KullaniciSil", param);
            return RedirectToAction("Index");
        }

        public ActionResult StokIndex()
        {

            return View(DP.ReturnList<StokUrunAd>("StokListele"));
        }

        [HttpGet]
        public ActionResult StokEY(int id = 0)
        {
            List<SelectListItem> deger1 = (from x in DP.ReturnList<UrunModel>("UrunCombobox")
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAdi,
                                               Value = x.UrunNo.ToString()
                                           }).ToList();

            ViewBag.urun = deger1;
            List<StokModel2> li = new List<StokModel2>();
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@StokNo", id);
                return View(DP.ReturnList<StokModel2>("StokGetir", param).FirstOrDefault<StokModel2>());
            }


        }
        [HttpPost]
        public ActionResult StokEY(StokModel2 stok)
        {
            //View olustururken edit olanı seciyoruz.
            DynamicParameters param = new DynamicParameters();
            param.Add("@StokNo", stok.StokNo);
            param.Add("@UrunNo", stok.UrunNo);
            param.Add("@Miktar", stok.Miktar);
            
            DP.ExecuteWReturn("StokEY", param);
            return RedirectToAction("StokIndex");

        }

        public ActionResult StokDelete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@StokNo", id);
            DP.ExecuteWReturn("StokSil", param);
            return RedirectToAction("StokIndex");
        }

        //public ActionResult StokKritikBelirle(int kritikseviye=50)
        //{
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@Min", kritikseviye);
        //    DP.ExecuteWReturn("KritikSeviye", param);
        //    var count = DP.ReturnList<StokUrunAd>("KritikSeviye",param).Count();
        //    ViewBag.count = count;
        //    return  View();

        public ActionResult UrunIndex()
        {

            return View(DP.ReturnList<UrunModel>("UrunListele"));
        }

        [HttpGet]
        public ActionResult UrunEY(int id = 0)
        {
            List<UrunModel> li = new List<UrunModel>();
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UrunNo", id);
                return View(DP.ReturnList<UrunModel>("UrunGetir", param).FirstOrDefault<UrunModel>());
            }


        }
        [HttpPost]
        public ActionResult UrunEY(UrunModel urun)
        {
            //View olustururken edit olanı seciyoruz.
            DynamicParameters param = new DynamicParameters();
            param.Add("@UrunNo", urun.UrunNo);
            param.Add("@UrunAdi", urun.UrunAdi);
            


            DP.ExecuteWReturn("UrunEY  ", param);
            return RedirectToAction("UrunIndex");

        }


        public ActionResult UrunDelete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UrunNo", id);
            DP.ExecuteWReturn("UrunSil", param);
            return RedirectToAction("UrunIndex");
        }
    }

}
