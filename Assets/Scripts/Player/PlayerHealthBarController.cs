using UnityEngine;

namespace LessIsMore.Player
{
    public class PlayerHealthBarController : MonoBehaviour
    {
        // config
        [SerializeField] RectTransform healthBarTransform = null;

        // cache
        PlayerHealthController _playerHealthController;

        private void Awake() 
        {
            _playerHealthController = GetComponent<PlayerHealthController>();
            UpdateHealthBar();
        }

        public void UpdateHealthBar()
        {
            if (!healthBarTransform) return;

            float lifePropertyLeft = (float)_playerHealthController.HealthPoints / (float)_playerHealthController.MaxHealthPoints;

            healthBarTransform.localScale = new Vector3(lifePropertyLeft, 1, 1);
        }
    }
}
