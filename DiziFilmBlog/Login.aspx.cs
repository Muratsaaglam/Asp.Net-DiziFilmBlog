using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiziFilmBlog.Entity;

namespace DiziFilmBlog
{
    public partial class Login : System.Web.UI.Page
    {
        BlogDiziEntities db = new BlogDiziEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Admin ve Şifre Sorgulama
            var sorgu = from x in db.TBLADMIN 
                        where x.KULLANICI == TextBox1.Text && 
                        x.SIFRE == TextBox2.Text select x;
            if (sorgu.Any())
            {
                Response.Redirect("/AdminSayfalar/Bloglar.Aspx");

            }
            else
            {
                Response.Write("Kullanıcı ve Şifre Hatalıdır");

            }
        }
    }
}