using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.endpoint.providerendpoint
{
	public sealed partial class SendControlToServer : limax.net.Protocol
	{
		public static int TYPE;
		override public int getType()
		{
			return TYPE;
		}
		public int providerid;
		public long sessionid;
		public short classindex;
		public int instanceindex;
		public byte controlindex;
		public limax.codec.Octets controlparameter;
		public string stringdata;
		public SendControlToServer()
		{
			providerid = 0;
			sessionid = 0;
			classindex = 0;
			instanceindex = 0;
			controlindex = 0;
			controlparameter = new limax.codec.Octets();
			stringdata = "";
		}
		public SendControlToServer(int _providerid_, long _sessionid_, short _classindex_, int _instanceindex_, byte _controlindex_, limax.codec.Octets _controlparameter_, string _stringdata_)
		{
			this.providerid = _providerid_;
			this.sessionid = _sessionid_;
			this.classindex = _classindex_;
			this.instanceindex = _instanceindex_;
			this.controlindex = _controlindex_;
			this.controlparameter = _controlparameter_;
			this.stringdata = _stringdata_;
		}
		public override OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.providerid);
			_os_.marshal(this.sessionid);
			_os_.marshal(this.classindex);
			_os_.marshal(this.instanceindex);
			_os_.marshal(this.controlindex);
			_os_.marshal(this.controlparameter);
			_os_.marshal(this.stringdata);
			return _os_;
		}
		public override OctetsStream unmarshal(OctetsStream _os_)
		{
			this.providerid = _os_.unmarshal_int();
			this.sessionid = _os_.unmarshal_long();
			this.classindex = _os_.unmarshal_short();
			this.instanceindex = _os_.unmarshal_int();
			this.controlindex = _os_.unmarshal_byte();
			this.controlparameter = _os_.unmarshal_Octets();
			this.stringdata = _os_.unmarshal_string();
			return _os_;
		}
	}
}
