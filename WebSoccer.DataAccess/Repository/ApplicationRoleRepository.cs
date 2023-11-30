using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSoccer.DataAccess.Repository.IRepository;
using WebSoccer.DataAcess.Data;
using WebSoccer.Models;

namespace WebSoccer.DataAccess.Repository
{
    public class ApplicationRoleRepository : Repository<ApplicationRole>, IApplicationRoleRepository
    {
        private ApplicationDbContext _db;
        public ApplicationRoleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ApplicationRole applicationRole)
        {
            _db.ApplicationRoles.Update(applicationRole);
        }
    }
}
