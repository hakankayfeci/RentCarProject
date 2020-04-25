using RCP.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.BL
{
    public class BlogPhotoRepository : BaseRepository<BlogPhoto>
    {
        public bool UpdateBlogPhoto(BlogPhoto model)
        {
            SqlParameter[] parameters = { new SqlParameter("BlogId", model.BlogId), new SqlParameter("ID", model.Id) , new SqlParameter("Photo", model.Photo)};
            int result = context.Database.ExecuteSqlCommand("Update [BlogPhoto] Set Photo = @Photo Where BlogId = @BlogId and Id = @ID", parameters);
            return result > 0 ? true : false;
        }
    }
}
