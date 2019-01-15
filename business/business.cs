using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class FBusiness
    {
        public IEnumerable<object> GetEmployees()
        {
            Employees employees = new Employees();
            return employees as IEnumerable<object>;
        }
    }
}
