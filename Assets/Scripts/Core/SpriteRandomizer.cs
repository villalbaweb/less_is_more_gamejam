using UnityEngine;

namespace LessIsMore.Core
{
    public class SpriteRandomizer : MonoBehaviour
    {
        //config
        [SerializeField] Sprite[] bloodSprites = null;

        // state
        private SpriteRenderer _spriteRenderer;

        private void Awake() 
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            int randomSpritePos =  Random.Range(0, bloodSprites.Length);

            _spriteRenderer.sprite = bloodSprites[randomSpritePos];    
        }
    }
}
