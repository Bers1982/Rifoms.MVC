using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rifoms.Domain.Infrastructure.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class SQL
    {
        public static string InsertContentTpl => "com_content_read.tpl";
        public static string InsertContent = "INSERT INTO cms_content(category_id,user_id,pubdate,enddate,is_end,title,description,content,published,hits,rating,meta_desc,meta_keys,showtitle,showdate,showlatest,showpath,ordering,comments,is_arhive,seolink,canrate,pagetitle,url,tpl)VALUES({{category_id}},{{{user_id}},{{pubdate}},{{enddate}},{{is_end}},{{title}},{{description}},{{content}},{{published},{{hits},{{rating},{{meta_desc}},{{meta_keys}},{{showtitle},{{showdate},{{showlatest},{{showpath},{{ordering}},{{comments},{{is_arhive}},{{seolink}},{{canrate},{{pagetitle}},{{url}},{{tpl}})";

        //public static string InsertContent = "INSERT INTO cms_content(id,category_id,user_id,pubdate,enddate,is_end,title,description,content,published,hits,rating,meta_desc,meta_keys,showtitle,showdate,showlatest,showpath,ordering,comments,is_arhive,seolink,canrate,pagetitle,url,tpl)VALUES({{id}},{{category_id}},{{{user_id}},{{pubdate}},{{enddate}},{{is_end}},{{title}},{{description}},{{content}},{{published},{{hits},{{rating},{{meta_desc}},{{meta_keys}},{{showtitle},{{showdate},{{showlatest},{{showpath},{{ordering}},{{comments},{{is_arhive}},{{seolink}},{{canrate},{{pagetitle}},{{url}},{{tpl}});";
    }
}
