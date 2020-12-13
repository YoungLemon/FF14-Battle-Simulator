using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.switcherauany
{
	public sealed class AuanyAuthRes : limax.codec.Marshal
	{
		public int errorSource;
		public int errorCode;
		public long sessionid;
		public long mainid;
		public string uid;
		public long flags;
		public limax.codec.Octets lmkdata;
		public AuanyAuthRes()
		{
			errorSource = 0;
			errorCode = 0;
			sessionid = 0;
			mainid = 0;
			uid = "";
			flags = 0;
			lmkdata = new limax.codec.Octets();
		}
		public AuanyAuthRes(int _errorSource_, int _errorCode_, long _sessionid_, long _mainid_, string _uid_, long _flags_, limax.codec.Octets _lmkdata_)
		{
			this.errorSource = _errorSource_;
			this.errorCode = _errorCode_;
			this.sessionid = _sessionid_;
			this.mainid = _mainid_;
			this.uid = _uid_;
			this.flags = _flags_;
			this.lmkdata = _lmkdata_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.errorSource);
			_os_.marshal(this.errorCode);
			_os_.marshal(this.sessionid);
			_os_.marshal(this.mainid);
			_os_.marshal(this.uid);
			_os_.marshal(this.flags);
			_os_.marshal(this.lmkdata);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.errorSource = _os_.unmarshal_int();
			this.errorCode = _os_.unmarshal_int();
			this.sessionid = _os_.unmarshal_long();
			this.mainid = _os_.unmarshal_long();
			this.uid = _os_.unmarshal_string();
			this.flags = _os_.unmarshal_long();
			this.lmkdata = _os_.unmarshal_Octets();
			return _os_;
		}
		public override bool Equals(object __o1__)
		{
			if(__o1__ == this)
				return true;
			if(__o1__.GetType() != this.GetType())
				return false;
			AuanyAuthRes __o__ = (AuanyAuthRes)__o1__;
			if (!Utils.equals(this.errorSource, __o__.errorSource))
				return false;
			if (!Utils.equals(this.errorCode, __o__.errorCode))
				return false;
			if (!Utils.equals(this.sessionid, __o__.sessionid))
				return false;
			if (!Utils.equals(this.mainid, __o__.mainid))
				return false;
			if (!Utils.equals(this.uid, __o__.uid))
				return false;
			if (!Utils.equals(this.flags, __o__.flags))
				return false;
			if (!Utils.equals(this.lmkdata, __o__.lmkdata))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.errorSource.GetHashCode();
			__h__ += __h__ * 31 + this.errorCode.GetHashCode();
			__h__ += __h__ * 31 + this.sessionid.GetHashCode();
			__h__ += __h__ * 31 + this.mainid.GetHashCode();
			__h__ += __h__ * 31 + this.uid.GetHashCode();
			__h__ += __h__ * 31 + this.flags.GetHashCode();
			__h__ += __h__ * 31 + this.lmkdata.GetHashCode();
			return __h__;
		}
	}
}
