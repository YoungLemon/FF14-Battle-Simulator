using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.providerglobalid
{
	public sealed class GroupName : limax.codec.Marshal, IComparable<GroupName>
	{
		public string grp;
		public string name;
		public GroupName()
		{
			grp = "";
			name = "";
		}
		public GroupName(string _grp_, string _name_)
		{
			this.grp = _grp_;
			this.name = _name_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.grp);
			_os_.marshal(this.name);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.grp = _os_.unmarshal_string();
			this.name = _os_.unmarshal_string();
			return _os_;
		}
		public int CompareTo(GroupName __o__)
		{
			if (__o__ == this)
				 return 0;
			int __c__ = 0;
			__c__ = this.grp.CompareTo( __o__.grp);
			if (0 != __c__)
				return __c__;
			__c__ = this.name.CompareTo( __o__.name);
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
			GroupName __o__ = (GroupName)__o1__;
			if (!Utils.equals(this.grp, __o__.grp))
				return false;
			if (!Utils.equals(this.name, __o__.name))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.grp.GetHashCode();
			__h__ += __h__ * 31 + this.name.GetHashCode();
			return __h__;
		}
	}
}
