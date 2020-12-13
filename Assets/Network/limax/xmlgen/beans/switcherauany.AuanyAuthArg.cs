using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.switcherauany
{
	public sealed class AuanyAuthArg : limax.codec.Marshal
	{
		public const int ST_SOCKET = 0;
		public const int ST_WEBSOCKET = 1;
		public string username;
		public string token;
		public string platflag;
		public Dictionary<int, byte> pvids;
		public limax.codec.Octets clientaddress;
		public byte sockettype;
		public AuanyAuthArg()
		{
			username = "";
			token = "";
			platflag = "";
			pvids = new Dictionary<int, byte>();
			clientaddress = new limax.codec.Octets();
			sockettype = 0;
		}
		public AuanyAuthArg(string _username_, string _token_, string _platflag_, Dictionary<int, byte> _pvids_, limax.codec.Octets _clientaddress_, byte _sockettype_)
		{
			this.username = _username_;
			this.token = _token_;
			this.platflag = _platflag_;
			this.pvids = _pvids_;
			this.clientaddress = _clientaddress_;
			this.sockettype = _sockettype_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.username);
			_os_.marshal(this.token);
			_os_.marshal(this.platflag);
			_os_.marshal_size(this.pvids.Count);
			foreach(var __v__ in this.pvids)
			{
				_os_.marshal(__v__.Key);
				_os_.marshal(__v__.Value);
			}
			_os_.marshal(this.clientaddress);
			_os_.marshal(this.sockettype);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.username = _os_.unmarshal_string();
			this.token = _os_.unmarshal_string();
			this.platflag = _os_.unmarshal_string();
			for(int _i_ = _os_.unmarshal_size(); _i_ > 0; --_i_)
			{
				int _k_ = _os_.unmarshal_int();
				byte _v_ = _os_.unmarshal_byte();
				this.pvids[_k_] = _v_;
			}
			this.clientaddress = _os_.unmarshal_Octets();
			this.sockettype = _os_.unmarshal_byte();
			return _os_;
		}
		public override bool Equals(object __o1__)
		{
			if(__o1__ == this)
				return true;
			if(__o1__.GetType() != this.GetType())
				return false;
			AuanyAuthArg __o__ = (AuanyAuthArg)__o1__;
			if (!Utils.equals(this.username, __o__.username))
				return false;
			if (!Utils.equals(this.token, __o__.token))
				return false;
			if (!Utils.equals(this.platflag, __o__.platflag))
				return false;
			if (!Utils.equals(this.pvids, __o__.pvids))
				return false;
			if (!Utils.equals(this.clientaddress, __o__.clientaddress))
				return false;
			if (!Utils.equals(this.sockettype, __o__.sockettype))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.username.GetHashCode();
			__h__ += __h__ * 31 + this.token.GetHashCode();
			__h__ += __h__ * 31 + this.platflag.GetHashCode();
			__h__ += __h__ * 31 + Utils.hashCode(this.pvids);
			__h__ += __h__ * 31 + this.clientaddress.GetHashCode();
			__h__ += __h__ * 31 + this.sockettype.GetHashCode();
			return __h__;
		}
	}
}
