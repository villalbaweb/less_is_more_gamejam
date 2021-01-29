using UnityEngine;
using LessIsMore.Core;
using System.Collections;

namespace LessIsMore.Player
{
    public class PlayerDieHandler : MonoBehaviour
    {
        // config
        [SerializeField] SceneLoader sceneLoader = null;
        [SerializeField] float loadStartScreenTime = 2f;

        public void OnPlayerDead()
        {
            StartCoroutine(DeadCoroutine());
        }

        IEnumerator DeadCoroutine()
        {
            transform.Find("Body").gameObject.SetActive(false);
            transform.Find("Aim").gameObject.SetActive(false);


            yield return new WaitForSeconds(loadStartScreenTime);
            
            sceneLoader.LoadMainMenu();
        }
    }
}
