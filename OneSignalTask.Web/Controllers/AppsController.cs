using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OneSignalTask.Core;
using OneSignalTask.Infrastructure;

namespace OneSignalTask.Web.Controllers
{
    public class AppsController : Controller
    {
        private readonly IAppService _appService;
        private readonly IMapper _mapper;
        public AppsController(IAppService appService, IMapper mapper)
        {
            _appService = appService;
            _mapper = mapper;
        }

        // GET: Apps
        [Authorize(Roles = "Admin, DataEntry")]
        public IActionResult Index()
        {
            return View(_appService.GetAllApi());
        }

        // GET: Apps/Details/5
        [Authorize(Roles = "Admin, DataEntry")]
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var app = _appService.GetByIdApi(id);
            if (app == null)
            {
                return NotFound();
            }

            return View(app);
        }

        // GET: Apps/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Apps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(AppInputModel app)
        {
            if (ModelState.IsValid)
            {
                var createdApp = _appService.CreateApi(app);
                _appService.Create(createdApp);
                return RedirectToAction(nameof(Index));
            }
            return View(app);
        }

        // GET: Apps/Edit/5
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var app = _appService.GetByIdApi(id);
            if (app == null)
            {
                return NotFound();
            }
            var mappedApp = _mapper.Map<AppInputModel>(app);
            return View(mappedApp);
        }

        // POST: Apps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string id, AppInputModel app)
        {
            if (id != app.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var result = _appService.UpdateApi(app);
                    if (result != null)
                        _appService.Update(result);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppExists(app.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(app);
        }

        //// GET: Apps/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var app = await _context.Apps
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (app == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(app);
        //}

        //// POST: Apps/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var app = await _context.Apps.FindAsync(id);
        //    _context.Apps.Remove(app);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool AppExists(string id)
        {
            return _appService.IsExist(id);
        }
    }
}
