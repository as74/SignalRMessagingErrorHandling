﻿using System.Threading.Tasks;
using Damienbod.SignalR.IHubSync.Client.Dto;
using Damienbod.Slab;
using Damienbod.Slab.Services;
using Microsoft.AspNet.SignalR;

namespace Damienbod.SignalR.Host.Hubs
{
    public class HubSync : Hub
    {
        private readonly IHubLogger _slabLogger;

        public HubSync(IHubLogger slabLogger)
        {
            _slabLogger = slabLogger;
        }

        public void AddMessage(string name, string message)
        {
            _slabLogger.Log(HubType.HubServerVerbose, "HubSync Sending AddMessage " + name + " " + message);
            Clients.All.addMessage(name, message);
        }

        public void Heartbeat()
        {
            _slabLogger.Log(HubType.HubServerVerbose, "HubSync Sending Heartbeat");
            Clients.All.heartbeat();
        }

        public void SendHelloObject(HelloModel hello)
        {
            _slabLogger.Log(HubType.HubServerVerbose, "HubSync Sending SendHelloObject " + hello.Molly + " " + hello.Age);
            Clients.All.sendHelloObject(hello);
        }

        public override Task OnConnected()
        {
            _slabLogger.Log(HubType.HubServerVerbose, "HubSync OnConnected" + Context.ConnectionId);
            return (base.OnConnected());
        }

        public override Task OnDisconnected()
        {
            _slabLogger.Log(HubType.HubServerVerbose, "HubSync OnDisconnected" + Context.ConnectionId);
            return (base.OnDisconnected());
        }

        public override Task OnReconnected()
        {
            _slabLogger.Log(HubType.HubServerVerbose, "HubSync OnReconnected" + Context.ConnectionId);
            return (base.OnReconnected());
        }
    }
}