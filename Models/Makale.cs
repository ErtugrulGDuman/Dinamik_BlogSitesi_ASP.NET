using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltTab.Models
{
	public class Makale
	{
        public int Id { get; set; }
        public string UseName { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Views { get; set; }
        public bool Confirm { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}