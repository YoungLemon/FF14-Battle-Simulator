using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.endpoint.switcherendpoint
{
	public sealed partial class ProviderLogin : limax.net.Protocol
	{
		public static int TYPE;
		override public int getType()
		{
			return TYPE;
		}
		public limax.defines.ProviderLoginData data;
		public ProviderLogin()
		{
			data = new limax.defines.ProviderLoginData();
		}
		public ProviderLogin(limax.defines.ProviderLoginData _data_)
		{
			this.data = _data_;
		}
		public override OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.data);
			return _os_;
		}
		public override OctetsStream unmarshal(OctetsStream _os_)
		{
			_os_.unmarshal(this.data);
			return _os_;
		}
	}
}
