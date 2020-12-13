using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace limax.endpoint.states
{
	static public class Endpoint
	{
		static public limax.net.State createEndpointKeyExchange() {
			limax.net.State state = new limax.net.State();
			state.addStub(typeof(limax.endpoint.switcherendpoint.PingAndKeepAlive), limax.endpoint.switcherendpoint.PingAndKeepAlive.TYPE=4, 8);
			state.addStub(typeof(limax.endpoint.switcherendpoint.SessionKick), limax.endpoint.switcherendpoint.SessionKick.TYPE=5, 32);
			state.addStub(typeof(limax.endpoint.switcherendpoint.CHandShake), limax.endpoint.switcherendpoint.CHandShake.TYPE=0, 1030);
			state.addStub(typeof(limax.endpoint.switcherendpoint.SHandShake), limax.endpoint.switcherendpoint.SHandShake.TYPE=1, 2048);
			state.addStub(typeof(limax.endpoint.switcherendpoint.SessionLoginByToken), limax.endpoint.switcherendpoint.SessionLoginByToken.TYPE=2, 16384);
			return state;
		}
		static public limax.net.State createEndpointClient() {
			limax.net.State state = new limax.net.State();
			state.addStub(typeof(limax.endpoint.switcherendpoint.ProviderLogin), limax.endpoint.switcherendpoint.ProviderLogin.TYPE=7, 0);
			state.addStub(typeof(limax.endpoint.switcherendpoint.OnlineAnnounce), limax.endpoint.switcherendpoint.OnlineAnnounce.TYPE=3, 0);
			state.addStub(typeof(limax.endpoint.switcherendpoint.PingAndKeepAlive), limax.endpoint.switcherendpoint.PingAndKeepAlive.TYPE=4, 8);
			state.addStub(typeof(limax.endpoint.switcherendpoint.SessionKick), limax.endpoint.switcherendpoint.SessionKick.TYPE=5, 32);
			state.addStub(typeof(limax.endpoint.switcherendpoint.PortForward), limax.endpoint.switcherendpoint.PortForward.TYPE=6, 1048576);
			state.addStub(typeof(limax.endpoint.providerendpoint.SendControlToServer), limax.endpoint.providerendpoint.SendControlToServer.TYPE=40, 0);
			state.addStub(typeof(limax.endpoint.providerendpoint.SyncViewToClients), limax.endpoint.providerendpoint.SyncViewToClients.TYPE=41, 0);
			state.addStub(typeof(limax.endpoint.providerendpoint.Tunnel), limax.endpoint.providerendpoint.Tunnel.TYPE=42, 0);
			return state;
		}
		static public limax.net.State createEndpointSessionLogin() {
			limax.net.State state = new limax.net.State();
			state.addStub(typeof(limax.endpoint.switcherendpoint.SessionLoginByToken), limax.endpoint.switcherendpoint.SessionLoginByToken.TYPE=2, 16384);
			state.addStub(typeof(limax.endpoint.switcherendpoint.SessionKick), limax.endpoint.switcherendpoint.SessionKick.TYPE=5, 32);
			state.addStub(typeof(limax.endpoint.switcherendpoint.ProviderLogin), limax.endpoint.switcherendpoint.ProviderLogin.TYPE=7, 0);
			state.addStub(typeof(limax.endpoint.switcherendpoint.OnlineAnnounce), limax.endpoint.switcherendpoint.OnlineAnnounce.TYPE=3, 0);
			return state;
		}
		static public limax.net.State EndpointKeyExchange = createEndpointKeyExchange();
		static public limax.net.State EndpointClient = createEndpointClient();
		static public limax.net.State EndpointSessionLogin = createEndpointSessionLogin();
		static public limax.net.State getDefaultState() {
			return EndpointKeyExchange;
		}
	}
}
