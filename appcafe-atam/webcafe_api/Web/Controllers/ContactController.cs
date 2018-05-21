using System;
using System.Web.Mvc;
using VD.Data.Entity.MF;
using VD.Lib;
using VD.Lib.DTO;
using VD.Data.IRepository;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using Web.ViewModels.MF;

namespace Web.Controllers
{
    public class ContactController : BaseController
    {
        private IConfigRepository _confRepo;
        private IContactRepository _contactRepo;
        public ContactController(IConfigRepository _confRepo, IContactRepository _contactRepo)
        {
            this._confRepo = _confRepo;
            this._contactRepo = _contactRepo;
        }
        // GET: Contact
        [Route("contact.html")]
        public ActionResult Index()
        {
            //  string test = VD.Lib.myUtils.MemberInfoGetting.GetMemberName(() => vm.conf_google_map);

            var viewmodel = new FrmLienHeView();
            viewmodel.__config = _confRepo.GetConfigCache();
            return View(viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FrmLienHeView vm)
        {
            vm.__config = __config;



            var trueCapt = (Session["Captcha" + "lh"] != null &&
                            Session["Captcha" + "lh"].ToString().ToLower() == vm.Captcha.ToLower());
            if (trueCapt == false)
            {
                ModelState.AddModelError(string.Empty, mui.mui.captcha_fail);
            }

            if (ModelState.IsValid)
            {

                string rs_mes = "";
                vm.NoiDung = myRegex.BoTagScriptAndCSS(vm.NoiDung);



                Contact contact = new Contact();
                contact.InjectFrom(vm);
                contact.CreatedDate = DateTime.Now;
                contact.ModifiedDate = DateTime.Now;
                contact.ContactStatusId = 1; //chua doc
                contact.KetQuaGuiMail = true;

                if (__setting.is_reply_contact)
                {
                    if (!string.IsNullOrWhiteSpace(__setting.etmp_reply_contact) &&
                        !string.IsNullOrWhiteSpace(__setting.etmp_reply_contact_title))
                    {
                        var dic = new Dictionary<string, string>()
                        {
                            {"full_name", vm.HoTen},
                            {"email", vm.Email},
                            {"phone_number", vm.SDT},
                            {"subject", vm.TieuDe},
                            {"content", vm.NoiDung},
                            {"time", DateTime.Now.ToShortDateString()}
                        };

                        string _tieude2 = sendMailObj.ReplaceContent(__setting.etmp_reply_contact_title, dic);
                        string _noidung2 = sendMailObj.ReplaceContent(__setting.etmp_reply_contact, dic);

                        //send to cus
                        var rs1 = _contactRepo.SendEmail(new sendMailObj()
                        {
                            emailNhan = vm.Email,
                            tieude = _tieude2,
                            noidung = _noidung2
                        }, true);
                        //send to adm
                        var rs2 = _contactRepo.SendEmail(new sendMailObj()
                        {
                            tieude = _tieude2,
                            noidung = _noidung2
                        }, true, true);
                        if (rs1.r && rs2.r)
                        {
                            TempData["message"] = "<h2>" + _tieude2 + "</h2>" + _noidung2;
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            contact.KetQuaGuiMail = false;
                            contact.LoiGuiMail = rs1.m + "<br/>" + rs2.m;
                            TempData["message"] = "error: mail servers have problems, please try again later!";
                            return View(vm);
                        }


                    }
                    else
                    {
                        TempData["message"] = "#1: " + mui.mui.contact_success;
                    }
                }
                else
                {
                    TempData["message"] = "#2: " + mui.mui.contact_success;
                }

                _contactRepo.Insert(contact);
                _contactRepo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                string messages = string.Join("; ", ModelState.Values
                                          .SelectMany(x => x.Errors)
                                          .Select(x => x.ErrorMessage));

                TempData["message"] = messages;
            }
            return View(vm);
        }

    }
}