using UnityEngine;

namespace LessIsMore.Player
{
    public class PlayerDieParticleSystemHandler : MonoBehaviour
    {

        // config
        [SerializeField] ParticleSystem[] dieParticleSystems = null;

        public void PlayDieParticleSystems()
        {
            foreach(var particleSystem in dieParticleSystems)
            {
                ParticleSystem instance = Instantiate(particleSystem, transform.position, Quaternion.identity);
                instance.Play();
            }
        }
    }
}