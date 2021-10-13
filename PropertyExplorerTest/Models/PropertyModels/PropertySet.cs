using PropertyChanged;
using PropertyExplorerTest.Defines;
using PropertyExplorerTest.Defines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PropertyExplorerTest.Models.PropertyModels
{
    /// <summary>
    /// PropertySet은 파생인터페이스를 상속하여 클래스 정의
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PropertySet<T> : BaseNotifier, IPropertySet<T>
    {
        #region Fields

        private T _value;

        /// <summary>
        /// 매개 변수가없는 메서드를 캡슐화하고, 
        /// T 매개 변수에 지정된 형식의 값을 반환
        /// </summary>
        private Func<T> _getter;

        /// <summary>
        /// 매개 변수를 한개 가지는 메서드를 캡슐화하고,
        /// 반환이 없는 형식
        /// </summary>
        private Action<T> _setter;

        #endregion

        #region Properties
        /// <summary>
        /// 변수나 메소드 이름이 저장될 Name 변수
        /// </summary>
        public string Name { get; set; }

        [DoNotNotify]
        public T Value
        {
            get 
            { 
                return this._getter.Invoke(); 
            }
            
            set 
            {
                this._setter.Invoke(value);
                this.NofityPropertyChanged();
            }
        }

        #endregion

        #region Construnctors

        protected PropertySet(string name) : this(name, null, null) { }

        protected PropertySet(string name, Func<T> getter, Action<T> setter)
        {
            this.Name = name;
            this._getter = getter ?? this.GetDefaultGetter;
            this._setter = setter ?? this.SetDefaultSetter;
        }
        #endregion
                
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        public virtual void ClearValue()
        {
            this.Value = default(T);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private T GetDefaultGetter()
        {
            return this._value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        private void SetDefaultSetter(T value)
        {
            this._value = value;
        }

        #endregion
    }

    
}
