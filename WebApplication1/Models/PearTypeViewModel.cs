using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	public class PearTypeViewModel
	{
		public int Id { get; set; }

		[Display(Name = "Tür")]
		[Required(ErrorMessage = "Tür boş bırakılamaz.")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Tür 3-50 karakter arasında olmalıdır.")]
		public string Type { get; set; }
	}
}