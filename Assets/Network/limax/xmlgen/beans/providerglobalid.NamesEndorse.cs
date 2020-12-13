using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.providerglobalid
{
	public sealed class NamesEndorse : limax.codec.Marshal, IComparable<NamesEndorse>
	{
		public const int COMMIT = 1;
		public const int ROLLBACK = 2;
		public int type;
		public int tid;
		public NamesEndorse()
		{
			type = 0;
			tid = 0;
		}
		public NamesEndorse(int _type_, int _tid_)
		{
			this.type = _type_;
			this.tid = _tid_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.type);
			_os_.marshal(this.tid);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.type = _os_.unmarshal_int();
			this.tid = _os_.unmarshal_int();
			return _os_;
		}
		public int CompareTo(NamesEndorse __o__)
		{
			if (__o__ == this)
				 return 0;
			int __c__ = 0;
			__c__ = this.type.CompareTo( __o__.type);
			if (0 != __c__)
				return __c__;
			__c__ = this.tid.CompareTo( __o__.tid);
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
			NamesEndorse __o__ = (NamesEndorse)__o1__;
			if (!Utils.equals(this.type, __o__.type))
				return false;
			if (!Utils.equals(this.tid, __o__.tid))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.type.GetHashCode();
			__h__ += __h__ * 31 + this.tid.GetHashCode();
			return __h__;
		}
	}
}
