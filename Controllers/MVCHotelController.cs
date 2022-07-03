using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SD_115_W22SD_Labs.Models;

namespace SD_115_W22SD_Labs.Controllers
{
    public class MVCHotelController : Controller
    {
      public IActionResult AllRooms()
        {
            return View(Hotel.Rooms);
        }
    }
}
