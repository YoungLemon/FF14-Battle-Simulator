using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.providerglobalid
{
	public sealed class NameResponse : limax.codec.Marshal, IComparable<NameResponse>
	{
		public const int OK = 0;
		public const int DUPLICATE = 1;
		public const int NOTEXISTS = 2;
		public const int REJECT = 3;
		public const int DEADLOCK = 4;
		public int status;
		public long serial;
		public NameResponse()
		{
			status = 0;
			serial = 0;
		}
		public NameResponse(int _status_, long _serial_)
		{
			this.status = _status_;
			this.serial = _serial_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.status);
			_os_.marshal(this.serial);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.status = _os_.unmarshal_int();
			this.serial = _os_.unmarshal_long();
			return _os_;
		}
		public int CompareTo(NameResponse __o__)
		{
			if (__o__ == this)
				 return 0;
			int __c__ = 0;
			__c__ = this.status.CompareTo( __o__.status);
			if (0 != __c__)
				return __c__;
			__c__ = this.serial.CompareTo( __o__.serial);
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
			NameResponse __o__ = (NameResponse)__o1__;
			if (!Utils.equals(this.status, __o__.status))
				return false;
			if (!Utils.equals(this.serial, __o__.serial))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.status.GetHashCode();
			__h__ += __h__ * 31 + this.serial.GetHashCode();
			return __h__;
		}
	}
}
