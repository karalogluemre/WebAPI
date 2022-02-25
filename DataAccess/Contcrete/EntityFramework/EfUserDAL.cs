using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Contcrete.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contcrete.EntityFramework
{
    public class EfUserDAL : EfBaseRepository<User,ApplicationDbContext>,IUserDAL
    {

    }
}
