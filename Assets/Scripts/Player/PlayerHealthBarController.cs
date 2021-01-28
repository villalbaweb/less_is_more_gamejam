using UnityEngine;

namespace LessIsMore.Player
{
    public class PlayerHealthBarController : MonoBehaviour
    {
        // config
        [SerializeField] PlayerHealthController playerHealthController = null;

        private void Awake() 
        {
            UpdateHealthBar();
        }

        public void OnHealthDamage()
        {
            UpdateHealthBar();
        }

        private void UpdateHealthBar()
        {
            if (!playerHealthController) return;

            float lifePropertyLeft = (float)playerHealthController.HealthPoints / (float)playerHealthController.MaxHealthPoints;
            print(lifePropertyLeft);

            transform.localScale = new Vector3(lifePropertyLeft, 1, 1);
        }
    }
}
