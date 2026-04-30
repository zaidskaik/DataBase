using DataBase.database;
using DataBase.Migrations;
using DataBase.Models;
using DataBase.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly Connect _context;
        public EquipmentController(Connect _context)
        {
            this._context = _context;
        } 
        //"Hey system, when you run EquipmentController, bring a copy of the Connect database and put it in my _context bag so I can use it to fetch or modify data."
        public async Task<IActionResult> Index()
        {
            var equipment = await _context.EquipmentTable.ToListAsync();
            var equipmentv = equipment.Select(p => new EquipmentView { Id = p.Id, Name = p.Name, price = p.price }).ToList();
            return View(equipmentv);
            /*in the first line we bring all rows on DB & convert it to list
            the second we select what we want to show to user and we send it on 
            EquipmentView to security to db class */
            
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Create(EquipmentView view)
        {
            if(ModelState.IsValid)
            {
                // this is for convert data from view which user fill data on it
                Equipment1 equipment= new Equipment1() { Name= view.Name, price= view.price };
                await _context.EquipmentTable.AddAsync(equipment);
                /*here we define object equipment from DB class Equipment1 and fill the data
                 * coming from user on it and add it to the table on context*/ 
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(); /* this return will make the user on the same page
                            if the IsValid not verified */
        }

        public async Task<IActionResult>Edit(int id)
        {
            var exist= await _context.EquipmentTable.FindAsync(id);
            /* here we tell DB to search about item with his id*/
            if (exist == null)
                return NotFound();
            var equipment = new EquipmentView
            {
                Id = exist.Id,
                Name = exist.Name,
                price = exist.price
                /* here we create object equipment to trans data from db to edit page*/
            };
            return View(equipment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(EquipmentView view)
        {  if (ModelState.IsValid)
            {
                var equipment= await _context.EquipmentTable.FindAsync(view.Id);
                if (equipment == null)
                    return NotFound();
                equipment.Id=view.Id;
                equipment.Name=view.Name;
                equipment.price=view.price;
                /* here we save the data the user modify it on db class */
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult>Delete(int id)
        {
            var exist = await _context.EquipmentTable.FindAsync(id);
            if(exist == null)
                return NotFound();
            var equipment = new EquipmentView
            {
                Id = exist.Id,
                Name = exist.Name,
                price = exist.price
            };
            return View(equipment);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>confirmDelete(int id)
        {
            var exist = await _context.EquipmentTable.FindAsync(id);
            if (exist == null)
                return NotFound();
            _context.EquipmentTable.Remove(exist);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
