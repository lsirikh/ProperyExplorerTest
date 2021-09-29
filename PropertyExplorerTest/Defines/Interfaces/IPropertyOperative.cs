using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.Defines.Interfaces
{
    public interface IPropertyOperative
    {
        /// <summary>
        /// IProperyCategory타입을 활용한 IEnumerable형 메소드
        /// IProperyCategory 타입과 같은 Custom 한 타입 혹은 객체를
        /// while이나 foreach 문과 같은 형태로 만들어 사용하는 등의 
        /// Interface 이다.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IPropertyCategory> GetCategories();
    }
}
