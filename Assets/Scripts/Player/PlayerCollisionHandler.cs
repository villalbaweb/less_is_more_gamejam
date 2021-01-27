using UnityEngine;
using UnityEngine.Events;

namespace LessIsMore.Player
{
    public class PlayerCollisionHandler : MonoBehaviour
    {
        // config
        [SerializeField] LayerMask damageLayersMask = new LayerMask();
        [SerializeField] UnityEvent onCollisionEvent = null;
        [SerializeField] WeaponPickupEvent onCollisionWithTransformEvent = null;

        [System.Serializable]
        public class WeaponPickupEvent : UnityEvent<Transform> { }

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if(IsDamageLayer(other.gameObject.layer))
            {
                onCollisionEvent.Invoke();
                onCollisionWithTransformEvent.Invoke(other.gameObject.transform);
            }    
        }

        private bool IsDamageLayer(int layer)
        {
            return damageLayersMask == (damageLayersMask | (1 << layer));
        }
    }
}