using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kitapderyasiFinal.Models
{
    public class UserProfile
    {
        public string id { get; set; }
        [Required]
        [DisplayName("Ad")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyad")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir e posta adresi giriniz!")]
        public string Email { get; set; }
    }
}