using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.Defines.Interfaces
{
    public interface IPropertyContainer
    {
        /// <summary>
        /// PropertyContainer의 명칭 Color, Size 등등...
        /// </summary>
        string PropertyName { get; }

        /// <summary>
        /// 소문자 형태 글자
        /// </summary>
        string LowerPropertyName { get; }

        /// <summary>
        /// Show Hide 설정을 위한 boolean 필드
        /// </summary>
        bool IsShow { get; set; }

        /// <summary>
        /// 실제 입력될 속정 값 Property
        /// ex) 3(두께정보), 132(X)
        /// </summary>
        IPropertySet Property { get; }

        IPropertyCategory ParentCategory { get; }
    }
}
