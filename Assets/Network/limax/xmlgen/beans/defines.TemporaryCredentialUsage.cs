using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.defines
{
	public sealed class TemporaryCredentialUsage : limax.codec.Marshal, IComparable<TemporaryCredentialUsage>
	{
		public const byte USAGE_LOGIN = 1;
		public const byte USAGE_TRANSFER = 2;
		public TemporaryCredentialUsage()
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
		public int CompareTo(TemporaryCredentialUsage __o__)
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
