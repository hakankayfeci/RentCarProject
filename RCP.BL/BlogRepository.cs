using RCP.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.BL
{
    public class BlogRepository:BaseRepository<Blog>
    {
        //public bool UpdateBlog(Blog blog)
        //{
        //    var resultblog = context.Blog.Find(blog.Id);
        //    context.Blog.Attach(blog);
        //    context.Entry(blog).State = System.Data.Entity.EntityState.Modified;
        //    int result = context.SaveChanges();
        //    return result > 0 ? true : false;
        //}
        public bool UpdateBlog(Blog model)
        {
            SqlParameter[] parameters = { new SqlParameter("userId", model.UserId), new SqlParameter("Title", model.Title) , new SqlParameter("Content", model.Content), new SqlParameter("Star", model.Star)
            , new SqlParameter("ID", model.Id)};
            int result = context.Database.ExecuteSqlCommand("Update [Blog] Set Title = @Title, Content= @Content, Star= @Star Where UserId = @userId and Id = @ID", parameters);
            return result > 0 ? true : false;
        }
    }
}
