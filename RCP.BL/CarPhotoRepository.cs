using RCP.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.BL
{
    public class CarPhotoRepository:BaseRepository<CarPhoto>
    {
        public bool UpdateCarPhoto(CarPhoto model)
        {
            SqlParameter[] parameters = { new SqlParameter("CarId", model.CarId), new SqlParameter("ID", model.Id), new SqlParameter("Photo", model.Photo) };
            int result = context.Database.ExecuteSqlCommand("Update [CarPhoto] Set Photo = @Photo Where CarId = @CarId and Id = @ID", parameters);
            return result > 0 ? true : false;
        }
    }
}
