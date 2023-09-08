using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltTab.Models
{
	public class Category
	{
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Makale> Makaleler { get; set; }
    }
}