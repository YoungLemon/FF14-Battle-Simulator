using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.providerglobalid
{
	public sealed class NameRequest : limax.codec.Marshal, IComparable<NameRequest>
	{
		public const int CREATE = 1;
		public const int DELETE = 2;
		public const int TEST = 3;
		public limax.providerglobalid.GroupName gn;
		public int type;
		public long serial;
		public NameRequest()
		{
			gn = new limax.providerglobalid.GroupName();
			type = 0;
			serial = 0;
		}
		public NameRequest(limax.providerglobalid.GroupName _gn_, int _type_, long _serial_)
		{
			this.gn = _gn_;
			this.type = _type_;
			this.serial = _serial_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.gn);
			_os_.marshal(this.type);
			_os_.marshal(this.serial);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			_os_.unmarshal(this.gn);
			this.type = _os_.unmarshal_int();
			this.serial = _os_.unmarshal_long();
			return _os_;
		}
		public int CompareTo(NameRequest __o__)
		{
			if (__o__ == this)
				 return 0;
			int __c__ = 0;
			__c__ = this.gn.CompareTo( __o__.gn);
			if (0 != __c__)
				return __c__;
			__c__ = this.type.CompareTo( __o__.type);
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
			NameRequest __o__ = (NameRequest)__o1__;
			if (!Utils.equals(this.gn, __o__.gn))
				return false;
			if (!Utils.equals(this.type, __o__.type))
				return false;
			if (!Utils.equals(this.serial, __o__.serial))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.gn.GetHashCode();
			__h__ += __h__ * 31 + this.type.GetHashCode();
			__h__ += __h__ * 31 + this.serial.GetHashCode();
			return __h__;
		}
	}
}
