using System;
using System.Collections.Generic;
using limax.codec;
using limax.endpoint;
using limax.util;
using FFSimulator_client;

namespace FFSimulator.client.views
{
    public sealed partial class ViewT
    {
        override protected void onClose()
        {
            FNet.ViewTIndex = -1;
        }
        override protected void onAttach(long sessionid) 
        {
            ViewS.getInstance().JoinRoom();
        }
        override protected void onDetach(long sessionid, byte reason) 
        {
            ViewS.getInstance().LeaveRoom(reason);
        }
        override protected void onOpen(ICollection<long> sessionids)
        {
            FNet.ViewTIndex = getInstanceIndex();
            EndPlaying();
            registerListener("nickname", (e) => FNet.Instance.UpdatePlayers());
            registerListener("isPlaying", (e) => FNet.Instance.UpdateState());
        }
    }
}
