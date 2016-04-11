using System.Collections.Generic;

namespace MindHypertrophy.Models
{
    public interface IAppRepository
    {
        IEnumerable<CardDTO> GetCards();
        CardDetailDTO GetCardById(int cardId);
        IEnumerable<CardDTO> GetCardsByTagId(int tagId);
        IEnumerable<TagDTO> GetTags();
    }
}
