using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using Rage.Native;

namespace ParticleLibrary
{
    
    public enum PTFXParticleNonLooped { Smoke1 = 0};
    
    public class Particle
    {
        //Hash codes for various functions
       private enum Hashes : ulong {
            REQUEST_NAMED_PTFX_ASSET = 0xB80D8756B4668AB6,
            HAS_NAMED_PTFX_ASSET_LOADED = 0x8702416E512EC454,
            _SET_PTFX_ASSET_NEXT_CALL = 0x6C38AF3693A69A91,
            START_PARTICLE_FX_NON_LOOPED_AT_COORD = 0x25129531F77B9ED3
        };

        /*
         * Array of dictionaries for holding asset and particle pair. 
         * Use a value from 'PTFXParticleNonLooped', as index for this array, to get the '{ASSET , PARTICLE}' pair.  
         */
        private static Dictionary<string, string>[] PTFXNonLoopedDictionaries = new Dictionary<string, string>[]{
            new Dictionary<string, string>(){{"scr_paletoscore","scr_paleto_doorway_smoke"}} //Smoke1 Dictionary, format: '{ASSET , PARTICLE}'
        };

        /// <summary>Whereever</summary>
        private bool looped; 

        


        /*
         * MARK: - Constructors for a Ped
         */


        /// <summary>Spawn a particle effect with a Ped and the following parameters...</summary>
        /// <param name="ptfxAssetName">For all other assets/effects than the ones included</param>
        /// <param name="ptfxParticleName">For all other assets/effects than the ones included</param>
        /// <param name="character">The Ped you want to spawn the particle effect on</param>
        /// <param name="position">The position you want the particle effect to spawn</param>
        /// <param name="scale">Sets the size of the particle effect</param>
        public Particle(PTFXParticleNonLooped nonLoopedPTFX, Ped character, float scale)
            : this(PTFXNonLoopedDictionaries[(int)nonLoopedPTFX].Keys.ToArray<string>()[0],
                   PTFXNonLoopedDictionaries[(int)nonLoopedPTFX].Values.ToArray<string>()[0],
                   character, Vector3.Zero, Vector3.Zero, scale) { }

        /// <summary>Spawn a particle effect with a Ped and the following parameters...</summary>
        /// <param name="ptfxAssetName">For all other assets/effects than the ones included</param>
        /// <param name="ptfxParticleName">For all other assets/effects than the ones included</param>
        /// <param name="character">The Ped you want to spawn the particle effect on</param>
        /// <param name="position">The position you want the particle effect to spawn</param>
        /// <param name="rotation">The rotating of the particle effect</param>
        /// <param name="scale">Sets the size of the particle effect</param>
       public Particle(PTFXParticleNonLooped nonLoopedPTFX, Ped character, Vector3 rotation, float scale)
            : this(PTFXNonLoopedDictionaries[(int)nonLoopedPTFX].Keys.ToArray<string>()[0],
                   PTFXNonLoopedDictionaries[(int)nonLoopedPTFX].Values.ToArray<string>()[0],
                   character, Vector3.Zero, rotation, scale) { }
        
        /// <summary>Spawn a particle effect with a Ped and the following parameters...</summary>
        /// <param name="ptfxAssetName">For all other assets/effects than the ones included</param>
        /// <param name="ptfxParticleName">For all other assets/effects than the ones included</param>
        /// <param name="character">The Ped you want to spawn the particle effect on</param>
        /// <param name="offset">The offset from the Ped</param>
        /// <param name="rotation">The rotating of the particle effect</param>
        /// <param name="scale">Sets the size of the particle effect</param>
        public Particle(PTFXParticleNonLooped nonLoopedPTFX, Ped character, Vector3 offset, Vector3 rotation, float scale)
            : this(PTFXNonLoopedDictionaries[(int)nonLoopedPTFX].Keys.ToArray<string>()[0],
                   PTFXNonLoopedDictionaries[(int)nonLoopedPTFX].Values.ToArray<string>()[0],
                   character, offset, rotation, scale) { }

        /// <summary>Spawn a particle effect with a Ped and the following parameters...</summary>
        /// <param name="ptfxAssetName">For all other assets/effects than the ones included</param>
        /// <param name="ptfxParticleName">For all other assets/effects than the ones included</param>
        /// <param name="position">The position you want the particle effect to spawn</param>
        /// <param name="rotation">The rotating of the particle effect</param>
        /// <param name="scale">Sets the size of the particle effect</param>
        public Particle(string ptfxAssetName, string ptfxParticleName, Ped character, Vector3 offset, Vector3 rotation, float scale)
        {
            //Setting up properties
            this.looped = false;

            //Preparing the Asset...
            if (!PreparingAsset(ptfxAssetName)) { return; }

            //Everything went OK. Procceding...


        }




