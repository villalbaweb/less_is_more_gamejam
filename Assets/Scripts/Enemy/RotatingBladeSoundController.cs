using LessIsMore.Core;
using UnityEngine;

namespace LessIsMore.Enemy
{
    public class RotatingBladeSoundController : MonoBehaviour
    {
        // config
        [SerializeField] AudioClip sawingSound = null;

        [Range(0, 1)]
        [SerializeField] float sawingSoundVolume = 0.75f;

        // cache
        GameSoundController _gameSoundController;

        private void Awake()
        {
            _gameSoundController = FindObjectOfType<GameSoundController>();
        }
        
        private void OnCollisionEnter2D(Collision2D other) 
        {
            _gameSoundController.PlayClipAtCamera(sawingSound, sawingSoundVolume);
        }
    }
}
