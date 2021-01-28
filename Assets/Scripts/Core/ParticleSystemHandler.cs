using UnityEngine;

namespace LessIsMore.Core
{
    public class ParticleSystemHandler : MonoBehaviour
    {
        // config
        [SerializeField] ParticleSystem[] particleSystemsToPlay = null;

        public void PlayParticleSystems()
        {
            foreach (var particleSystem in particleSystemsToPlay)
            {
                ParticleSystem instance = Instantiate(particleSystem, transform.position, Quaternion.identity);
                instance.Play();
            }
        }
    }
}