        /*
         * MARK: - Constructors for a position
         */


        /// <summary>Spawn a particle effect with a position and the following parameters...</summary>
        /// <param name="nonLoopedPTFX">The type of particle effect you want</param>
        /// <param name="position">The position you want the particle effect to spawn</param>
        /// <param name="scale">Sets the size of the particle effect</param>
        public Particle(PTFXParticleNonLooped nonLoopedPTFX, Vector3 position, float scale)
           : this(PTFXNonLoopedDictionaries[(int)nonLoopedPTFX].Keys.ToArray<string>()[0],
                   PTFXNonLoopedDictionaries[(int)nonLoopedPTFX].Values.ToArray<string>()[0],
                   position, Vector3.Zero, scale) { }

        /// <summary>Spawn a particle effect with a position and the following parameters...</summary>
        /// <param name="nonLoopedPTFX">The type of particle effect you want</param>
        /// <param name="position">The position you want the particle effect to spawn</param>
        /// <param name="rotation">The rotating of the particle effect</param>
        /// <param name="scale">Sets the size of the particle effect</param>
        public Particle(PTFXParticleNonLooped nonLoopedPTFX, Vector3 position, Vector3 rotation, float scale)
           : this(PTFXNonLoopedDictionaries[(int)nonLoopedPTFX].Keys.ToArray<string>()[0],
                  PTFXNonLoopedDictionaries[(int)nonLoopedPTFX].Values.ToArray<string>()[0],
                  position, rotation, scale) { }

        /// <summary>Spawn a particle effect with a position and the following parameters...</summary>
        /// <param name="ptfxAssetName">For all other assets/effects than the ones included</param>
        /// <param name="ptfxParticleName">For all other assets/effects than the ones included</param>
        /// <param name="position">The position you want the particle effect to spawn</param>
        /// <param name="rotation">The rotating of the particle effect</param>
        /// <param name="scale">Sets the size of the particle effect</param>
        public Particle(string ptfxAssetName, string ptfxParticleName, Vector3 position, Vector3 rotation, float scale)
        {
            //Preparing the Asset...
            if (!PreparingAsset(ptfxAssetName)) { return; }

            //Everything went OK. Procceding...
            //Set the PTFX asset to ready, and spawn the particle
            NativeFunction.CallByHash((ulong)Hashes._SET_PTFX_ASSET_NEXT_CALL, null, ptfxAssetName);
            bool success = NativeFunction.CallByHash<bool>((ulong)Hashes.START_PARTICLE_FX_NON_LOOPED_AT_COORD, ptfxParticleName, position.X, position.Y, position.Z, rotation.X, rotation.Y, rotation.Z, scale, 0, 0, 0);
            
            if (success)
            {
                Game.Console.Print("PL: Successfully spawned a particle effect.");
            }
            else
            {
                Game.Console.Print("PL: Something went wrong, particle effect not spawned.");
            }
            
        }




        /*
         * MARK: - Custom functions
         */

        private bool PreparingAsset(string ptfxAssetName)
        {
            //Request PTFX asset
            NativeFunction.CallByHash((ulong)Hashes.REQUEST_NAMED_PTFX_ASSET, null, ptfxAssetName);

            //Checking if PTFX asset is loaded
            if (!IsPTFXAssetLoaded(ptfxAssetName))
            {
                //PTFX is not found so sleep for 25ms, and try again
                GameFiber.Wait(25);

                if (!IsPTFXAssetLoaded(ptfxAssetName))
                {
                    Game.Console.Print("PL: PTFX asset could not be found.");
                    return false;
                }
            }
            Game.Console.Print("PL: PTFX asset found and loaded.");
            return true;
        }

        private bool IsPTFXAssetLoaded(string ptfxAssetName)
        {
            if(NativeFunction.CallByHash<bool>((ulong)Hashes.HAS_NAMED_PTFX_ASSET_LOADED, ptfxAssetName)){
                return true;
            }
            return false;
        }


        public void StopLooping()
        {
            if (looped)
            {

            }
            else
            {
                throw new ParticleNotLoopedException();
            }
        }

       
    }

    // Custom exceptions
    
    public class ParticleNotLoopedException : Exception
    {
        public ParticleNotLoopedException(){}
    }
}
