using System.Web.Mvc;
using Omu.ValueInjecter;
using VD.Data.Entity;
using VD.Data.IRepository;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;
using Web.Security;
using VD.Data.Base;
using VD.Lib.Encode;

namespace Web.Areas.Admin.Controllers
{
      [myAuth(Roles = "1")]
    public class SettingController : BaseController
    {
        private ISettingRepository _settingRepo;
        public SettingController(ISettingRepository _settingRepo)
        {
            this._settingRepo = _settingRepo;
        }
        [HttpGet]
        public ActionResult Smtp()
        {
            var entity = _settingRepo.GetEntry(1);
            SettingSmtpVM vm = new SettingSmtpVM();
            vm.InjectFrom(entity);
            return View(vm);
        }
        [HttpPost]
        public ActionResult Smtp(SettingSmtpVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                var entity = _settingRepo.GetEntry(1);
                entity.InjectFrom(viewmodel);
                _settingRepo.Update(entity);
                _settingRepo.Save();
                CacheServ.ClearAll();
                TempData["message"] = "Update setting successfully!";
                return RedirectToAction("Smtp");
            }
            return View(viewmodel);
        }
        #region row per page
        [HttpGet]
        public ActionResult Rpp()
        {
            var entity = _settingRepo.GetEntry(1);
            SettingRppVM vm = new SettingRppVM();
            vm.InjectFrom(entity);
            return View(vm);
        }
        [HttpPost]
        public ActionResult Rpp(SettingRppVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                var entity = _settingRepo.GetEntry(1);
                entity.InjectFrom(viewmodel);
                _settingRepo.Update(entity);
                _settingRepo.Save();
                CacheServ.ClearAll();
                TempData["message"] = "Update setting successfully!";
                return RedirectToAction("Rpp");

            }
            return View(viewmodel);
        }
        #endregion

        #region gia vip
        [HttpGet]
        public ActionResult GiaVip()
        {
            var entity = _settingRepo.GetEntry(1);
            
            GiaVipVM vm = new GiaVipVM();
            vm.InjectFrom(entity);
            return View(vm);
        }
        [HttpPost]
        public ActionResult GiaVip(GiaVipVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                var entity = _settingRepo.GetEntry(1);
                entity.InjectFrom(viewmodel);
                _settingRepo.Update(entity);
                _settingRepo.Save();
                CacheServ.ClearAll();
                TempData["message"] = "Update Giá nâng cấp thành viên VIP successfully!";
                return RedirectToAction("GiaVip");

            }
            return View(viewmodel);
        }
        #endregion


        #region email robot
        [HttpGet]
        public ActionResult EmailRobot()
        {
            SimpleAES __aes = new SimpleAES();
            var entity = _settingRepo.GetEntry(1);
            SettingEmailRobotVM vm = new SettingEmailRobotVM();
            vm.InjectFrom(entity);
            vm.sys_email_robot_pw = __aes.DecryptString(entity.sys_email_robot_pw);
            return View(vm);
        }
        [HttpPost]
        public ActionResult EmailRobot(SettingEmailRobotVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                SimpleAES __aes = new SimpleAES();
                var entity = _settingRepo.GetEntry(1);
                entity.InjectFrom(viewmodel);
                entity.sys_email_robot_pw = __aes.EncryptToString(viewmodel.sys_email_robot_pw);
                _settingRepo.Update(entity);
                _settingRepo.Save();
                CacheServ.ClearAll();
                TempData["message"] = "Update setting successfully!";
                return RedirectToAction("EmailRobot");

            }
            return View(viewmodel);
        }
        #endregion


        #region[Contact email]
        public ActionResult ContactEmail()
        {
            var entity = _settingRepo.GetEntry(1);
            SettingEmailContactVM vm = new SettingEmailContactVM();
            vm.InjectFrom(entity);
            return View(vm);
        }
        [HttpPost]
        public ActionResult ContactEmail(SettingEmailContactVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                var entity = _settingRepo.GetEntry(1);
                entity.InjectFrom(viewmodel);
                _settingRepo.Update(entity);
                _settingRepo.Save();
                CacheServ.ClearAll();
                TempData["message"] = "Update setting successfully!";
                return RedirectToAction("ContactEmail");

            }
            return View(viewmodel);
        }
        #endregion
        #region[ThongBaoDatHang]
        public ActionResult ThongBaoDatHang()
        {
            var entity = _settingRepo.GetEntry(1);
            SettingThongBaoDatHangVM vm = new SettingThongBaoDatHangVM();
            vm.InjectFrom(entity);
            return View(vm);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThongBaoDatHang(SettingThongBaoDatHangVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                var entity = _settingRepo.GetEntry(1);
                entity.InjectFrom(viewmodel);
                _settingRepo.Update(entity);
                _settingRepo.Save();
                CacheServ.ClearAll();
                TempData["message"] = "Update setting successfully!";
                return RedirectToAction("ThongBaoDatHang");

            }
            return View(viewmodel);
        }
        #endregion


        #region[Register]
        public ActionResult EmployerRegister()
        {
            var entity = _settingRepo.GetEntry(1);
            SettingEmployerRegisterVM vm = new SettingEmployerRegisterVM();
            vm.InjectFrom(entity);
            return View(vm);
        }
        [HttpPost]
        public ActionResult EmployerRegister(SettingEmployerRegisterVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                var entity = _settingRepo.GetEntry(1);
                entity.InjectFrom(viewmodel);
                _settingRepo.Update(entity);
                _settingRepo.Save();
                CacheServ.ClearAll();
                TempData["message"] = "Update setting successfully!";
                return RedirectToAction("EmployerRegister");

            }
            return View(viewmodel);
        }


        public ActionResult EmployerRegisterSendAdmin()
        {
            var entity = _settingRepo.GetEntry(1);
            SettingEmployerRegisterSendAdminVM vm = new SettingEmployerRegisterSendAdminVM();
            vm.InjectFrom(entity);
            return View(vm);
        }
        [HttpPost]
        public ActionResult EmployerRegisterSendAdmin(SettingEmployerRegisterSendAdminVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                var entity = _settingRepo.GetEntry(1);
                entity.InjectFrom(viewmodel);
                _settingRepo.Update(entity);
                _settingRepo.Save();
                CacheServ.ClearAll();
                TempData["message"] = "Update setting successfully!";
                return RedirectToAction("EmployerRegisterSendAdmin");

            }
            return View(viewmodel);
        }


        public ActionResult CandidateRegister()
        {
            var entity = _settingRepo.GetEntry(1);
            SettingCadidateRegisterVM vm = new SettingCadidateRegisterVM();
            vm.InjectFrom(entity);
            return View(vm);
        }
        [HttpPost]
        public ActionResult CandidateRegister(SettingCadidateRegisterVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                var entity = _settingRepo.GetEntry(1);
                entity.InjectFrom(viewmodel);
                _settingRepo.Update(entity);
                _settingRepo.Save();
                CacheServ.ClearAll();
                TempData["message"] = "Update setting successfully!";
                return RedirectToAction("CandidateRegister");

            }
            return View(viewmodel);
        }

        public ActionResult CandidateRegisterSendAdmin()
        {
            var entity = _settingRepo.GetEntry(1);
            SettingCadidateRegisterSendAdminVM vm = new SettingCadidateRegisterSendAdminVM();
            vm.InjectFrom(entity);
            return View(vm);
        }
        [HttpPost]
        public ActionResult CandidateRegisterSendAdmin(SettingCadidateRegisterSendAdminVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                var entity = _settingRepo.GetEntry(1);
                entity.InjectFrom(viewmodel);
                _settingRepo.Update(entity);
                _settingRepo.Save();
                CacheServ.ClearAll();
                TempData["message"] = "Update setting successfully!";
                return RedirectToAction("CandidateRegisterSendAdmin");

            }
            return View(viewmodel);
        }
        #endregion

        #region score rules
        [HttpGet]
        public ActionResult FeeScore()
        {
            var entity = _settingRepo.GetEntry(1);
            SettingFeeScoreVM vm = new SettingFeeScoreVM();
            vm.InjectFrom(entity);
            return View(vm);
        }
        [HttpPost]
        public ActionResult FeeScore(SettingFeeScoreVM viewmodel)
        {
            
            if (ModelState.IsValid)
            {
                var entity = _settingRepo.GetEntry(1);
                entity.InjectFrom(viewmodel);
                _settingRepo.Update(entity);
                _settingRepo.Save();
                CacheServ.ClearAll();
                TempData["message"] = "Update setting successfully!";
                return RedirectToAction("FeeScore");

            }
            return View(viewmodel);
        }
        #endregion



        public ActionResult PurchaseWallet()
        {
            var entity = _settingRepo.GetEntry(1);
            SettingPurchaseWalletVM vm = new SettingPurchaseWalletVM();
            vm.InjectFrom(entity);
            return View(vm);
        }
        [HttpPost]
        public ActionResult PurchaseWallet(SettingPurchaseWalletVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                var entity = _settingRepo.GetEntry(1);
                entity.InjectFrom(viewmodel);
                _settingRepo.Update(entity);
                _settingRepo.Save();
                CacheServ.ClearAll();
                TempData["message"] = "Update setting successfully!";
                return RedirectToAction("PurchaseWallet");

            }
            return View(viewmodel);
        }

        public ActionResult StatisticsJobsAndCV()
        {
            var entity = _settingRepo.GetEntry(1);
            SettingStatisticsJobsAndCVVM vm = new SettingStatisticsJobsAndCVVM();
            vm.InjectFrom(entity);
            return View(vm);
        }
        [HttpPost]
        public ActionResult StatisticsJobsAndCV(SettingStatisticsJobsAndCVVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                var entity = _settingRepo.GetEntry(1);
                entity.InjectFrom(viewmodel);
                _settingRepo.Update(entity);
                _settingRepo.Save();
                CacheServ.ClearAll();
                TempData["message"] = "Update setting successfully!";
                return RedirectToAction("StatisticsJobsAndCV");

            }
            return View(viewmodel);
        }
        
    }
}