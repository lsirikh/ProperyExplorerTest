using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.Defines.Interfaces
{
    public interface IPropertyCategory
    {
        string CategoryName { get; }

        bool IsShow { get; }

        List<IPropertyContainer> Properties { get; }

    }
}
