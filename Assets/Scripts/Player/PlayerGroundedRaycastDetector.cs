using UnityEngine;

namespace LessIsMore.Player
{
    public class PlayerGroundedRaycastDetector : MonoBehaviour
    {
        // config params
        [SerializeField] LayerMask jumpLayers = new LayerMask();

        public bool IsGroundedOnLayers()
        {
            RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.down, 1f, jumpLayers);

            return rayHit.collider != null && IsInLayerMask(rayHit.collider.gameObject.layer, jumpLayers);
        }

        private bool IsInLayerMask(int layer, LayerMask layermask)
        {
            return layermask == (layermask | (1 << layer));
        }
    }
}
