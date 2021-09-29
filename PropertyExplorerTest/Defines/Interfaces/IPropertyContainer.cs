using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.Defines.Interfaces
{
    public interface IPropertyContainer
    {
        string PropertyName { get; }

        string LowerPropertyName { get; }

        bool IsShow { get; set; }

        IPropertySet Property { get; }

        IPropertyCategory ParentCategory { get; }
    }
}
