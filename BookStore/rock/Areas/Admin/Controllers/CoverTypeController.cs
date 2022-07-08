#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rock.Data;
using rock.DataAccess.Repository.IRepository;
using rock.Models;

namespace rock.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/CoverType
        public IActionResult Index()
        {

            IEnumerable<CoverType> objCoverTypelist = _unitOfWork.coverType.GetAll();
            return View(objCoverTypelist);

        }

        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {

            if (ModelState.IsValid)
            {

                _unitOfWork.coverType.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Success";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.categories.Find(id);
            var categoryFromDbFirst = _unitOfWork.coverType.GetFirstOrDefault(u => u.Id == id);

            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.coverType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Success";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // var categoryFromDb = _db.categories.Find(id);
            var covertypeFromDbFirst = _unitOfWork.coverType.GetFirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (covertypeFromDbFirst == null)
            {
                return NotFound();
            }

            return View(covertypeFromDbFirst);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.categories.Find(id);
            var covertypeFromDbFirst = _unitOfWork.coverType.GetFirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (covertypeFromDbFirst == null)
            {
                return NotFound();
            }

            return View(covertypeFromDbFirst);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.coverType.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.coverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Success";
            return RedirectToAction("Index");

        }

    }
}

