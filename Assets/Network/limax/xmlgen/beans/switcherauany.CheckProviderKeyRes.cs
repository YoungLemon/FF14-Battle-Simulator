using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.switcherauany
{
	public sealed class CheckProviderKeyRes : limax.codec.Marshal, IComparable<CheckProviderKeyRes>
	{
		public int error;
		public long jsonPublishDelayMin;
		public CheckProviderKeyRes()
		{
			error = 0;
			jsonPublishDelayMin = 0;
		}
		public CheckProviderKeyRes(int _error_, long _jsonPublishDelayMin_)
		{
			this.error = _error_;
			this.jsonPublishDelayMin = _jsonPublishDelayMin_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.error);
			_os_.marshal(this.jsonPublishDelayMin);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.error = _os_.unmarshal_int();
			this.jsonPublishDelayMin = _os_.unmarshal_long();
			return _os_;
		}
		public int CompareTo(CheckProviderKeyRes __o__)
		{
			if (__o__ == this)
				 return 0;
			int __c__ = 0;
			__c__ = this.error.CompareTo( __o__.error);
			if (0 != __c__)
				return __c__;
			__c__ = this.jsonPublishDelayMin.CompareTo( __o__.jsonPublishDelayMin);
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
			CheckProviderKeyRes __o__ = (CheckProviderKeyRes)__o1__;
			if (!Utils.equals(this.error, __o__.error))
				return false;
			if (!Utils.equals(this.jsonPublishDelayMin, __o__.jsonPublishDelayMin))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.error.GetHashCode();
			__h__ += __h__ * 31 + this.jsonPublishDelayMin.GetHashCode();
			return __h__;
		}
	}
}
