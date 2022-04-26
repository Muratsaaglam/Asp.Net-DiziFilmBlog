﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiziFilmBlog.Entity;

namespace DiziFilmBlog.AdminSayfalar
{
    public partial class BlogGuncelle : System.Web.UI.Page
    {
        BlogDiziEntities db = new BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Blog Güncelleme İşlemleri
            int y = int.Parse(Request.QueryString["BLOGID"]);
            if (Page.IsPostBack == false)
            {

                var turler = (from x in db.TBLTUR
                              select new
                              {
                                  x.TURAD,
                                  x.TURID

                              }).ToList();
                DropDownList1.DataSource = turler;
                DropDownList1.DataBind();

                //Kategori Türlerini Drop Down'da Listeleme
                var kategoriler = (from x in db.TBLKATEGORI
                                   select new
                                   {
                                       x.KATEGORIAD,
                                       x.KATEGORIID

                                   }).ToList();
                DropDownList2.DataSource = kategoriler;
                DropDownList2.DataBind();

                //Değerlerin Textbox'lara yansıtılması
                var deger = db.TBLBLOG.Find(y);
                TextBox1.Text = deger.BLOGBASLIK;
                TextBox2.Text = deger.BLOGTARIH.ToString();
                TextBox3.Text = deger.BLOGGORSEL;
                TextBox4.Text = deger.BLOGICERIK;
                DropDownList1.Text = deger.BLOGTUR.ToString();
                DropDownList2.Text = deger.BLOGKATEGORI.ToString();

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Blog İçeriği Güncelle Butonu
            int y = int.Parse(Request.QueryString["BLOGID"]);
            var blog = db.TBLBLOG.Find(y);
            blog.BLOGBASLIK = TextBox1.Text;
            blog.BLOGTARIH = DateTime.Parse(TextBox2.Text);
            blog.BLOGGORSEL = TextBox3.Text;
            blog.BLOGICERIK = TextBox4.Text;    
            blog.BLOGTUR = byte.Parse(DropDownList1.SelectedValue);
            blog.BLOGKATEGORI = byte.Parse(DropDownList2.SelectedValue);
            db.SaveChanges();
            Response.Redirect("Bloglar.Aspx");

        }
    }
}