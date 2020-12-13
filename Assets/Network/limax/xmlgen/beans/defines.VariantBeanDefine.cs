using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.defines
{
	public sealed class VariantBeanDefine : limax.codec.Marshal
	{
		public int type;
		public List<limax.defines.VariantVariableDefine> vars;
		public VariantBeanDefine()
		{
			type = 0;
			vars = new List<limax.defines.VariantVariableDefine>();
		}
		public VariantBeanDefine(int _type_, List<limax.defines.VariantVariableDefine> _vars_)
		{
			this.type = _type_;
			this.vars = _vars_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.type);
			_os_.marshal_size(this.vars.Count);
			foreach(var __v__ in this.vars)
				_os_.marshal(__v__);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.type = _os_.unmarshal_int();
			for(int _i_ = _os_.unmarshal_size(); _i_ > 0; --_i_)
			{
				limax.defines.VariantVariableDefine _v_ = new limax.defines.VariantVariableDefine();
				_v_.unmarshal(_os_);
				this.vars.Add(_v_);
			}
			return _os_;
		}
		public override bool Equals(object __o1__)
		{
			if(__o1__ == this)
				return true;
			if(__o1__.GetType() != this.GetType())
				return false;
			VariantBeanDefine __o__ = (VariantBeanDefine)__o1__;
			if (!Utils.equals(this.type, __o__.type))
				return false;
			if (!Utils.equals(this.vars, __o__.vars))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.type.GetHashCode();
			__h__ += __h__ * 31 + Utils.hashCode(this.vars);
			return __h__;
		}
	}
}
