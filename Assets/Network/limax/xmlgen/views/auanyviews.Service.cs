using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
using limax.endpoint;
namespace limax.endpoint.auanyviews
{
	public sealed class Service : View
	{
		private static int __pvid__;
		internal Service(ViewContext vc) : base(vc) { __pvid__ = vc.getProviderId(); }
		override public short getClassIndex()
		{
			return 0;
		}
		protected override void onData(long sessionid, byte index, byte field, Octets data, Octets dataremoved)
		{
		}
		static private ISet<string> _fieldnames_Service = new HashSet<string>();
		static Service()
		{
		}
		protected override ISet<string> getFieldNames()
		{
			return _fieldnames_Service;
		}
		public static Service getInstance() {
			return getInstance(Endpoint.getDefaultEndpointManager());
		}
		public static Service getInstance(EndpointManager manager) {
			return getInstance(manager, __pvid__);
		}
		public static Service getInstance(EndpointManager manager, int pvid) {
			ViewContext vc = manager.getViewContext(pvid, ViewContextKind.Static);
			return vc == null ? null : (Service)vc.getSessionOrGlobalView((short)0);
		}
		private sealed class __Pay : View.Control
		{
			public int sn;
			public int gateway;
			public int payid;
			public int product;
			public int price;
			public int quantity;
			public string receipt;
			public __Pay(View _view_, int _sn_, int _gateway_, int _payid_, int _product_, int _price_, int _quantity_, string _receipt_) : base(_view_)
			{
				this.sn = _sn_;
				this.gateway = _gateway_;
				this.payid = _payid_;
				this.product = _product_;
				this.price = _price_;
				this.quantity = _quantity_;
				this.receipt = _receipt_;
			}
			public override OctetsStream marshal(OctetsStream _os_)
			{
				_os_.marshal(this.sn);
				_os_.marshal(this.gateway);
				_os_.marshal(this.payid);
				_os_.marshal(this.product);
				_os_.marshal(this.price);
				_os_.marshal(this.quantity);
				_os_.marshal(this.receipt);
				return _os_;
			}
			public override OctetsStream unmarshal(OctetsStream _os_)
			{
				this.sn = _os_.unmarshal_int();
				this.gateway = _os_.unmarshal_int();
				this.payid = _os_.unmarshal_int();
				this.product = _os_.unmarshal_int();
				this.price = _os_.unmarshal_int();
				this.quantity = _os_.unmarshal_int();
				this.receipt = _os_.unmarshal_string();
				return _os_;
			}
			public override short getViewClassIndex()
			{
				return 0;
			}
			public override byte getControlIndex()
			{
				return 0;
			}
		};
		public void Pay(int _sn_, int _gateway_, int _payid_, int _product_, int _price_, int _quantity_, string _receipt_)
		{
			new __Pay(this,  _sn_,  _gateway_,  _payid_,  _product_,  _price_,  _quantity_,  _receipt_).send();
		}
		private sealed class __Derive : View.Control
		{
			public int sn;
			public string credential;
			public string authcode;
			public __Derive(View _view_, int _sn_, string _credential_, string _authcode_) : base(_view_)
			{
				this.sn = _sn_;
				this.credential = _credential_;
				this.authcode = _authcode_;
			}
			public override OctetsStream marshal(OctetsStream _os_)
			{
				_os_.marshal(this.sn);
				_os_.marshal(this.credential);
				_os_.marshal(this.authcode);
				return _os_;
			}
			public override OctetsStream unmarshal(OctetsStream _os_)
			{
				this.sn = _os_.unmarshal_int();
				this.credential = _os_.unmarshal_string();
				this.authcode = _os_.unmarshal_string();
				return _os_;
			}
			public override short getViewClassIndex()
			{
				return 0;
			}
			public override byte getControlIndex()
			{
				return 1;
			}
		};
		public void Derive(int _sn_, string _credential_, string _authcode_)
		{
			new __Derive(this,  _sn_,  _credential_,  _authcode_).send();
		}
		private sealed class __Bind : View.Control
		{
			public int sn;
			public string credential;
			public string authcode;
			public string username;
			public string token;
			public string platflag;
			public __Bind(View _view_, int _sn_, string _credential_, string _authcode_, string _username_, string _token_, string _platflag_) : base(_view_)
			{
				this.sn = _sn_;
				this.credential = _credential_;
				this.authcode = _authcode_;
				this.username = _username_;
				this.token = _token_;
				this.platflag = _platflag_;
			}
			public override OctetsStream marshal(OctetsStream _os_)
			{
				_os_.marshal(this.sn);
				_os_.marshal(this.credential);
				_os_.marshal(this.authcode);
				_os_.marshal(this.username);
				_os_.marshal(this.token);
				_os_.marshal(this.platflag);
				return _os_;
			}
			public override OctetsStream unmarshal(OctetsStream _os_)
			{
				this.sn = _os_.unmarshal_int();
				this.credential = _os_.unmarshal_string();
				this.authcode = _os_.unmarshal_string();
				this.username = _os_.unmarshal_string();
				this.token = _os_.unmarshal_string();
				this.platflag = _os_.unmarshal_string();
				return _os_;
			}
			public override short getViewClassIndex()
			{
				return 0;
			}
			public override byte getControlIndex()
			{
				return 2;
			}
		};
		public void Bind(int _sn_, string _credential_, string _authcode_, string _username_, string _token_, string _platflag_)
		{
			new __Bind(this,  _sn_,  _credential_,  _authcode_,  _username_,  _token_,  _platflag_).send();
		}
		private sealed class __TemporaryFromCredential : View.Control
		{
			public int sn;
			public string credential;
			public string authcode;
			public string authcode2;
			public long milliseconds;
			public byte usage;
			public string subid;
			public __TemporaryFromCredential(View _view_, int _sn_, string _credential_, string _authcode_, string _authcode2_, long _milliseconds_, byte _usage_, string _subid_) : base(_view_)
			{
				this.sn = _sn_;
				this.credential = _credential_;
				this.authcode = _authcode_;
				this.authcode2 = _authcode2_;
				this.milliseconds = _milliseconds_;
				this.usage = _usage_;
				this.subid = _subid_;
			}
			public override OctetsStream marshal(OctetsStream _os_)
			{
				_os_.marshal(this.sn);
				_os_.marshal(this.credential);
				_os_.marshal(this.authcode);
				_os_.marshal(this.authcode2);
				_os_.marshal(this.milliseconds);
				_os_.marshal(this.usage);
				_os_.marshal(this.subid);
				return _os_;
			}
			public override OctetsStream unmarshal(OctetsStream _os_)
			{
				this.sn = _os_.unmarshal_int();
				this.credential = _os_.unmarshal_string();
				this.authcode = _os_.unmarshal_string();
				this.authcode2 = _os_.unmarshal_string();
				this.milliseconds = _os_.unmarshal_long();
				this.usage = _os_.unmarshal_byte();
				this.subid = _os_.unmarshal_string();
				return _os_;
			}
			public override short getViewClassIndex()
			{
				return 0;
			}
			public override byte getControlIndex()
			{
				return 3;
			}
		};
		public void TemporaryFromCredential(int _sn_, string _credential_, string _authcode_, string _authcode2_, long _milliseconds_, byte _usage_, string _subid_)
		{
			new __TemporaryFromCredential(this,  _sn_,  _credential_,  _authcode_,  _authcode2_,  _milliseconds_,  _usage_,  _subid_).send();
		}
		private sealed class __TemporaryFromLogin : View.Control
		{
			public int sn;
			public string username;
			public string token;
			public string platflag;
			public int appid;
			public string authcode;
			public long milliseconds;
			public byte usage;
			public string subid;
			public __TemporaryFromLogin(View _view_, int _sn_, string _username_, string _token_, string _platflag_, int _appid_, string _authcode_, long _milliseconds_, byte _usage_, string _subid_) : base(_view_)
			{
				this.sn = _sn_;
				this.username = _username_;
				this.token = _token_;
				this.platflag = _platflag_;
				this.appid = _appid_;
				this.authcode = _authcode_;
				this.milliseconds = _milliseconds_;
				this.usage = _usage_;
				this.subid = _subid_;
			}
			public override OctetsStream marshal(OctetsStream _os_)
			{
				_os_.marshal(this.sn);
				_os_.marshal(this.username);
				_os_.marshal(this.token);
				_os_.marshal(this.platflag);
				_os_.marshal(this.appid);
				_os_.marshal(this.authcode);
				_os_.marshal(this.milliseconds);
				_os_.marshal(this.usage);
				_os_.marshal(this.subid);
				return _os_;
			}
			public override OctetsStream unmarshal(OctetsStream _os_)
			{
				this.sn = _os_.unmarshal_int();
				this.username = _os_.unmarshal_string();
				this.token = _os_.unmarshal_string();
				this.platflag = _os_.unmarshal_string();
				this.appid = _os_.unmarshal_int();
				this.authcode = _os_.unmarshal_string();
				this.milliseconds = _os_.unmarshal_long();
				this.usage = _os_.unmarshal_byte();
				this.subid = _os_.unmarshal_string();
				return _os_;
			}
			public override short getViewClassIndex()
			{
				return 0;
			}
			public override byte getControlIndex()
			{
				return 4;
			}
		};
		public void TemporaryFromLogin(int _sn_, string _username_, string _token_, string _platflag_, int _appid_, string _authcode_, long _milliseconds_, byte _usage_, string _subid_)
		{
			new __TemporaryFromLogin(this,  _sn_,  _username_,  _token_,  _platflag_,  _appid_,  _authcode_,  _milliseconds_,  _usage_,  _subid_).send();
		}
		private sealed class __Transfer : View.Control
		{
			public int sn;
			public string username;
			public string token;
			public string platflag;
			public string authcode;
			public string temp;
			public string authtemp;
			public __Transfer(View _view_, int _sn_, string _username_, string _token_, string _platflag_, string _authcode_, string _temp_, string _authtemp_) : base(_view_)
			{
				this.sn = _sn_;
				this.username = _username_;
				this.token = _token_;
				this.platflag = _platflag_;
				this.authcode = _authcode_;
				this.temp = _temp_;
				this.authtemp = _authtemp_;
			}
			public override OctetsStream marshal(OctetsStream _os_)
			{
				_os_.marshal(this.sn);
				_os_.marshal(this.username);
				_os_.marshal(this.token);
				_os_.marshal(this.platflag);
				_os_.marshal(this.authcode);
				_os_.marshal(this.temp);
				_os_.marshal(this.authtemp);
				return _os_;
			}
			public override OctetsStream unmarshal(OctetsStream _os_)
			{
				this.sn = _os_.unmarshal_int();
				this.username = _os_.unmarshal_string();
				this.token = _os_.unmarshal_string();
				this.platflag = _os_.unmarshal_string();
				this.authcode = _os_.unmarshal_string();
				this.temp = _os_.unmarshal_string();
				this.authtemp = _os_.unmarshal_string();
				return _os_;
			}
			public override short getViewClassIndex()
			{
				return 0;
			}
			public override byte getControlIndex()
			{
				return 5;
			}
		};
		public void Transfer(int _sn_, string _username_, string _token_, string _platflag_, string _authcode_, string _temp_, string _authtemp_)
		{
			new __Transfer(this,  _sn_,  _username_,  _token_,  _platflag_,  _authcode_,  _temp_,  _authtemp_).send();
		}
	}
}
