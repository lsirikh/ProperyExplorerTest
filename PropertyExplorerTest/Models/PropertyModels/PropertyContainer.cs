using PropertyChanged;
using PropertyExplorerTest.Defines;
using PropertyExplorerTest.Defines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.Models.PropertyModels
{
    public class PropertyContainer : BaseNotifier, IPropertyContainer
    {

        public string PropertyName { get; private set; }

        public string LowerPropertyName { get; private set; }

        private bool _isShow;

        [DoNotNotify]
        public bool IsShow
        {
            get { return _isShow; }
            set 
            { 
                _isShow = value;
                this.NofityPropertyChanged();
                this.Set(this.ParentCategory);
            }
        }

        public IPropertySet Property { get; set; }

        public IPropertyCategory ParentCategory { get; private set; }

        public PropertyContainer(IPropertySet propertySet, IPropertyCategory parentCategory, string propertyName = "")
        {
            this.Property = propertySet;
            this.Init(parentCategory, propertyName);
        }

        private void Init(IPropertyCategory parentCategory, string propertyName = "")
        {
            this.PropertyName = string.IsNullOrWhiteSpace(propertyName) ? this.Property.Name : propertyName;
            this.LowerPropertyName = this.PropertyName.ToLower();
            this.IsShow = true;
            this.ParentCategory = parentCategory;

        }
    }
}
