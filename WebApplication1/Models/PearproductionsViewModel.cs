using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	public class PearproductionsViewModel
	{
		public int id { get; set; }

		[Display(Name = "Ülke ismi")]
		[Required(ErrorMessage ="Şehir ismi boş bırakılamaz.")]
		[StringLength(50,MinimumLength = 3, ErrorMessage ="Şehir ismi 3-50 karakter arasında olmalıdır.")]
		public string country_name { get; set; }

		[Display(Name = "2018 Yılı")]
		[Required(ErrorMessage = "Yıl boş bırakılamaz")]
		[Range(int.MinValue,int.MaxValue,ErrorMessage = "integer değer aralığını aşmamalı !")]
		public int? production_2020 { get; set; }

		[Display(Name = "2019 Yılı")]
		[Required(ErrorMessage = "Yıl boş bırakılamaz")]
		[Range(int.MinValue, int.MaxValue, ErrorMessage = "integer değer aralığını aşmamalı !")]
		public int? production_2019 { get; set; }

		[Display(Name = "2019 Yılı")]
		[Required(ErrorMessage = "Yıl boş bırakılamaz")]
		[Range(int.MinValue, int.MaxValue, ErrorMessage = "integer değer aralığını aşmamalı !")]
		public int? production_2018 { get; set; }
	}
}