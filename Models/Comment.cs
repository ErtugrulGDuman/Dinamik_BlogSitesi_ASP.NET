using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltTab.Models
{
	public class Comment
	{
        public int CommentId { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public float puan { get; set; }
        public int MakaleId { get; set; }
        public virtual Makale Makale { get; set; }
    }
}