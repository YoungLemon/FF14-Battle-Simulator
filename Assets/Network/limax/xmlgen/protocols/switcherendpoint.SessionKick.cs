using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.endpoint.switcherendpoint
{
	public sealed partial class SessionKick : limax.net.Protocol
	{
		public static int TYPE;
		override public int getType()
		{
			return TYPE;
		}
		public int error;
		public SessionKick()
		{
			error = 0;
		}
		public SessionKick(int _error_)
		{
			this.error = _error_;
		}
		public override OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.error);
			return _os_;
		}
		public override OctetsStream unmarshal(OctetsStream _os_)
		{
			this.error = _os_.unmarshal_int();
			return _os_;
		}
	}
}
