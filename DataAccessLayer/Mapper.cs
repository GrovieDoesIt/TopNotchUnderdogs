using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Mapper //This is the declaration of the class Creating a parent class that we can sort of use as a template for all of our other mappers to implement the assert method
    {
        public void Assert(bool condition, string message)
        {
            if (condition)
            {
                // this is the expected situation.  Nothing need to be done.
            }
            else
            {
                throw new Exception(message);
            }
        }
    }
}
