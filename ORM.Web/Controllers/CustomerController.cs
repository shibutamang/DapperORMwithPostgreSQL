using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    }
}