using UnityEngine;

namespace LessIsMore.Player
{
    // config

    public class PlayerCollisionHandler : MonoBehaviour
    {
        // config
        [SerializeField] LayerMask damageLayersMask = new LayerMask();

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if(IsDamageLayer(other.gameObject.layer))
            {
                Destroy(gameObject);
            }    
        }

        private bool IsDamageLayer(int layer)
        {
            return damageLayersMask == (damageLayersMask | (1 << layer));
        }
    }
}