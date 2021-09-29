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
        /// <summary>
        /// IPropertyCategory를 Implementing 한 실체
        /// CategoryName
        /// </summary>
        public string CategoryName { get; }

        /// <summary>
        /// IPropertyCategory를 Implementing 한 실체
        /// IsShow
        /// /// </summary>
        public bool IsShow
        {
            get 
            { 
                //IsShow가 호출되면,
                //this.Properties.Any는 내부 아이템 IPropertyContainer
                //
                return this.Properties.Any(p => p.IsShow); 
            }
        }

        /// <summary>
        /// 최초 생성시, Properties에 List<IPropertyContainer>를 붙여준다.
        /// </summary>
        public List<IPropertyContainer> Properties { get; } = new List<IPropertyContainer>();

        public PropertyCategory(string categoryName)
        {
            this.CategoryName = categoryName;
        }
    }
}
