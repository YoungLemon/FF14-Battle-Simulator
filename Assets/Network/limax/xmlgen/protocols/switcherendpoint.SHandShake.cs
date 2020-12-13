using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.endpoint.switcherendpoint
{
	public sealed partial class SHandShake : limax.net.Protocol
	{
		public static int TYPE;
		override public int getType()
		{
			return TYPE;
		}
		public limax.codec.Octets dh_data;
		public bool s2cneedcompress;
		public bool c2sneedcompress;
		public SHandShake()
		{
			dh_data = new limax.codec.Octets();
			s2cneedcompress = false;
			c2sneedcompress = false;
		}
		public SHandShake(limax.codec.Octets _dh_data_, bool _s2cneedcompress_, bool _c2sneedcompress_)
		{
			this.dh_data = _dh_data_;
			this.s2cneedcompress = _s2cneedcompress_;
			this.c2sneedcompress = _c2sneedcompress_;
		}
		public override OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.dh_data);
			_os_.marshal(this.s2cneedcompress);
			_os_.marshal(this.c2sneedcompress);
			return _os_;
		}
		public override OctetsStream unmarshal(OctetsStream _os_)
		{
			this.dh_data = _os_.unmarshal_Octets();
			this.s2cneedcompress = _os_.unmarshal_bool();
			this.c2sneedcompress = _os_.unmarshal_bool();
			return _os_;
		}
	}
}
