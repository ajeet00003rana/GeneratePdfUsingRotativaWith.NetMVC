using Rotativa;
using System;
using System.Web.Mvc;

namespace GeneratePdfFromView.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// Reference from below url
        /// https://www.c-sharpcorner.com/article/export-pdf-from-html-in-mvc-net4/
        /// </summary>
        /// <returns></returns>
        public ActionResult GenerateReceipt()
        {
            var receipt = new PaymentReceiptViewModel
            {
                ReceiptNumber = "RCT123456",
                PaymentDate = DateTime.Now,
                AmountPaid = 100.00m,
                CustomerName = "John Doe"
            };

            return View(receipt);
        }
        public ActionResult DownloadReceipt()
        {
            var receipt = new PaymentReceiptViewModel
            {
                ReceiptNumber = "RCT123456",
                PaymentDate = DateTime.Now,
                AmountPaid = 100.00m,
                CustomerName = "John Doe"
            };

            return new PartialViewAsPdf("GenerateReceipt", receipt)
            {
                FileName = "PaymentReceipt.pdf",
                PageSize = Rotativa.Options.Size.A4,
                PageOrientation = Rotativa.Options.Orientation.Portrait,
            };
        }

    }

    public class PaymentReceiptViewModel
    {
        public string ReceiptNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string CustomerName { get; set; }
    }
}