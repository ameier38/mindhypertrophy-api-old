using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;

namespace MindHypertrophy.Models
{
    public class AppRepository : IAppRepository
    {
        private AppDbContext _context;
        public AppRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CardDTO> GetCards()
        {
            var cards = _context.Cards.Include(c => c.CardTags).ThenInclude(ct => ct.Tag);
            var cardDTOs = cards.Select(c => new CardDTO()
            {
                Id = c.Id,
                Title = c.Title,
                Slug = c.Slug,
                Summary = c.Summary,
                CreatedDate = c.CreatedDate.ToString("MMMM dd, yyyy"),
                Tags = c.CardTags.Select(ct => new TagDTO()
                {
                    Id = ct.Tag.Id,
                    Name = ct.Tag.Name
                }).ToList()
            });
            return cardDTOs;
        }

        public IEnumerable<CardDTO> GetCardsByTagId(int tagId)
        {
            var cards = _context.Cards.Include(c => c.CardTags).ThenInclude(ct => ct.Tag)
                                        .Where(c => c.CardTags.Any(ct => ct.TagId == tagId))
                                        .Select(c => new CardDTO()
                                        {
                                            Id = c.Id,
                                            Title = c.Title,
                                            Slug = c.Slug,
                                            Summary = c.Summary,
                                            CreatedDate = c.CreatedDate.ToString("MMMM dd, yyyy"),
                                            Tags = c.CardTags.Select(ct => new TagDTO()
                                            {
                                                Id = ct.Tag.Id,
                                                Name = ct.Tag.Name
                                            }).ToList()
                                        });
            return cards;
        }

        public CardDetailDTO GetCardById(int cardId)
        {
            var card = _context.Cards.Include(c => c.CardTags).ThenInclude(ct => ct.Tag).FirstOrDefault(c => c.Id == cardId);
            if (card == null)
            {
                return null;
            }
            else
            {
                var cardDetail = new CardDetailDTO()
                {
                    Id = card.Id,
                    Slug = card.Slug,
                    Title = card.Title,
                    ImageUrl = card.ImageUrl,
                    CreatedDate = card.CreatedDate.ToString("MMMM dd, yyyy"),
                    Content = card.Content,
                    Tags = card.CardTags.Select(ct => new TagDTO()
                    {
                        Id = ct.Tag.Id,
                        Name = ct.Tag.Name
                    }).ToList()
                };

                return cardDetail;
            }
        }

        public CardDetailDTO GetCardBySlug(string slug)
        {
            var card = _context.Cards.Include(c => c.CardTags).ThenInclude(ct => ct.Tag).FirstOrDefault(c => c.Slug == slug);
            if (card == null)
            {
                return null;
            }
            else
            {
                var cardDetail = new CardDetailDTO()
                {
                    Id = card.Id,
                    Slug = card.Slug,
                    Title = card.Title,
                    ImageUrl = card.ImageUrl,
                    CreatedDate = card.CreatedDate.ToString("MMMM dd, yyyy"),
                    Content = card.Content,
                    Tags = card.CardTags.Select(ct => new TagDTO()
                    {
                        Id = ct.Tag.Id,
                        Name = ct.Tag.Name
                    }).ToList()
                };

                return cardDetail;
            }
        }

        public IEnumerable<TagDTO> GetTags()
        {
            return _context.Tags.Select(t => new TagDTO()
            {
                Id = t.Id,
                Name = t.Name
            });
        }
    }
}
