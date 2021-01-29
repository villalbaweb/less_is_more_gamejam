using UnityEngine;

namespace LessIsMore.Portal
{
    public class PortalTeletransporter : MonoBehaviour
    {
        // config
        [SerializeField] Transform spawnPos = null;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            other.gameObject.transform.position = spawnPos.position;
        }
    }
}
