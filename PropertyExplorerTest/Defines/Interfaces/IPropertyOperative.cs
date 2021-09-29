using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.Defines.Interfaces
{
    public interface IPropertyOperative
    {
        IEnumerable<IPropertyCategory> GetCategories();
    }
}
