using foodSolutions.Model.ADMIN.PUBLIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodSolutions.Services.ADMIN.PUBLIC
{
    public interface IAdminLoginServices
    {
        AdminLogin LoginIn(AdminLogin admin);
    }
}
