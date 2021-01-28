using UnityEngine;
using UnityEngine.Events;

namespace LessIsMore.Pickup
{
    public class PickupTakeController : MonoBehaviour
    {
        // config
        [SerializeField] UnityEvent onPickup = null;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            onPickup.Invoke();            
        }
    }
}
