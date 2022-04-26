using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiziFilmBlog.Entity;

namespace DiziFilmBlog.AdminSayfalar
{
    public partial class Bloglar : System.Web.UI.Page
    {
        BlogDiziEntities db = new BlogDiziEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource=db.TBLBLOG.ToList();
            Repeater1.DataBind();
        }
    }
}