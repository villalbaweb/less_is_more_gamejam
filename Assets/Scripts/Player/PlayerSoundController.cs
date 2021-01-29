using UnityEngine;
using LessIsMore.Core;

namespace LessIsMore.Player
{
    public class PlayerSoundController : MonoBehaviour
    {
        // config
        [SerializeField] AudioClip hitSound = null;
        [SerializeField] AudioClip jumpSound = null;
        [SerializeField] AudioClip dieSound = null;
        
        [Range(0, 1)]
        [SerializeField] float hitSoundVolume = 0.75f;
        [Range(0, 1)]
        [SerializeField] float jumpSoundVolume = 0.75f;
        [Range(0, 1)]
        [SerializeField] float dieSoundVolume = 0.75f;


        // cache
        GameSoundController _gameSoundController;

        private void Awake() 
        {
            _gameSoundController = FindObjectOfType<GameSoundController>();    
        }

        public void HurtSoundPlay()
        {
            _gameSoundController.PlayClipAtCamera(hitSound, hitSoundVolume);
        }

        public void JumpSoundPlay()
        {
            _gameSoundController.PlayClipAtCamera(jumpSound, jumpSoundVolume);
        }

        public void DieSoundPlay()
        {
            _gameSoundController.PlayClipAtCamera(dieSound, dieSoundVolume);
        }
    }
}