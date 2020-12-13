using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.defines
{
	public sealed class ErrorCodes : limax.codec.Marshal, IComparable<ErrorCodes>
	{
		public const int SUCCEED = 0;
		public const int SWITCHER_AUANY_UNREADY = 11;
		public const int SWITCHER_AUANY_TIMEOUT = 12;
		public const int SWITCHER_SEND_DISPATCH_EXCEPTION = 13;
		public const int SWITCHER_SEND_TO_ENDPOINT_EXCEPTION = 14;
		public const int SWITCHER_DHGROUP_NOTSUPPRTED = 15;
		public const int SWITCHER_LOST_PROVIDER = 16;
		public const int SWITCHER_PROVIDER_UNBIND = 17;
		public const int SWITCHER_WRONG_PROVIDER = 18;
		public const int SWITCHER_MALFORMED_TUNNELDATA = 19;
		public const int AUANY_UNKNOWN_PLAT = 1001;
		public const int AUANY_BAD_TOKEN = 1002;
		public const int AUANY_AUTHENTICATE_TIMEOUT = 1003;
		public const int AUANY_AUTHENTICATE_FAIL = 1004;
		public const int AUANY_CALL_PROCEDURE_FAILED = 1005;
		public const int AUANY_CHECK_LOGIN_IP_FAILED = 1006;
		public const int AUANY_CHECK_PROVIDER_KEY_UNKNOWN_PVID = 1007;
		public const int AUANY_CHECK_PROVIDER_KEY_BAD_KEY = 1008;
		public const int AUANY_SERVICE_BAD_ARGS = 1021;
		public const int AUANY_SERVICE_BIND_HAS_BEEN_BOUND = 1022;
		public const int AUANY_SERVICE_BIND_ACCOUNT_HAS_BEEN_USED = 1023;
		public const int AUANY_SERVICE_PAY_NOT_ENABLED = 1026;
		public const int AUANY_SERVICE_PAY_GATEWAY_NOT_DEFINED = 1027;
		public const int AUANY_SERVICE_PAY_GATEWAY_FAIL = 1028;
		public const int AUANY_SERVICE_INVALID_INVITE = 1030;
		public const int AUANY_SERVICE_INVALID_CREDENTIAL = 1031;
		public const int AUANY_SERVICE_CREDENTIAL_NOT_MATCH = 1032;
		public const int AUANY_SERVICE_ACCOUNT_TOO_MANY_SUBORDINATES = 1033;
		public const int AUANY_SERVICE_TRANSFER_APPID_COLLISION = 1034;
		public const int ENDPOINT_PING_TIMEOUT = 2001;
		public const int ENDPOINT_AUANY_SERVICE_CLIENT_TIMEOUT = 2002;
		public const int ENDPOINT_AUANY_SERVICE_ENGINE_CLOSE = 2003;
		public const int PROVIDER_DUPLICATE_ID = 3002;
		public const int PROVIDER_UNSUPPORTED_VARINAT = 3004;
		public const int PROVIDER_NOT_ALLOW_VARINAT = 3005;
		public const int PROVIDER_UNSUPPORTED_SCRIPT = 3006;
		public const int PROVIDER_NOT_ALLOW_SCRIPT = 3007;
		public const int PROVIDER_KICK_SESSION = 3008;
		public const int PROVIDER_DUPLICATE_SESSION = 3009;
		public const int PROVIDER_SESSION_LOGINED = 3011;
		public const int PROVIDER_ADD_TRANSPORT_EXCEPTION = 3012;
		public const int PROVIDER_TUNNEL_EXCEPTION = 3013;
		public ErrorCodes()
		{
		}
		public OctetsStream marshal(OctetsStream _os_)
		{
			return _os_;
		}
		public OctetsStream unmarshal(OctetsStream _os_)
		{
			return _os_;
		}
		public int CompareTo(ErrorCodes __o__)
		{
			if (__o__ == this)
				 return 0;
			int __c__ = 0;
			return __c__;
		}
		public override bool Equals(object __o1__)
		{
			if(__o1__ == this)
				return true;
			if(__o1__.GetType() != this.GetType())
				return false;
			return true;
		}
		public override int GetHashCode()
		{
			int __h__ = 0;
			return __h__;
		}
	}
}
