using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.switcherprovider
{
	public sealed class ProbeValue : limax.codec.Marshal, IComparable<ProbeValue>
	{
		public long key;
		public ProbeValue()
		{
			key = 0;
		}
		public ProbeValue(long _key_)
		{
			this.key = _key_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.key);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.key = _os_.unmarshal_long();
			return _os_;
		}
		public int CompareTo(ProbeValue __o__)
		{
			if (__o__ == this)
				 return 0;
			int __c__ = 0;
			__c__ = this.key.CompareTo( __o__.key);
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
			ProbeValue __o__ = (ProbeValue)__o1__;
			if (!Utils.equals(this.key, __o__.key))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.key.GetHashCode();
			return __h__;
		}
	}
}
