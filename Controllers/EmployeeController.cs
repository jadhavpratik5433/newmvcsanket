using aspMVCproject.Data;
using aspMVCproject.Models;
using aspMVCproject.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspMVCproject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public EmployeeController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Clients = await mvcDemoDbContext.Client.ToListAsync();
            return View(Clients);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Client addEmployeeRequest)
        {
            if (ModelState.IsValid)
            {
                var employee = new Client()
                {
                    Id = Guid.NewGuid(),
                    Name = addEmployeeRequest.Name,
                    Email = addEmployeeRequest.Email,
                    Salary = addEmployeeRequest.Salary,
                    Department = addEmployeeRequest.Department,
                    DateOfBirth = addEmployeeRequest.DateOfBirth,
                };

                await mvcDemoDbContext.Client.AddAsync(employee);
                await mvcDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Add");
            }
            return View(addEmployeeRequest);

        }

    }
}
