using System.Collections.Generic;

namespace MindHypertrophy.Models
{
    public class CardDetailDTO
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string CreatedDate { get; set; }
        public string Content { get; set; }
        public List<TagDTO> Tags { get; set; }
    }
}
