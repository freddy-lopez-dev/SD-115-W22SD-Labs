using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SD_115_W22SD_Labs.Models;

namespace SD_115_W22SD_Labs.Controllers
{
    public class MVCHotelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Reservations()
        {
            return View(Hotel.Reservations);
        }

        [HttpGet]
        public IActionResult TopThree()
        {
            return View(Hotel.TopThreeClients().ToList());
        }

        public IActionResult AllRooms()
        {
            return View(Hotel.Rooms);
        }

        public IActionResult TotalCapacity()
        {
            ViewBag.totalCapacity = Hotel.TotalCapacityRemaining();
            return View(Hotel.Rooms);
        }

        public IActionResult GetRoom()
        {
            return View();
        }

        public IActionResult Room(int occupants)
        {
            try
            {
                if(occupants <= 0)
                {
                    return RedirectToAction("Error");
                } else
                {
                    Room room = Hotel.Rooms.First(r => r.Capacity >= occupants);
                    return View(room);
                }
            } catch
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
