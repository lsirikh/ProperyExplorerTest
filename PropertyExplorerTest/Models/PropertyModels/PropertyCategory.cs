using PropertyExplorerTest.Defines;
using PropertyExplorerTest.Defines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.Models.PropertyModels
{
    public class PropertyCategory : BaseNotifier, IPropertyCategory
    {

        public string CategoryName { get; }

        public bool IsShow
        {
            get { return this.Properties.Any(p => p.IsShow); }
        }

        public List<IPropertyContainer> Properties { get; } = new List<IPropertyContainer>();

        public PropertyCategory(string categoryName)
        {
            this.CategoryName = categoryName;
        }
    }
}
