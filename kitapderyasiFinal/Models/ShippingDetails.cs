using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kitapderyasiFinal.Models
{
    public class ShippingDetails
    {
        public string UserName { get; set; }
        [Required(ErrorMessage ="Lütfen bir başlık giriniz.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Lütfen şehir giriniz.")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Lütfen ilçe giriniz.")]
        public string Semt { get; set; }
        [Required(ErrorMessage = "Lütfen mahalle giriniz.")]
        public string Mahalle { get; set; }
        [Required(ErrorMessage = "Lütfen postakodu giriniz.")]
        public string Postakodu { get; set; }
    }
}