using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class MainController
    {
        public IEnumerable<Modelos.UserViewModel> GetList()
        {
            using (Modelos.EF.cursomvcEntities db = new Modelos.EF.cursomvcEntities())
            {
                IEnumerable<Modelos.UserViewModel> lst = (from d in db.user
                                                          select new Modelos.UserViewModel
                                                          {
                                                              Id = d.id,
                                                              Email = d.email
                                                          }).ToList();
                return lst;
            }
        }
    }
}
