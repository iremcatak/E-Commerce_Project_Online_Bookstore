using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kitapderyasiFinal.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category() {Name="Roman",Description="Kitap"},
                new Category() {Name="Çocuk & Gençlik",Description="Kitap"},
                new Category() {Name="Kişisel Gelişim",Description="Kitap"},
                new Category() {Name="Şiir",Description="Kitap"},
                new Category() {Name="Bilim",Description="Kitap"},
                new Category() {Name="Din & Tasavvuf",Description="Kitap"},
                new Category() {Name="Felsefe",Description="Kitap"},
                new Category() {Name="Araştırma & Tarih",Description="Kitap"},
                new Category() {Name="Çizgi Roman",Description="Kitap"},
                new Category() {Name="Foreign Languages",Description="Kitap"},
                new Category() {Name="Edebiyat",Description="Kitap"},
                new Category() {Name="Eğitim",Description="Kitap"},
                new Category() {Name="Boya & Resim Malzemeleri",Description="Kırtasiye"},
                new Category() {Name="Defterler",Description="Kırtasiye"},
                new Category() {Name="Ajandalar",Description="Kırtasiye"},
                new Category() {Name="Kalemler",Description="Kırtasiye"},
                new Category() {Name="Okul Çantaları",Description="Kırtasiye"},
                new Category() {Name="Silgi & Kalemtraş",Description="Kırtasiye"},
                new Category() {Name="Elektronik Kitap Okuyucu",Description="Elektronik"},
                new Category() {Name="Okuma Lambası",Description="Elektronik"}
            };
            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product(){Id=1,Name="Her Şey Seninle Başlar",Writer="Mümin Sekman",Brand="Alfa",Description="Kişisel Gelişim Kitabı",Colour="None",Price=55,Stock=1000,Slider=true,IsHome=true,IsFeatured=true,IsApproved=false,CategoryId=1,Image="1.png"},
                new Product(){Id=2,Name="Elektronik Kitap Okuyucu",Writer="None",Brand="Lenovo",Description="En çok satan kitap okuyucu",Colour="Beyaz",Price=2500,Stock=50,Slider=true,IsHome=true,IsFeatured=true,IsApproved=true,CategoryId=2,Image="2.png"},
                new Product(){Id=3,Name="Latife Hanım",Brand="DK",Writer="İpek Çalışlar",Description="lorem ipsum",Colour="None",Price=42,Stock=78,Slider=false,IsHome=false,IsFeatured=false,IsApproved=false,CategoryId=1,Image="3.png"},
                new Product(){Id=4,Name="Kırmızı Kurşun Kalem",Brand="Faber Castel",Description="Yumuşak Uçlu",Writer="None",Colour="Kırmızı",Price=5,Stock=2500,Slider=true,IsHome=true,IsFeatured=false,IsApproved=true,CategoryId=3,Image="4.png"},
                new Product(){Id=5,Name="Siyah Okul Çantası",Brand="Nike",Description="Okul Çantası",Writer="None",Colour="Siyah",Price=70,Stock=78,Slider=true,IsHome=false,IsFeatured=true,IsApproved=false,CategoryId=3,Image="5.png"},
            };
            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }
}