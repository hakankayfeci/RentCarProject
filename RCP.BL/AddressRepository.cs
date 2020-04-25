using RCP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.BL
{
   public class AddressRepository :BaseRepository<Address>
    {
        public List<Address> SearchByTitle(string content)
        {
            //using (context = new ETicaretContext())
            {
                return context.Address.Where(x => x.Content == content).ToList();
            }
        }
    }
}
