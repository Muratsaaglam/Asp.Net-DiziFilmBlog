using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiziFilmBlog.Entity;

namespace DiziFilmBlog.AdminSayfalar
{
    public partial class YeniBlog : System.Web.UI.Page
    {
        BlogDiziEntities db = new BlogDiziEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Dizi Türlerini Drop Down'da Listeleme
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
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Blog Kayıt 
            TBLBLOG t = new TBLBLOG();
            t.BLOGBASLIK = TextBox1.Text;
            t.BLOGGORSEL = TextBox3.Text;
            t.BLOGICERIK = TextBox4.Text;
            t.BLOGTARIH = DateTime.Parse(TextBox2.Text);
            t.BLOGTUR = byte.Parse(DropDownList1.SelectedValue);
            t.BLOGKATEGORI = byte.Parse(DropDownList2.SelectedValue);
            db.TBLBLOG.Add(t);
            db.SaveChanges();
            Response.Redirect("Bloglar.Aspx");
        }
    }
}