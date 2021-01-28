using System.Collections;
using UnityEngine;

namespace LessIsMore.Pickup
{
    public class PickupDisableController : MonoBehaviour
    {
        // config
        [SerializeField] float dissapearTime = 10f;

        // cache
        SpriteRenderer _spriteRenderer;
        CircleCollider2D _circleCollider2d;

        private void Awake() 
        {
            _spriteRenderer = transform.Find("Body").GetComponent<SpriteRenderer>();    
            _circleCollider2d = GetComponent<CircleCollider2D>();
        }

        public void PickupDissapear()
        {
            StartCoroutine(DissapearCoroutine());
        }

        IEnumerator DissapearCoroutine()
        {
            _spriteRenderer.enabled = false;
            _circleCollider2d.enabled = false;
            yield return new WaitForSeconds(dissapearTime);
            _spriteRenderer.enabled = true;
            _circleCollider2d.enabled = true;
        }
    }
}
