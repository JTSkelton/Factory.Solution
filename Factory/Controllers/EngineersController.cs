using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Engineer> model = _db.Engineers.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.MachienId = new SelectList(_db.Machiens, "MachienId", "MachienName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisEngineer = _db.Engineers
        .Include(engineer => engineer.JoinEntities)
        .ThenInclude(join => join.Machiens)
        .FirstOrDefault(engineer => engineer.EngineerId == id);
    return View(thisEngineer);
    }

    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      ViewBag.MachienId = new SelectList(_db.Machiens, "MachienId", "MachienName");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisStylist = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      _db.Engineers.Remove(thisStylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
public ActionResult DeleteMachine(int joinId)
{
    var joinEntry = _db.EngineerMachiens.FirstOrDefault(entry => entry.EngineerMachiensId == joinId);
    _db.EngineerMachiens.Remove(joinEntry);
    _db.SaveChanges();
    return RedirectToAction("Index");
}

    public ActionResult AddMachine(int id)
{
    var thisMachien = _db.Engineers.FirstOrDefault(machien => machien.EngineerId == id);
    ViewBag.MachienId = new SelectList(_db.Machiens, "MachienId", "MachienName");
    return View(thisMachien);
}

[HttpPost]
public ActionResult AddMachine(Engineer engineer, int MachienId)
{
    if (MachienId != 0)
    {
      _db.EngineerMachiens.Add(new EngineerMachiens() { MachienId = MachienId, EngineerId = engineer.EngineerId });
      _db.SaveChanges();
    }
    return RedirectToAction("Index");
}
  }
}