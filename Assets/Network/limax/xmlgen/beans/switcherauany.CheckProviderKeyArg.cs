using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.switcherauany
{
	public sealed class CheckProviderKeyArg : limax.codec.Marshal, IComparable<CheckProviderKeyArg>
	{
		public int pvid;
		public string pvkey;
		public bool paySupported;
		public string json;
		public CheckProviderKeyArg()
		{
			pvid = 0;
			pvkey = "";
			paySupported = false;
			json = "";
		}
		public CheckProviderKeyArg(int _pvid_, string _pvkey_, bool _paySupported_, string _json_)
		{
			this.pvid = _pvid_;
			this.pvkey = _pvkey_;
			this.paySupported = _paySupported_;
			this.json = _json_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.pvid);
			_os_.marshal(this.pvkey);
			_os_.marshal(this.paySupported);
			_os_.marshal(this.json);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.pvid = _os_.unmarshal_int();
			this.pvkey = _os_.unmarshal_string();
			this.paySupported = _os_.unmarshal_bool();
			this.json = _os_.unmarshal_string();
			return _os_;
		}
		public int CompareTo(CheckProviderKeyArg __o__)
		{
			if (__o__ == this)
				 return 0;
			int __c__ = 0;
			__c__ = this.pvid.CompareTo( __o__.pvid);
			if (0 != __c__)
				return __c__;
			__c__ = this.pvkey.CompareTo( __o__.pvkey);
			if (0 != __c__)
				return __c__;
			__c__ = this.paySupported.CompareTo( __o__.paySupported);
			if (0 != __c__)
				return __c__;
			__c__ = this.json.CompareTo( __o__.json);
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
			CheckProviderKeyArg __o__ = (CheckProviderKeyArg)__o1__;
			if (!Utils.equals(this.pvid, __o__.pvid))
				return false;
			if (!Utils.equals(this.pvkey, __o__.pvkey))
				return false;
			if (!Utils.equals(this.paySupported, __o__.paySupported))
				return false;
			if (!Utils.equals(this.json, __o__.json))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.pvid.GetHashCode();
			__h__ += __h__ * 31 + this.pvkey.GetHashCode();
			__h__ += __h__ * 31 + this.paySupported.GetHashCode();
			__h__ += __h__ * 31 + this.json.GetHashCode();
			return __h__;
		}
	}
}
