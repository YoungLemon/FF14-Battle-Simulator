using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.providerglobalid
{
	public sealed class Group : limax.codec.Marshal, IComparable<Group>
	{
		public string grp;
		public Group()
		{
			grp = "";
		}
		public Group(string _grp_)
		{
			this.grp = _grp_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.grp);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.grp = _os_.unmarshal_string();
			return _os_;
		}
		public int CompareTo(Group __o__)
		{
			if (__o__ == this)
				 return 0;
			int __c__ = 0;
			__c__ = this.grp.CompareTo( __o__.grp);
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
			Group __o__ = (Group)__o1__;
			if (!Utils.equals(this.grp, __o__.grp))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.grp.GetHashCode();
			return __h__;
		}
	}
}
