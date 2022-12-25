using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShipmentTrackingSite.Data;
using ShipmentTrackingSite.Models;
using Microsoft.EntityFrameworkCore;
namespace ShipmentTrackingSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    IOrderRepository repo;

    public HomeController(ILogger<HomeController> logger, IOrderRepository r)
    {
        _logger = logger;
        repo = r;
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Order> orders = repo.Orders.ToList<Order>();
        return View(orders);
    }

    [HttpPost]
    public IActionResult Index(string carrier, string orderedFrom)
    {
        List<Order> orders = null;

        if (orderedFrom != null && carrier != null)
        {
            orders = (from o in repo.Orders where o.OrderedFrom == orderedFrom && o.Carrier == carrier select o).ToList();
        }

        else if (orderedFrom != null)
        {
            orders = (from o in repo.Orders where o.OrderedFrom == orderedFrom select o).ToList();
        }

        else if (carrier != null)
        {
            orders = (from c in repo.Orders where c.Carrier == carrier select c).ToList();

        }

        return View(orders);
    }

    [HttpGet]
    public IActionResult Add()
    {
        //ViewBag.FV = 0;
        return View();
    }

    [HttpPost]
    public IActionResult Add(Order model)
    {

        //ViewBag.FV = 0;
        if (ModelState.IsValid)
        {
            model = repo.AddToDb(model);
        }
        else
        {
            return RedirectToAction("Add");
        }

        return RedirectToAction("Index", new { orderId = model.OrderId });
    }
}

