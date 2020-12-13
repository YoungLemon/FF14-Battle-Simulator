using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.providerglobalid
{
	public sealed class Id : limax.codec.Marshal, IComparable<Id>
	{
		public long val;
		public Id()
		{
			val = 0;
		}
		public Id(long _val_)
		{
			this.val = _val_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.val);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.val = _os_.unmarshal_long();
			return _os_;
		}
		public int CompareTo(Id __o__)
		{
			if (__o__ == this)
				 return 0;
			int __c__ = 0;
			__c__ = this.val.CompareTo( __o__.val);
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
			Id __o__ = (Id)__o1__;
			if (!Utils.equals(this.val, __o__.val))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.val.GetHashCode();
			return __h__;
		}
	}
}
