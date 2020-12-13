using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.defines
{
	public sealed class ProviderLoginData : limax.codec.Marshal
	{
		public const int tUnused = 0;
		public const int tTunnelData = 1;
		public const int tUserData = 2;
		public int pvid;
		public int type;
		public int label;
		public limax.codec.Octets data;
		public ProviderLoginData()
		{
			pvid = 0;
			type = 0;
			label = 0;
			data = new limax.codec.Octets();
		}
		public ProviderLoginData(int _pvid_, int _type_, int _label_, limax.codec.Octets _data_)
		{
			this.pvid = _pvid_;
			this.type = _type_;
			this.label = _label_;
			this.data = _data_;
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.pvid);
			_os_.marshal(this.type);
			_os_.marshal(this.label);
			_os_.marshal(this.data);
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			this.pvid = _os_.unmarshal_int();
			this.type = _os_.unmarshal_int();
			this.label = _os_.unmarshal_int();
			this.data = _os_.unmarshal_Octets();
			return _os_;
		}
		public override bool Equals(object __o1__)
		{
			if(__o1__ == this)
				return true;
			if(__o1__.GetType() != this.GetType())
				return false;
			ProviderLoginData __o__ = (ProviderLoginData)__o1__;
			if (!Utils.equals(this.pvid, __o__.pvid))
				return false;
			if (!Utils.equals(this.type, __o__.type))
				return false;
			if (!Utils.equals(this.label, __o__.label))
				return false;
			if (!Utils.equals(this.data, __o__.data))
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			__h__ += __h__ * 31 + this.pvid.GetHashCode();
			__h__ += __h__ * 31 + this.type.GetHashCode();
			__h__ += __h__ * 31 + this.label.GetHashCode();
			__h__ += __h__ * 31 + this.data.GetHashCode();
			return __h__;
		}
	}
}
