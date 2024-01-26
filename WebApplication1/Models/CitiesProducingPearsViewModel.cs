using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	public class CitiesProducingPearsViewModel
	{
		public int Id { get; set; }

		[Display(Name = "Şehir ismi")]
		[Required(ErrorMessage = "Şehir ismi boş bırakılamaz.")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Şehir ismi 3-50 karakter arasında olmalıdır.")]
		public string City { get; set; }
	}
}