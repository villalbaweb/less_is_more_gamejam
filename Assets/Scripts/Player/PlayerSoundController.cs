using UnityEngine;
using LessIsMore.Core;

namespace LessIsMore.Player
{
    public class PlayerSoundController : MonoBehaviour
    {
        // config
        [SerializeField] AudioClip hitSound = null;

        // cache
        GameSoundController _gameSoundController;

        private void Awake() 
        {
            _gameSoundController = FindObjectOfType<GameSoundController>();    
        }

        public void HurtSoundPlay()
        {
            _gameSoundController.PlayClipAtCamera(hitSound, 0.75f);
        }
    }
}