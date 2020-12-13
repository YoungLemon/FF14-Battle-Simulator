using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.endpoint.switcherendpoint
{
	public sealed partial class SessionLoginByToken : limax.net.Protocol
	{
		public static int TYPE;
		override public int getType()
		{
			return TYPE;
		}
		public string username;
		public string token;
		public string platflag;
		public Dictionary<int, byte> pvids;
		public limax.codec.Octets report_ip;
		public short report_port;
		public SessionLoginByToken()
		{
			username = "";
			token = "";
			platflag = "";
			pvids = new Dictionary<int, byte>();
			report_ip = new limax.codec.Octets();
			report_port = 0;
		}
		public SessionLoginByToken(string _username_, string _token_, string _platflag_, Dictionary<int, byte> _pvids_, limax.codec.Octets _report_ip_, short _report_port_)
		{
			this.username = _username_;
			this.token = _token_;
			this.platflag = _platflag_;
			this.pvids = _pvids_;
			this.report_ip = _report_ip_;
			this.report_port = _report_port_;
		}
		public override OctetsStream marshal(OctetsStream _os_)
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
			_os_.marshal(this.report_ip);
			_os_.marshal(this.report_port);
			return _os_;
		}
		public override OctetsStream unmarshal(OctetsStream _os_)
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
			this.report_ip = _os_.unmarshal_Octets();
			this.report_port = _os_.unmarshal_short();
			return _os_;
		}
	}
}
