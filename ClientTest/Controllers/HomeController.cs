using System;
using System.Web.Mvc;
using GamerscoinWrapper.Data;
using GamerscoinWrapper.Wrapper;
using GamerscoinWrapper.Wrapper.Interfaces;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBaseBtcConnector _baseBtcConnector;
        private readonly IGamerscoinService _GamerscoinService;

        //
        // GET: /Home/
        public HomeController()
        {
            _baseBtcConnector =  new BaseBtcConnector();
            _GamerscoinService = new GamerscoinService();
        }

        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public Decimal GetBalanceInWallet()
        {
            return _baseBtcConnector.GetBalance();
        }

        [HttpGet]
        public JsonResult GetInformationAboutTransaction(String txId)
        {
            Transaction transaction = _GamerscoinService.GetTransaction(txId);
            return Json(transaction, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetBlockInfo(String blockhashId)
        {
            Block transaction = _baseBtcConnector.GetBlock(blockhashId);
            return Json(transaction, JsonRequestBehavior.AllowGet);
        }
    }
}
