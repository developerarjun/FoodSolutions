using foodSolutions.Model.ADMIN.PUBLIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodSolutions.Services.ADMIN.PUBLIC
{
    public interface IMenuServices
    {
        bool savemenu(List<Menu> menu);
        List<Menu> getMenu();
        bool deleteMenu(int id);
    }
}
