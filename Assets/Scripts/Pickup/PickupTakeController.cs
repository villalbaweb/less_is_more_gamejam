using LessIsMore.Player;
using UnityEngine;
using UnityEngine.Events;

namespace LessIsMore.Pickup
{
    public class PickupTakeController : MonoBehaviour
    {
        // config
        [SerializeField] int healthPointsToIncrease = 5;
        [SerializeField] UnityEvent onPickup = null;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            other.gameObject.GetComponent<PlayerHealthController>().IncreaseHealth(healthPointsToIncrease);
            onPickup.Invoke();            
        }
    }
}
