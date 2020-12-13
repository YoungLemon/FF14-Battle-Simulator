using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.providerendpoint
{
	public sealed class ViewMemberData : limax.codec.Marshal
	{
		public long sessionid;
		public limax.providerendpoint.ViewVariableData vardata;
		public ViewMemberData()
		{
			sessionid = 0;
			vardata = new limax.providerendpoint.ViewVariableData();
		}
		public ViewMemberData(long _sessionid_, limax.providerendpoint.ViewVariableData _vardata_)
		{
			this.sessionid = _sessionid_;
			this.vardata = _vardata_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.sessionid);
			_os_.marshal(this.vardata);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.sessionid = _os_.unmarshal_long();
			_os_.unmarshal(this.vardata);
			return _os_;
		}
		public override bool Equals(object __o1__)
		{
			if(__o1__ == this)
				return true;
			if(__o1__.GetType() != this.GetType())
				return false;
			ViewMemberData __o__ = (ViewMemberData)__o1__;
			if (!Utils.equals(this.sessionid, __o__.sessionid))
				return false;
			if (!Utils.equals(this.vardata, __o__.vardata))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.sessionid.GetHashCode();
			__h__ += __h__ * 31 + this.vardata.GetHashCode();
			return __h__;
		}
	}
}
