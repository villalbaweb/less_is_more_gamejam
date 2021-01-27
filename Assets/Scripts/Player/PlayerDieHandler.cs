using UnityEngine;
using UnityEngine.Events;

namespace LessIsMore.Player
{
    public class PlayerDieHandler : MonoBehaviour
    {
        // config
        [SerializeField] UnityEvent onDieEvent = null;

        public void OnPlayerCollision()
        {
            onDieEvent.Invoke();
        }
    }
}
