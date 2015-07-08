using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using Rage.Native;

namespace ParticleLibrary
{
    //public enum PTFXAssetNonLooped { Smoke = 0};
    public enum PTFXParticleNonLooped { Smoke1 = 0};
    
    
    public class Particle
    {
        //Hash codes for various functions
       
        private enum Hashes {
            REQUEST_NAMED_PTFX_ASSET = 0xB80D8756B4668AB6,
            START_PARTICLE_FX_NON_LOOPED_AT_COORD = 0x25129531F77B9ED3
        };

        /*
         * Array of dictionaries for holding asset and particle pair. 
         * Use a value from 'PTFXParticleNonLooped', as index for this array, to get the '{ASSET , PARTICLE}' pair.  
         */
        private Dictionary<string, string>[] PTFXNonLoopedDictionaries = new Dictionary<string, string>[]{
            new Dictionary<string, string>(){{"scr_paletoscore","scr_paleto_doorway_smoke"}} //Smoke1 Dictionary, format: '{ASSET , PARTICLE}'
        };

        public Particle(string ptfxAsset)
        {
            //Request ptfx asset
            NativeFunction.CallByHash((ulong)Hashes.REQUEST_NAMED_PTFX_ASSET, null, ptfxAsset);

        }

       
    }
}
