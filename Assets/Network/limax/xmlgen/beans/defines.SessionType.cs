using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.defines
{
	public sealed class SessionType : limax.codec.Marshal, IComparable<SessionType>
	{
		public const byte ST_PROTOCOL = 0;
		public const byte ST_STATIC = 1;
		public const byte ST_VARIANT = 2;
		public const byte ST_SCRIPT = 4;
		public const byte ST_WEB_SOCKET = 8;
		public const byte ST_STATELESS = 16;
		public SessionType()
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
		public int CompareTo(SessionType __o__)
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
