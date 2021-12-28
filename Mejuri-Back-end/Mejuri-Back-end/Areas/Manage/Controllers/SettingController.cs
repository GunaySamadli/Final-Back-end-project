using Mejuri_Back_end.Extentions;
using Mejuri_Back_end.Helpers;
using Mejuri_Back_end.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mejuri_Back_end.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("manage")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Edit()
        {
            Setting setting = _context.Settings.FirstOrDefault();
            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Setting setting)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            Setting settingDb = _context.Settings.FirstOrDefault();
            string path = Path.Combine(_env.WebRootPath, "uploads", "setting");

            // Added new setting datas
            if (settingDb == null)
            {
                Setting newSetting = new Setting
                {
                    HomePageInfo = setting.HomePageInfo,
                    LocationTitle = setting.LocationTitle,
                    LocationSubTitle = setting.LocationSubTitle,
                    Fb = setting.Fb,
                    Insta = setting.Insta,
                    Pinterest = setting.Pinterest,
                    Twitter = setting.Twitter,
                    FbUrl = setting.FbUrl,
                    InstaUrl = setting.InstaUrl,
                    PinterestUrl = setting.PinterestUrl,
                    TwitterUrl = setting.TwitterUrl,
                    CopyRight = setting.CopyRight,
                    FaqTitle=setting.FaqTitle,
                    ContactTitle=setting.ContactTitle,
                    ContactSubtitle1=setting.ContactSubtitle1,
                    ContactSubtitle2=setting.ContactSubtitle2
                };
                // Inserted Header Logo

                if (setting.HomePageImgFile == null)
                {
                    ModelState.AddModelError("HomePageImgFile", "HeaderLogo null ola bilmez");
                    return View("Index", setting);
                }
                if (setting.LocationImgFile == null)
                {
                    ModelState.AddModelError("LocationImgFile", "LocationImg null ola bilmez");
                    return View("Index", setting);
                }
                if (setting.ShopImgFile == null)
                {
                    ModelState.AddModelError("ShopImgFile", "ShopImg null ola bilmez");
                    return View("Index", setting);
                }
                if (setting.CompanyImgFile == null)
                {
                    ModelState.AddModelError("CompanyImgFile", "CompanyImg null ola bilmez");
                    return View("Index", setting);
                }
                if (setting.ContactImgFile == null)
                {
                    ModelState.AddModelError("ContactImgFile", "ContactImg null ola bilmez");
                    return View("Index", setting);
                }
                if (setting.FaqImgFile == null)
                {
                    ModelState.AddModelError("FaqImgFile", "FaqImg null ola bilmez");
                    return View("Index", setting);
                }
                if (!setting.HomePageImgFile.CheckContent())
                {
                    ModelState.AddModelError("HomePageImgFile", "Fayl shekil formatinda olmalidir");
                    return View("Index", setting);
                }
                if (setting.HomePageImgFile.CheckSize(200))
                {
                    ModelState.AddModelError("HomePageImgFile", "Faylin olchusu 200kb-dan chox olmamalidi!");
                    return View("Index", setting);
                }

                // Inserted LocationImg 
                if (!setting.LocationImgFile.CheckContent())
                {
                    ModelState.AddModelError("LocationImgFile", "Fayl shekil formatinda olmalidir");
                    return View("Index", setting);
                }
                if (setting.LocationImgFile.CheckSize(200))
                {
                    ModelState.AddModelError("LocationImgFile", "Faylin olchusu 200kb-dan chox olmamalidi!");
                    return View("Index", setting);
                }

                // Inserted ContactImg 
                if (!setting.ContactImgFile.CheckContent())
                {
                    ModelState.AddModelError("ContactImgFile", "Fayl shekil formatinda olmalidir");
                    return View("Index", setting);
                }
                if (setting.LocationImgFile.CheckSize(200))
                {
                    ModelState.AddModelError("ContactImgFile", "Faylin olchusu 200kb-dan chox olmamalidi!");
                    return View("Index", setting);
                }

                // Inserted FaqImg 
                if (!setting.FaqImgFile.CheckContent())
                {
                    ModelState.AddModelError("FaqImgFile", "Fayl shekil formatinda olmalidir");
                    return View("Index", setting);
                }
                if (setting.LocationImgFile.CheckSize(200))
                {
                    ModelState.AddModelError("FaqImgFile", "Faylin olchusu 200kb-dan chox olmamalidi!");
                    return View("Index", setting);
                }

                // Inserted shopImage 
                if (!setting.ShopImgFile.CheckContent())
                {
                    ModelState.AddModelError("LocationImgFile", "Fayl shekil formatinda olmalidir");
                    return View("Index", setting);
                }
                if (setting.ShopImgFile.CheckSize(200))
                {
                    ModelState.AddModelError("LocationImgFile", "Faylin olchusu 200kb-dan chox olmamalidi!");
                    return View("Index", setting);
                }

                // Inserted company Image 
                if (!setting.CompanyImgFile.CheckContent())
                {
                    ModelState.AddModelError("LocationImgFile", "Fayl shekil formatinda olmalidir");
                    return View("Index", setting);
                }
                if (setting.CompanyImgFile.CheckSize(200))
                {
                    ModelState.AddModelError("LocationImgFile", "Faylin olchusu 200kb-dan chox olmamalidi!");
                    return View("Index", setting);
                }

                newSetting.HomePageImg = await setting.HomePageImgFile.SaveImage(path);


                newSetting.LocationImg = await setting.LocationImgFile.SaveImage(path);


                newSetting.ShopImg = await setting.ShopImgFile.SaveImage(path);

                newSetting.CompanyImg = await setting.CompanyImgFile.SaveImage(path);

                newSetting.ContactImg = await setting.CompanyImgFile.SaveImage(path);

                newSetting.FaqImg = await setting.FaqImgFile.SaveImage(path);

                // Added Other Data

                _context.Settings.Add(newSetting);
            }
            // Updated setting datas
            else
            {
                if (setting.HomePageImgFile != null)
                {
                    if (!setting.HomePageImgFile.CheckContent())
                    {
                        ModelState.AddModelError("HomePageImgFile", "Fayl shekil formatinda olmalidir");
                        return View("Index", setting);
                    }
                    if (setting.HomePageImgFile.CheckSize(200))
                    {
                        ModelState.AddModelError("HomePageImgFile", "Faylin olchusu 200kb-dan chox olmamalidi!");
                        return View("Index", setting);
                    }

                    Helper.FileDelete(path, settingDb.HomePageImg);
                    settingDb.HomePageImg = await setting.HomePageImgFile.SaveImage(path);
                }

                if (setting.LocationImgFile != null)
                {
                    if (!setting.LocationImgFile.CheckContent())
                    {
                        ModelState.AddModelError("LocationImgFile", "Fayl shekil formatinda olmalidir");
                        return View("Index", setting);
                    }
                    if (setting.LocationImgFile.CheckSize(200))
                    {
                        ModelState.AddModelError("LocationImgFile", "Faylin olchusu 200kb-dan chox olmamalidi!");
                        return View("Index", setting);
                    }

                    Helper.FileDelete(path, settingDb.LocationImg);
                    settingDb.LocationImg = await setting.LocationImgFile.SaveImage(path);

                }

                if (setting.ShopImgFile != null)
                {
                    if (!setting.ShopImgFile.CheckContent())
                    {
                        ModelState.AddModelError("ShopImgFile", "Fayl shekil formatinda olmalidir");
                        return View("Index", setting);
                    }
                    if (setting.ShopImgFile.CheckSize(200))
                    {
                        ModelState.AddModelError("ShopImgFile", "Faylin olchusu 200kb-dan chox olmamalidi!");
                        return View("Index", setting);
                    }

                    Helper.FileDelete(path, settingDb.ShopImg);
                    settingDb.ShopImg = await setting.ShopImgFile.SaveImage(path);

                }

                if (setting.CompanyImgFile != null)
                {
                    if (!setting.CompanyImgFile.CheckContent())
                    {
                        ModelState.AddModelError("CompanyImgFile", "Fayl shekil formatinda olmalidir");
                        return View("Index", setting);
                    }
                    if (setting.CompanyImgFile.CheckSize(200))
                    {
                        ModelState.AddModelError("CompanyImgFile", "Faylin olchusu 200kb-dan chox olmamalidi!");
                        return View("Index", setting);
                    }

                    Helper.FileDelete(path, settingDb.CompanyImg);
                    settingDb.CompanyImg = await setting.CompanyImgFile.SaveImage(path);

                }
                if (setting.ContactImgFile != null)
                {
                    if (!setting.ContactImgFile.CheckContent())
                    {
                        ModelState.AddModelError("ContactImgFile", "Fayl shekil formatinda olmalidir");
                        return View("Index", setting);
                    }
                    if (setting.CompanyImgFile.CheckSize(200))
                    {
                        ModelState.AddModelError("ContactImgFile", "Faylin olchusu 200kb-dan chox olmamalidi!");
                        return View("Index", setting);
                    }

                    Helper.FileDelete(path, settingDb.ContactImg);
                    settingDb.CompanyImg = await setting.ContactImgFile.SaveImage(path);

                }

                if (setting.FaqImgFile != null)
                {
                    if (!setting.FaqImgFile.CheckContent())
                    {
                        ModelState.AddModelError("FaqImgFile", "Fayl shekil formatinda olmalidir");
                        return View("Index", setting);
                    }
                    if (setting.CompanyImgFile.CheckSize(200))
                    {
                        ModelState.AddModelError("FaqImgFile", "Faylin olchusu 200kb-dan chox olmamalidi!");
                        return View("Index", setting);
                    }

                    Helper.FileDelete(path, settingDb.FaqImg);
                    settingDb.CompanyImg = await setting.FaqImgFile.SaveImage(path);

                }


                settingDb.HomePageInfo = setting.HomePageInfo;
                settingDb.LocationTitle = setting.LocationTitle;
                settingDb.LocationSubTitle = setting.LocationSubTitle;
                settingDb.CopyRight = setting.CopyRight;
                settingDb.Fb = setting.Fb;
                settingDb.FbUrl = setting.FbUrl;
                settingDb.Insta = setting.Insta;
                settingDb.InstaUrl = setting.InstaUrl;
                settingDb.Pinterest = setting.Pinterest;
                settingDb.PinterestUrl = setting.PinterestUrl;
                settingDb.Twitter = setting.Twitter;
                settingDb.TwitterUrl = setting.TwitterUrl;
                settingDb.FaqTitle = setting.FaqTitle;
                settingDb.ContactTitle = setting.ContactTitle;
                settingDb.ContactSubtitle1 = setting.ContactSubtitle1;
                settingDb.ContactSubtitle2 = setting.ContactSubtitle2;
            }

            await _context.SaveChangesAsync();


            return RedirectToAction("index", "dashboard");
        }
    }
}
