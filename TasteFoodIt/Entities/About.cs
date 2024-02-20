using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasteFoodIt.Entities
{
	public class About
	{
		public int AboutId { get; set; } //Sınıf ismi + ID bunun primary key olduğunu anlıyor.
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImgUrl { get; set; }

	}
}