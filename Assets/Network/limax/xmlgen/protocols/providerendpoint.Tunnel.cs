using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.endpoint.providerendpoint
{
	public sealed partial class Tunnel : limax.net.Protocol
	{
		public static int TYPE;
		override public int getType()
		{
			return TYPE;
		}
		public int providerid;
		public long sessionid;
		public int label;
		public limax.codec.Octets data;
		public Tunnel()
		{
			providerid = 0;
			sessionid = 0;
			label = 0;
			data = new limax.codec.Octets();
		}
		public Tunnel(int _providerid_, long _sessionid_, int _label_, limax.codec.Octets _data_)
		{
			this.providerid = _providerid_;
			this.sessionid = _sessionid_;
			this.label = _label_;
			this.data = _data_;
		}
		public override OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.providerid);
			_os_.marshal(this.sessionid);
			_os_.marshal(this.label);
			_os_.marshal(this.data);
			return _os_;
		}
		public override OctetsStream unmarshal(OctetsStream _os_)
		{
			this.providerid = _os_.unmarshal_int();
			this.sessionid = _os_.unmarshal_long();
			this.label = _os_.unmarshal_int();
			this.data = _os_.unmarshal_Octets();
			return _os_;
		}
	}
}
