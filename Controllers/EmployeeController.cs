using aspMVCproject.Data;
using aspMVCproject.Models;
using aspMVCproject.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static System.Reflection.Metadata.BlobBuilder;

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
            var clients = new List<Client>
            {
                new Client
                {
                    Id = 1,
                    Name = "Alice Johnson",
                    Email = "alice.johnson@email.com",
                    Salary = 75000,
                    DateOfBirth = new DateTime(1990, 5, 12),
                    Department = "Finance"
                },
                new Client
                {
                    Id = 2,
                    Name = "Bob Smith",
                    Email = "bob.smith@email.com",
                    Salary = 85000,
                    DateOfBirth = new DateTime(1985, 3, 22),
                    Department = "IT"
                },
                new Client
                {
                    Id = 3,
                    Name = "Charlie Brown",
                    Email = "charlie.brown@email.com",
                    Salary = 68000,
                    DateOfBirth = new DateTime(1992, 11, 3),
                    Department = "Marketing"
                },
                new Client
                {
                    Id = 3,
                    Name = "Diana Prince",
                    Email = "diana.prince@email.com",
                    Salary = 92000,
                    DateOfBirth = new DateTime(1988, 7, 19),
                    Department = "HR"
                },
                new Client
                {
                    Id = 4,
                    Name = "Ethan Hunt",
                    Email = "ethan.hunt@email.com",
                    Salary = 98000,
                    DateOfBirth = new DateTime(1984, 12, 5),
                    Department = "Operations"
                }
            };


            if (TempData["Clients"] != null)
            {
                var newclients = TempData["Clients"] != null
                ? JsonConvert.DeserializeObject<List<Client>>(TempData["Clients"].ToString())
                : new List<Client>();
                return View(newclients);
            }
            else
            {
                return View(clients);
            }            
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
                var clients = new List<Client>
            {
                new Client
                {
                    Id = 1,
                    Name = "Alice Johnson",
                    Email = "alice.johnson@email.com",
                    Salary = 75000,
                    DateOfBirth = new DateTime(1990, 5, 12),
                    Department = "Finance"
                },
                new Client
                {
                    Id = 2,
                    Name = "Bob Smith",
                    Email = "bob.smith@email.com",
                    Salary = 85000,
                    DateOfBirth = new DateTime(1985, 3, 22),
                    Department = "IT"
                },
                new Client
                {
                    Id = 3,
                    Name = "Charlie Brown",
                    Email = "charlie.brown@email.com",
                    Salary = 68000,
                    DateOfBirth = new DateTime(1992, 11, 3),
                    Department = "Marketing"
                },
                new Client
                {
                    Id = 3,
                    Name = "Diana Prince",
                    Email = "diana.prince@email.com",
                    Salary = 92000,
                    DateOfBirth = new DateTime(1988, 7, 19),
                    Department = "HR"
                },
                new Client
                {
                    Id = 4,
                    Name = "Ethan Hunt",
                    Email = "ethan.hunt@email.com",
                    Salary = 98000,
                    DateOfBirth = new DateTime(1984, 12, 5),
                    Department = "Operations"
                }
            };
                var newEmployee = new Client()
                {
                    Id = 5,
                    Name = addEmployeeRequest.Name,
                    Email = addEmployeeRequest.Email,
                    Salary = addEmployeeRequest.Salary,
                    Department = addEmployeeRequest.Department,
                    DateOfBirth = addEmployeeRequest.DateOfBirth,
                };

                clients.Add(newEmployee);
                TempData["Clients"] = JsonConvert.SerializeObject(clients);
                TempData.Keep("Clients");

                //await mvcDemoDbContext.Client.AddAsync(employee);
                //await mvcDemoDbContext.SaveChangesAsync();
                //return RedirectToAction("Add");
            }
            return RedirectToAction("Index");

        }

    }
}
