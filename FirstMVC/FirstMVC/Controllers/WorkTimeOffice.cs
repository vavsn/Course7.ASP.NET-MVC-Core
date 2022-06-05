using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers
{
    public class WorkTimeOffice : Controller
    {
        // GET: WorkTimeOffice
        public ActionResult Index()
        {
            return View();
        }

        // GET: WorkTimeOffice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkTimeOffice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkTimeOffice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkTimeOffice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorkTimeOffice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkTimeOffice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WorkTimeOffice/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
