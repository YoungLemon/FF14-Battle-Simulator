using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.defines
{
	public sealed class SessionFlags : limax.codec.Marshal, IComparable<SessionFlags>
	{
		public const long FLAG_ACCOUNT_BOUND = 1L;
		public const long FLAG_TEMPORARY_LOGIN = 2L;
		public const long FLAG_CAN_PORT_FORWARD = 4L;
		public SessionFlags()
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
		public int CompareTo(SessionFlags __o__)
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
