using RCP.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.BL
{
   public class UserRepository:BaseRepository<User>
    {
        public User Login(string email, string password,string username)
        {
          return context.Set<User>().Where(x => x.Email == email || x.Username == username && x.Password == password).FirstOrDefault();
        }

        public bool AddRole(int userId, int roleId)
        {
            SqlParameter[] parameters = { new SqlParameter("userId", userId), new SqlParameter("rolId", roleId) };
            int result = context.Database.ExecuteSqlCommand("insert into UserRole (UserId, RoleId) values (@userId,@rolId)", parameters);
            return result > 0 ? true : false;
        }
        public bool UpdateUser(User user)
        {
            SqlParameter[] parameters = { new SqlParameter("userId", user.Id), new SqlParameter("Email", user.Email), new SqlParameter("Name", user.Name), new SqlParameter("Password", user.Password)
            , new SqlParameter("Surname", user.Surname), new SqlParameter("Username", user.Username), new SqlParameter("Phone", user.Phone)};
            int result = context.Database.ExecuteSqlCommand("Update [User] Set Email = @Email, Name= @Name, Surname= @Surname, Password=@Password,Username=@Username, Phone=@Phone Where Id = @userId", parameters);
            return result > 0 ? true : false;
        }
    }
}
