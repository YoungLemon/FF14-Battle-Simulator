using FFSimulator.client.views;
using limax.endpoint;
using limax.net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;

namespace FFSimulator_client
{
    class MyListener : EndpointListener
    {
        public MyListener()
        {
        }
        public void onAbort(Transport transport)
        {
            Exception e = transport.getCloseReason();
            Debug.Log("onAbort " + transport + " " + e);
        }
        public void onManagerInitialized(Manager manager, Config config)
        {
            Debug.Log("onManagerInitialized " + config.GetType().Name + " " + manager);
        }
        public void onManagerUninitialized(Manager manager)
        {
            Debug.Log("onManagerUninitialized " + manager);
        }
        public void onTransportAdded(Transport transport)
        {
            Debug.Log("onTransportAdded " + transport);
            ViewS.getInstance().SetNickname(FNet.Instance.nickname);
            ViewS.getInstance().JoinRoom();
            FNet.Instance.connectionState = ConnectionState.MAIN;
        }
        public void onTransportRemoved(Transport transport)
        {
            Exception e = transport.getCloseReason();
            Debug.Log("onTransportRemoved " + transport + " " + e);
        }
        public void onSocketConnected()
        {
            Debug.Log("onSocketConnected");
        }
        public void onKeyExchangeDone()
        {
            Debug.Log("onKeyExchangeDone");
        }
        public void onKeepAlived(int ms)
        {
            Debug.Log("onKeepAlived " + ms);
        }
        public void onErrorOccured(int source, int code, Exception exception)
        {
            Debug.LogError("onErrorOccured " + source + " " + code + " " + exception);
        }
    }
}
