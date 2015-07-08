using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using Rage.Native;

namespace ParticleLibrary
{
    public class Particle
    {
        public Particle()
        {
            string hello = "g";

        }

        private void PreparePTFXAsset(string ptfxName)
        {
            ulong hash = 0xB80D8756B4668AB6;
            NativeFunction.CallByHash(hash, null, "");

        }
    }
}
