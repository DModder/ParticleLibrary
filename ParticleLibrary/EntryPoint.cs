[assembly: Rage.Attributes.Plugin("Particle Library", Description = "Used for spawning particles with RAGE Plugin Hook", Author = "DModder")]

namespace ParticleLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Rage;

    public class EntryPoint
    {

        public static void Main()
        {
            Particle particle = new Particle(PTFXParticleNonLooped.Smoke1, Game.LocalPlayer.Character, 5);
            
            //Keeping the plugin alive and looping
            while (true)
            {
                GameFiber.Yield();   
            }
        }
    }
}
