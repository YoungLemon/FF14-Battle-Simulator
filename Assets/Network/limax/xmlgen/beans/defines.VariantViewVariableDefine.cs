using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.defines
{
	public sealed class VariantViewVariableDefine : limax.codec.Marshal, IComparable<VariantViewVariableDefine>
	{
		public int name;
		public int type;
		public int typeKey;
		public int typeValue;
		public bool bind;
		public VariantViewVariableDefine()
		{
			name = 0;
			type = 0;
			typeKey = 0;
			typeValue = 0;
			bind = false;
		}
		public VariantViewVariableDefine(int _name_, int _type_, int _typeKey_, int _typeValue_, bool _bind_)
		{
			this.name = _name_;
			this.type = _type_;
			this.typeKey = _typeKey_;
			this.typeValue = _typeValue_;
			this.bind = _bind_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.name);
			_os_.marshal(this.type);
			_os_.marshal(this.typeKey);
			_os_.marshal(this.typeValue);
			_os_.marshal(this.bind);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.name = _os_.unmarshal_int();
			this.type = _os_.unmarshal_int();
			this.typeKey = _os_.unmarshal_int();
			this.typeValue = _os_.unmarshal_int();
			this.bind = _os_.unmarshal_bool();
			return _os_;
		}
		public int CompareTo(VariantViewVariableDefine __o__)
		{
			if (__o__ == this)
				 return 0;
			int __c__ = 0;
			__c__ = this.name.CompareTo( __o__.name);
			if (0 != __c__)
				return __c__;
			__c__ = this.type.CompareTo( __o__.type);
			if (0 != __c__)
				return __c__;
			__c__ = this.typeKey.CompareTo( __o__.typeKey);
			if (0 != __c__)
				return __c__;
			__c__ = this.typeValue.CompareTo( __o__.typeValue);
			if (0 != __c__)
				return __c__;
			__c__ = this.bind.CompareTo( __o__.bind);
			if (0 != __c__)
				return __c__;
			return __c__;
		}
		public override bool Equals(object __o1__)
		{
			if(__o1__ == this)
				return true;
			if(__o1__.GetType() != this.GetType())
				return false;
			VariantViewVariableDefine __o__ = (VariantViewVariableDefine)__o1__;
			if (!Utils.equals(this.name, __o__.name))
				return false;
			if (!Utils.equals(this.type, __o__.type))
				return false;
			if (!Utils.equals(this.typeKey, __o__.typeKey))
				return false;
			if (!Utils.equals(this.typeValue, __o__.typeValue))
				return false;
			if (!Utils.equals(this.bind, __o__.bind))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.name.GetHashCode();
			__h__ += __h__ * 31 + this.type.GetHashCode();
			__h__ += __h__ * 31 + this.typeKey.GetHashCode();
			__h__ += __h__ * 31 + this.typeValue.GetHashCode();
			__h__ += __h__ * 31 + this.bind.GetHashCode();
			return __h__;
		}
	}
}
