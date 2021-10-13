using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.Defines.Interfaces
{
    public interface IPropertyCategory
    {
        /// <summary>
        /// 카테고리 명칭 Color, Size 등등
        /// </summary>
        string CategoryName { get; }

        /// <summary>
        /// Show Hide 설정을 위한 boolean 필드
        /// </summary>
        bool IsShow { get; }

        /// <summary>
        /// 담고있는 속성값들...
        /// </summary>
        List<IPropertyContainer> Properties { get; }

    }
}
