using Exiled.API.Features;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hud
{
    public class EventHandlers
    {
        public CoroutineHandle coroutine = new CoroutineHandle();
        public IEnumerator<float> Handle()
        {
            while(true) 
            {
                foreach(Player pl in Player.List)
                {
                    if(pl.Role.Team != PlayerRoles.Team.Dead && pl.Role.Type != PlayerRoles.RoleTypeId.Filmmaker)
                    {
                        pl.ShowHint($"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<align=\"left\"><color={pl.Role.Color.ToHex()}>ㅤㅤ{pl.DisplayNickname.Replace("*", "")}</color></align>", 1.4f);
                    }
                    
                }
                yield return Timing.WaitForSeconds(1f);
            }
            
        }
        public void WaitingForPlayers()
        {
            Timing.KillCoroutines(coroutine);
        }
        public void OnRoundStarted()
        {
            coroutine = Timing.RunCoroutine(Handle());
        }
    }
}
