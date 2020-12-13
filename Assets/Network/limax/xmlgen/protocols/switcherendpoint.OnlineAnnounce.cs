using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.endpoint.switcherendpoint
{
	public sealed partial class OnlineAnnounce : limax.net.Protocol
	{
		public static int TYPE;
		override public int getType()
		{
			return TYPE;
		}
		public int errorSource;
		public int errorCode;
		public long sessionid;
		public long flags;
		public Dictionary<int, limax.defines.VariantDefines> variantdefines;
		public string scriptdefines;
		public limax.codec.Octets lmkdata;
		public OnlineAnnounce()
		{
			errorSource = 0;
			errorCode = 0;
			sessionid = 0;
			flags = 0;
			variantdefines = new Dictionary<int, limax.defines.VariantDefines>();
			scriptdefines = "";
			lmkdata = new limax.codec.Octets();
		}
		public OnlineAnnounce(int _errorSource_, int _errorCode_, long _sessionid_, long _flags_, Dictionary<int, limax.defines.VariantDefines> _variantdefines_, string _scriptdefines_, limax.codec.Octets _lmkdata_)
		{
			this.errorSource = _errorSource_;
			this.errorCode = _errorCode_;
			this.sessionid = _sessionid_;
			this.flags = _flags_;
			this.variantdefines = _variantdefines_;
			this.scriptdefines = _scriptdefines_;
			this.lmkdata = _lmkdata_;
		}
		public override OctetsStream marshal(OctetsStream _os_)
		{
			_os_.marshal(this.errorSource);
			_os_.marshal(this.errorCode);
			_os_.marshal(this.sessionid);
			_os_.marshal(this.flags);
			_os_.marshal_size(this.variantdefines.Count);
			foreach(var __v__ in this.variantdefines)
			{
				_os_.marshal(__v__.Key);
				_os_.marshal(__v__.Value);
			}
			_os_.marshal(this.scriptdefines);
			_os_.marshal(this.lmkdata);
			return _os_;
		}
		public override OctetsStream unmarshal(OctetsStream _os_)
		{
			this.errorSource = _os_.unmarshal_int();
			this.errorCode = _os_.unmarshal_int();
			this.sessionid = _os_.unmarshal_long();
			this.flags = _os_.unmarshal_long();
			for(int _i_ = _os_.unmarshal_size(); _i_ > 0; --_i_)
			{
				int _k_ = _os_.unmarshal_int();
				limax.defines.VariantDefines _v_ = new limax.defines.VariantDefines();
				_v_.unmarshal(_os_);
				this.variantdefines[_k_] = _v_;
			}
			this.scriptdefines = _os_.unmarshal_string();
			this.lmkdata = _os_.unmarshal_Octets();
			return _os_;
		}
	}
}
