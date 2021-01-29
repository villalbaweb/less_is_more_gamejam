using UnityEngine;

namespace LessIsMore.Core
{
    public class UIButtonClickSoundController : MonoBehaviour
    {
        // config
        [SerializeField] AudioClip clickSound = null;

        [Range(0, 1)]
        [SerializeField] float clickSoundVolume = 0.75f;

        // cache
        GameSoundController _gameSoundController;

        private void Awake()
        {
            _gameSoundController = FindObjectOfType<GameSoundController>();
        }

        public void ClickSoundPlay()
        {
            _gameSoundController.PlayClipAtCamera(clickSound, clickSoundVolume);
        }
    }
}
