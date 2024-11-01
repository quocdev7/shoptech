using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using shopdodadung.Models;

namespace shopdodadung.Library
{
    
    public class ValidationSlug
    {
        BanHangDBContext db = new BanHangDBContext();
        public bool check_slug(String slug, String table, int? id=null)
        {
            //xử lý ràng buộc cho Categorys
            if(table == "category")
            {                
                if (id!=null)
                {
                    //sửa
                    var category_item = db.Categogys.Where(m => m.Slug == slug && m.Id!=id);
                    if (category_item.Count() != 0)
                    {
                        return false;
                    }
                }
                else
                {
                    //Thêm
                    var category_item = db.Categogys.Where(m => m.Slug == slug);
                    if (category_item.Count() != 0)
                    {
                        return false;
                    }
                }
                
            }
            //xử lý ràng buộc cho Topic
            if (table == "topic")
            {
                if (id != null)
                {
                    var category_item = db.Topics.Where(m => m.Slug == slug && m.Id != id);
                    if (category_item.Count() != 0)
                    {
                        return false;
                    }
                }
                else
                {
                    var category_item = db.Topics.Where(m => m.Slug == slug);
                    if (category_item.Count() != 0)
                    {
                        return false;
                    }
                }

            }
            //Xử lý rang buộc contact
            if (table == "contact")
            {
                if (id != null)
                {
                    var category_item = db.Contacts.Where(m => m.Email == slug || m.Phone == slug && m.Id != id);
                    if (category_item.Count() != 0)
                    {
                        return false;
                    }
                }
                else
                {
                    var category_item = db.Contacts.Where(m => m.Email == slug || m.Phone == slug);
                    if (category_item.Count() != 0)
                    {
                        return false;
                    }
                }

            }
            //xử lý ràng buộc cho Posts
            if (table == "post")
            {
                if (id != null)
                {
                    var category_item = db.Posts.Where(m => m.Slug == slug && m.Id != id);
                    if (category_item.Count() != 0)
                    {
                        return false;
                    }
                }
                else
                {
                    var category_item = db.Posts.Where(m => m.Slug == slug);
                    if (category_item.Count() != 0)
                    {
                        return false;
                    }
                }

            }
            if (table == "user")
            {
                if (id != null)
                {
                    //sửa
                    var category_item = db.Users.Where(m => m.UserName == slug || m.Email == slug && m.Id != id);
                    if (category_item.Count() != 0)
                    {
                        return false;
                    }
                }
                else
                {
                    //Thêm
                    var category_item = db.Users.Where(m => m.UserName  == slug || m.Email == slug);
                    if (category_item.Count() != 0)
                    {
                        return false;
                    }
                }

            }
            //xử lý ràng buộc cho Products
            if (table == "product")
            {
                if (id != null)
                {
                    var category_item = db.Products.Where(m => m.Slug == slug && m.Id != id);
                    if (category_item.Count() != 0)
                    {
                        return false;
                    }
                }
                else
                {
                    var category_item = db.Products.Where(m => m.Slug == slug);
                    if (category_item.Count() != 0)
                    {
                        return false;
                    }
                }

            }            
            return true;
        }
    }
}