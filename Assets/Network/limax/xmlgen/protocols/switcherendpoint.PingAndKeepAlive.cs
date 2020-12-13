using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.endpoint.switcherendpoint
{
	public sealed partial class PingAndKeepAlive : limax.net.Protocol
	{
		public static int TYPE;
		override public int getType()
		{
			return TYPE;
		}
		public long timestamp;
		public PingAndKeepAlive()
		{
			timestamp = 0;
		}
		public PingAndKeepAlive(long _timestamp_)
		{
			this.timestamp = _timestamp_;
		}
		public override OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.timestamp);
			return _os_;
		}
		public override OctetsStream unmarshal(OctetsStream _os_)
		{
			this.timestamp = _os_.unmarshal_long();
			return _os_;
		}
	}
}
