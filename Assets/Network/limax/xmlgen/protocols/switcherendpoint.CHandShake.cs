using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.endpoint.switcherendpoint
{
	public sealed partial class CHandShake : limax.net.Protocol
	{
		public static int TYPE;
		override public int getType()
		{
			return TYPE;
		}
		public byte dh_group;
		public limax.codec.Octets dh_data;
		public CHandShake()
		{
			dh_group = 0;
			dh_data = new limax.codec.Octets();
		}
		public CHandShake(byte _dh_group_, limax.codec.Octets _dh_data_)
		{
			this.dh_group = _dh_group_;
			this.dh_data = _dh_data_;
		}
		public override OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.dh_group);
			_os_.marshal(this.dh_data);
			return _os_;
		}
		public override OctetsStream unmarshal(OctetsStream _os_)
		{
			this.dh_group = _os_.unmarshal_byte();
			this.dh_data = _os_.unmarshal_Octets();
			return _os_;
		}
	}
}
