using UnityEngine;

namespace LessIsMore.Pickup
{
    public class PickupTakeController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) 
        {
            print("taken...");    
        }
    }
}
