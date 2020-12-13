using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.defines
{
	public sealed class GlobalIdFlags : limax.codec.Marshal, IComparable<GlobalIdFlags>
	{
		public const int GLOBALID_OK = 0;
		public const int GLOBALID_DUPLICATE = 1;
		public const int GLOBALID_NOT_EXISTS = 2;
		public const int GLOBALID_REJECT = 3;
		public GlobalIdFlags()
		{
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			return _os_;
		}
		public int CompareTo(GlobalIdFlags __o__)
		{
			if (__o__ == this)
				 return 0;
			int __c__ = 0;
			return __c__;
		}
		public override bool Equals(object __o1__)
		{
			if(__o1__ == this)
				return true;
			if(__o1__.GetType() != this.GetType())
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			return __h__;
		}
	}
}
