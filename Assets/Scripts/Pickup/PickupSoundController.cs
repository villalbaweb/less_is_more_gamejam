using LessIsMore.Core;
using UnityEngine;

namespace LessIsMore.Pickup
{
    public class PickupSoundController : MonoBehaviour
    {
        // config
        [SerializeField] AudioClip pickupSound = null;

        [Range(0, 1)]
        [SerializeField] float pickupSoundVolume = 0.75f;

        // cache
        GameSoundController _gameSoundController;

        private void Awake()
        {
            _gameSoundController = FindObjectOfType<GameSoundController>();
        }

        public void PickupSoundPlay()
        {
            _gameSoundController.PlayClipAtCamera(pickupSound, pickupSoundVolume);
        }
    }
}
