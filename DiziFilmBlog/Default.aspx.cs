﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiziFilmBlog.Entity;

namespace DiziFilmBlog
{
    public partial class Default : System.Web.UI.Page
    {
        BlogDiziEntities db = new BlogDiziEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            //BLOG BAŞLIKLARI
            var bloglar = db.TBLBLOG.ToList();
            Repeater1.DataSource= bloglar;
            Repeater1.DataBind();

            //KATAGORİ BAŞLIKLARI
            var bloglar2 = db.TBLKATEGORI.ToList();
            Repeater2.DataSource = bloglar2;
            Repeater2.DataBind();


            //EN SON PAYLAŞILANLAR
            var bloglar3 = db.TBLBLOG.Take(5).ToList();
            Repeater3.DataSource = bloglar3;
            Repeater3.DataBind();

            //EN SON PAYLAŞILAN YORUMLAR
            var bloglar4 = db.TBLYORUM.Take(3).ToList();
            Repeater4.DataSource = bloglar4;
            Repeater4.DataBind();

        }
    }
}