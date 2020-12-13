using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.auanyviews
{
	public sealed class Result : limax.codec.Marshal, IComparable<Result>
	{
		public int sn;
		public int errorSource;
		public int errorCode;
		public string result;
		public Result()
		{
			sn = 0;
			errorSource = 0;
			errorCode = 0;
			result = "";
		}
		public Result(int _sn_, int _errorSource_, int _errorCode_, string _result_)
		{
			this.sn = _sn_;
			this.errorSource = _errorSource_;
			this.errorCode = _errorCode_;
			this.result = _result_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.sn);
			_os_.marshal(this.errorSource);
			_os_.marshal(this.errorCode);
			_os_.marshal(this.result);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.sn = _os_.unmarshal_int();
			this.errorSource = _os_.unmarshal_int();
			this.errorCode = _os_.unmarshal_int();
			this.result = _os_.unmarshal_string();
			return _os_;
		}
		public int CompareTo(Result __o__)
		{
			if (__o__ == this)
				 return 0;
			int __c__ = 0;
			__c__ = this.sn.CompareTo( __o__.sn);
			if (0 != __c__)
				return __c__;
			__c__ = this.errorSource.CompareTo( __o__.errorSource);
			if (0 != __c__)
				return __c__;
			__c__ = this.errorCode.CompareTo( __o__.errorCode);
			if (0 != __c__)
				return __c__;
			__c__ = this.result.CompareTo( __o__.result);
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
			Result __o__ = (Result)__o1__;
			if (!Utils.equals(this.sn, __o__.sn))
				return false;
			if (!Utils.equals(this.errorSource, __o__.errorSource))
				return false;
			if (!Utils.equals(this.errorCode, __o__.errorCode))
				return false;
			if (!Utils.equals(this.result, __o__.result))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.sn.GetHashCode();
			__h__ += __h__ * 31 + this.errorSource.GetHashCode();
			__h__ += __h__ * 31 + this.errorCode.GetHashCode();
			__h__ += __h__ * 31 + this.result.GetHashCode();
			return __h__;
		}
	}
}
