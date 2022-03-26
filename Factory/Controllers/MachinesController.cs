using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class MachiensController : Controller
  {
    private readonly FactoryContext _db;

    public MachiensController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      var thisItem = _db.EngineerMachiens
        .Include(join => join.Machiens)
        .Include(join => join.Engineers);
    return View(thisItem);
    }

    public ActionResult Create()
    {
      ViewBag.EningeerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machien machien, int EngineerId)
    {
      _db.Machiens.Add(machien);
      _db.SaveChanges();
      if (EngineerId != 0)
    {
        _db.EngineerMachiens.Add(new EngineerMachiens() { EngineerId = EngineerId, MachienId = machien.MachienId });
        _db.SaveChanges();
    }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisItem = _db.Machiens
        .Include(item => item.JoinEntities)
        .ThenInclude(join => join.Engineers)
        .FirstOrDefault(machien => machien.MachienId == id);
    return View(thisItem);
    }
    public ActionResult Edit(int id)
    {
      var thisMachien = _db.Machiens.FirstOrDefault(machien => machien.MachienId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
      return View(thisMachien);
    }

    [HttpPost]
    public ActionResult Edit(Machien machien, int EngineerId)
     {
      bool duplicate = _db.EngineerMachiens.Any(join => 
        join.EngineerId == EngineertId && join.MachienId == machien.MachienId);

      if (EngineerId != 0 && !duplicate)
      {
        _db.EngineerMachiens.Add(new EngineerMachiens() { EngineerId = EngineerId, MachienId = machien.MachienId });
      }
      _db.Entry(machien).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisMachien = _db.Machiens.FirstOrDefault(machien => machien.MachienId == id);
      return View(thisMachien);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachien = _db.Machiens.FirstOrDefault(machien => machien.MachienId == id);
      _db.Machiens.Remove(thisMachien);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

[HttpPost, ActionName("DeleteEngineer")]
public ActionResult DeleteEngineer(int joinId)
{
    var joinEntry = _db.EngineerMachiens.FirstOrDefault(entry => entry.EngineerMachiensId == joinId);
    _db.EngineerMachiens.Remove(joinEntry);
    _db.SaveChanges();
    return RedirectToAction("Index");
}

    public ActionResult AddEngineer(int id)
{
    var thisMachien = _db.Machiens.FirstOrDefault(machien => machien.MachienId == id);
    ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
    return View(thisMachien);
}

[HttpPost]
public ActionResult AddEngineer(Machien machien, int EngineerId)
{
    if (EngineerId != 0)
    {
      _db.EngineerMachiens.Add(new EngineerMachiens() { EngineerId = EngineerId, MachienId = machien.MachienId });
      _db.SaveChanges();
    }
    return RedirectToAction("Index");
}
  }
}