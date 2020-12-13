using System;
using System.Collections.Generic;
using limax.codec;
using limax.util;
namespace FFSimulator.client.states
{
	static public class ClientM
	{
		static public limax.net.State createClientState(int pvid) {
			limax.net.State state = new limax.net.State();
			return state;
		}
		static public limax.net.State getDefaultState(int pvid) {
			return createClientState(pvid);;
		}
	}
}
