using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 10:00: using interface : it has removed the implementation details from this class.
// Now anything that implements this interface can be used with this class and
// UserCanDrink method will call that interface and get its data back. It does not
// care where the data from. 

// 11:23 create new project,


namespace UnitTestDemo
{
    public class SampleClass1D
    {

        private readonly IDataSource _dataSource;

        public SampleClass1D(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public bool UserCanDrink(Guid id)
        {
            User user = _dataSource.GetUser(id);
            return user.Age >= 21;
        }
    }
}
