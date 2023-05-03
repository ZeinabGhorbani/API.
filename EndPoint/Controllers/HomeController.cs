using Common.Models;
using EndPoint.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EndPoint.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly UserApiService userApi;

        public HomeController(ILogger<HomeController> logger, UserApiService userApi)
        {
            this.logger = logger;
            this.userApi = userApi;
        }

        public IActionResult Index()
        {
            return View(userApi.GetAll());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            userApi.Post(user);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            User user = userApi.Get(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            userApi.Put(user);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            User user = userApi.Get(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult DeleteContact(int UserId)
        {
            userApi.DeleteUser(UserId);
            return RedirectToAction("Index");
        }

    }
}
