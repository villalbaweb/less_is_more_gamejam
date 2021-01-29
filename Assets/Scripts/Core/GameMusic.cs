using UnityEngine;

namespace LessIsMore.Core
{
    public class GameMusic : MonoBehaviour
    {
        // config props
        [SerializeField] AudioClip gameMusic = null;

        // cache
        AudioSource _musicAudioSource;

        // Start is called before the first frame update
        void Awake()
        {
            _musicAudioSource = GetComponent<AudioSource>();

            PlayRegularGameMusic();
        }

        public void PlayRegularGameMusic()
        {
            _musicAudioSource.Stop();
            _musicAudioSource.clip = gameMusic;
            _musicAudioSource.Play();
        }
    }
}
