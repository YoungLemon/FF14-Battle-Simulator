using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.defines
{
	public sealed class VariantNameIds : limax.codec.Marshal
	{
		public List<int> ids;
		public VariantNameIds()
		{
			ids = new List<int>();
		}
		public VariantNameIds(List<int> _ids_)
		{
			this.ids = _ids_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal_size(this.ids.Count);
			foreach(var __v__ in this.ids)
				_os_.marshal(__v__);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			for(int _i_ = _os_.unmarshal_size(); _i_ > 0; --_i_)
			{
				int _v_ = _os_.unmarshal_int();
				this.ids.Add(_v_);
			}
			return _os_;
		}
		public override bool Equals(object __o1__)
		{
			if(__o1__ == this)
				return true;
			if(__o1__.GetType() != this.GetType())
				return false;
			VariantNameIds __o__ = (VariantNameIds)__o1__;
			if (!Utils.equals(this.ids, __o__.ids))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + Utils.hashCode(this.ids);
			return __h__;
		}
	}
}
