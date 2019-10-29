using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Mapper
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
