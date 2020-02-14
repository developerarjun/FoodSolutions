using foodSolutions.Model.USER.PUBLIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodSolutions.Services.ADMIN.PUBLIC
{
    public interface IViewOrderServices
    {
        Orders getOrderByAdmin();
        List<Orders> getSalesReport(SalesReport sales);
    }
}
