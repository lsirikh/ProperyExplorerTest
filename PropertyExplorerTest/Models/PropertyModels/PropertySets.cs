using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PropertyExplorerTest.Models.PropertyModels
{
	public class DoublePropertySet : PropertySet<double>
	{
		/// <summary>
		/// DoublePropertySet 생성시, Override를 활용하여 2가지 형태로
		/// 생성을 하게 됨.
		/// 주 목적은 get과 set을 분리하려고 하는것인데
		/// 
		/// ???????????그 의도는 아직 이해가 안된다.
		/// </summary>
		/// <param name="name"></param>
		public DoublePropertySet(string name) : base(name) { }

		public DoublePropertySet(string name, Func<double> getter, Action<double> setter)
			: base(name, getter, setter)
		{
		}
		
	}

	public class IntPropertySet : PropertySet<int>
	{
		/// <summary>
		/// IntPropertySet 생성시, Override를 활용하여 2가지 형태로
		/// 생성을 하게 됨.
		/// 주 목적은 get과 set을 분리하려고 하는것인데
		/// 
		/// ???????????그 의도는 아직 이해가 안된다.
		/// </summary>
		/// <param name="name"></param>
		public IntPropertySet(string name) : base(name) { }

		public IntPropertySet(string name, Func<int> getter, Action<int> setter)
			: base(name, getter, setter)
		{
		}
	}

	public class BoolPropertySet : PropertySet<bool>
	{
		/// <summary>
		/// IntPropertySet 생성시, Override를 활용하여 2가지 형태로
		/// 생성을 하게 됨.
		/// 주 목적은 get과 set을 분리하려고 하는것인데
		/// 
		/// ???????????그 의도는 아직 이해가 안된다.
		/// </summary>
		/// <param name="name"></param>
		public BoolPropertySet(string name) : base(name) { }

		public BoolPropertySet(string name, Func<bool> getter, Action<bool> setter)
			: base(name, getter, setter)
		{
		}
	}


	/// <summary>
	/// 이하 상동
	/// </summary>
	public class ColorPropertySet : PropertySet<Color>
	{
		public ColorPropertySet(string name) : base(name) { }

		public ColorPropertySet(string name, Func<Color> getter, Action<Color> setter)
			: base(name, getter, setter)
		{
		}
	}

	/// <summary>
	/// 이하 상동
	/// </summary>
	public class StringPropertySet : PropertySet<string>
	{
		public StringPropertySet(string name) : base(name) { }

		public StringPropertySet(string name, Func<string> getter, Action<string> setter)
			: base(name, getter, setter)
		{
		}
	}
}
