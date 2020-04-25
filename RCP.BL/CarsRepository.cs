using RCP.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.BL
{
    public class CarsRepository:BaseRepository<Cars>
    {
        public bool UpdateCar(Cars model)
        {
            SqlParameter[] parameters = { new SqlParameter("userId", model.UserId), new SqlParameter("Brand", model.Brand) , new SqlParameter("CarPlate", model.CarPlate), new SqlParameter("CaseType", model.CaseType)
            , new SqlParameter("ID", model.Id), new SqlParameter("Color", model.Color), new SqlParameter("Engine", model.Engine), new SqlParameter("EnginePower", model.EnginePower), new SqlParameter("Fuel", model.Fuel), new SqlParameter("Gear", model.Gear), new SqlParameter("Km", model.Km), new SqlParameter("Model", model.Model), new SqlParameter("Price", model.Price), new SqlParameter("Sherry", model.Sherry), new SqlParameter("Traction", model.Traction), new SqlParameter("Waranty", model.Waranty), new SqlParameter("Year", model.Year)};
            int result = context.Database.ExecuteSqlCommand("Update [Cars] Set Brand = @Brand, CarPlate= @CarPlate, CaseType= @CaseType,Gear = @Gear, Km= @Km, Model= @Model, Color= @Color,Engine = @Engine, EnginePower= @EnginePower, Fuel= @Fuel, Price= @Price, Sherry= @Sherry,Traction = @Traction, Waranty= @Waranty, Year= @Year Where UserId = @userId and Id = @ID", parameters);
            return result > 0 ? true : false;
        }
    }
}
