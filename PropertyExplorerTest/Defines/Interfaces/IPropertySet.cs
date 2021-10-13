using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyExplorerTest.Defines.Interfaces
{
    /// <summary>
    /// IPropertySet 인터페이스 원형
    /// </summary>
    public interface IPropertySet
    {
        string Name { get; }
    }
    /// <summary>
    /// IPropertySet 인터페이스 파생
    /// </summary>
    /// <typeparam name="T">Generic하게 다양한 타입을 받을 수 있게 되었다.</typeparam>
    public interface IPropertySet<T> : IPropertySet
    {
        
        T Value { get; set; }
    }
}
