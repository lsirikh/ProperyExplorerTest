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
    /// <typeparam name="T"></typeparam>
    public interface IPropertySet<T> : IPropertySet
    {
        
        T Value { get; set; }
    }
}
