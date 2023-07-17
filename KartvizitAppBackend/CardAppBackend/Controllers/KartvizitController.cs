using CardAppBackend.DTOs;
using CardAppBackend.MapperProfile;
using CardAppBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CardAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KartvizitController : ControllerBase
    {
        private readonly CardMapperProfile _mapperProfile;

        public KartvizitController(CardMapperProfile mapperProfile)
        {
            _mapperProfile = mapperProfile;
        }

        private static readonly List<Card> cards = new List<Card>
        {
            new Card(1,"Yazılım Mühendisi","Yiğit Tanyel","Address 1","Phone 1"),
            new Card(2,"Öğrenci","Semih Tanyel","Address 2",""),
            new Card(3,"Öğrenci","Yusuf Tanyel","Address 3","Phone 3"),
            new Card(4,"Doktor","Abcd Efg","","")
        };

        [HttpGet("[action]")]
        public IActionResult GetCards()
        {
            return Ok(cards);
        }

        [HttpPost("[action]")]
        public IActionResult AddCard(CardCreateDto card)
        {
            Card cardItem = _mapperProfile.Map(card);
            cards.Add(cardItem);

            return Ok(new { message = "Kartvizit oluşturma işlemi başarılı." });
        }

        [HttpPut("[action]/{id}")]
        public  IActionResult UpdateCard(int id, Card card)
        {
            try
            {
                if (id != card.Id)
                    return BadRequest("Card ID mismatch");

                var cardToUpdate =  cards.Where(x=>x.Id==id).FirstOrDefault();

                if (cardToUpdate == null)
                    return NotFound($"Card with Id = {id} not found");

                cardToUpdate.Title = card.Title;
                cardToUpdate.Name = card.Name;
                cardToUpdate.Address = card.Address;
                cardToUpdate.Phone = card.Phone;

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteCard(int id)
        {
            try
            {
                var cardToDelete = cards.Where(x => x.Id == id).FirstOrDefault();

                if (cardToDelete == null)
                    return NotFound($"Card with Id = {id} not found");

                cards.Remove(cardToDelete);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                       "Error deleting data");
            }
        }
    }
}
