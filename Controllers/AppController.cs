using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using MindHypertrophy.Models;

namespace MindHypertrophy.Controllers
{
    [Route("api")]
    public class AppController : Controller
    {
        // GET: api/cards
        [HttpGet("cards")]   
        public IEnumerable<CardDTO> GetCards([FromQuery] int? tagId, [FromServices] IAppRepository CardsRepo)
        {
            if (tagId == null)
            {
                return CardsRepo.GetCards();
            }
            else
            {
                return CardsRepo.GetCardsByTagId((int)tagId);
            }
        }

        // GET api/cards/5
        [HttpGet("cards/{cardId}")]
        public IActionResult GetCardById(int cardId, [FromServices] IAppRepository CardsRepo)
        {
            var card = CardsRepo.GetCardById(cardId);
            if (card == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(card);
        }

        [HttpGet("cards/{slug}")]
        public IActionResult GetCardBySlug(string slug, [FromServices] IAppRepository CardsRepo)
        {
            var card = CardsRepo.GetCardBySlug(slug);
            if (card == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(card);
        }

        // GET: api/tags
        [HttpGet("tags")]
        public IEnumerable<TagDTO> Get([FromServices] IAppRepository CardsRepo)
        {
            return CardsRepo.GetTags();
        }
    }
}
