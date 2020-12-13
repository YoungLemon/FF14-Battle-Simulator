using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.endpoint.switcherendpoint
{
	public sealed partial class PortForward : limax.net.Protocol
	{
		public static int TYPE;
		override public int getType()
		{
			return TYPE;
		}
		public const int eConnect = 1;
		public const int eClose = 2;
		public const int eForward = 3;
		public const int eForwardAck = 4;
		public const int eAuthority = 5;
		public const int eConnectV0 = 0;
		public const int eCloseUnknownConnectVersion = 1;
		public const int eCloseUnknownForwardType = 2;
		public const int eCloseForwardPortNotFound = 3;
		public const int eCloseConnectDuplicatePort = 4;
		public const int eCloseSessionAbort = 5;
		public const int eCloseSessionClose = 6;
		public const int eCloseForwardAckPortNotFound = 7;
		public const int eCloseManualClosed = 8;
		public const int eCloseNoAuthority = 9;
		public const int eForwardRaw = 0;
		public int command;
		public int portsid;
		public int code;
		public limax.codec.Octets data;
		public PortForward()
		{
			command = 0;
			portsid = 0;
			code = 0;
			data = new limax.codec.Octets();
		}
		public PortForward(int _command_, int _portsid_, int _code_, limax.codec.Octets _data_)
		{
			this.command = _command_;
			this.portsid = _portsid_;
			this.code = _code_;
			this.data = _data_;
		}
		public override OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.command);
			_os_.marshal(this.portsid);
			_os_.marshal(this.code);
			_os_.marshal(this.data);
			return _os_;
		}
		public override OctetsStream unmarshal(OctetsStream _os_)
		{
			this.command = _os_.unmarshal_int();
			this.portsid = _os_.unmarshal_int();
			this.code = _os_.unmarshal_int();
			this.data = _os_.unmarshal_Octets();
			return _os_;
		}
	}
}
