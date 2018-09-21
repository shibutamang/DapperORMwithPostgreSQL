using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ORM.Web.Models;
using ORM.Web.Repository;

namespace ORM.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerRepository _repository;

        public CustomerController(IConfiguration configuration)
        {
            _repository = new CustomerRepository(configuration);
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _repository.GetAllAsync();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = _repository.Get(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            _repository.Update(customer);
            return RedirectToAction("Index");

        }
    }
}