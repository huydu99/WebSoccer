using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSoccer.DataAccess.Repository;
using WebSoccer.DataAccess.Repository.IRepository;
using WebSoccer.DataAcess.Data;
using WebSoccer.Models;

namespace WebSoccer.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser> ,IApplicationUserRepository
    {
        private ApplicationDbContext _context;
        public ApplicationUserRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }
        public void Update(ApplicationUser obj)
        {
			_context.ApplicationUsers.Update(obj);
		}

    }
}
