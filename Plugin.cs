using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hud
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin plugin;
        public EventHandlers eventHandlers;
        public override string Author => "Zolics";
        public override string Prefix => "hud";
        public override string Name => "Hud";
        public override void OnEnabled()
        {
            
            eventHandlers = new EventHandlers();
            Exiled.Events.Handlers.Server.RoundStarted += eventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Server.WaitingForPlayers += eventHandlers.WaitingForPlayers;
            plugin = this;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            eventHandlers = null;
            plugin = null;
            Exiled.Events.Handlers.Server.RoundStarted -= eventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= eventHandlers.WaitingForPlayers;
            
            base.OnDisabled();
        }
        
    }
}
