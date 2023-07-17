using CardAppBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardAppBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    public IActionResult Login(User user)
    {
        if (user.Username == "admin" && user.Password == "123")
        {
            return Ok();
        }

        return Unauthorized();
    }

    [HttpGet("[action]")]
    public IActionResult GetCards()
    {
        var card1= new Card("Title 1","Name 1","Address 1","Phone 1");
        var card2= new Card("Title 2","Name 2","Address 2","Phone 2");

        var cards = new List<Card> { card1, card2 };

        return Ok(cards);
    }
}
