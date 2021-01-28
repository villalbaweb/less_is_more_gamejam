using UnityEngine;
using UnityEngine.Events;

namespace LessIsMore.Player
{
    public class PlayerHealthController : MonoBehaviour
    {
        // config
        [SerializeField] int maxHealthPoints = 20;
        [SerializeField] int healthPoints = 20;
        [SerializeField] UnityEvent onDie = null;

        // properties
        public int MaxHealthPoints => maxHealthPoints;
        public int HealthPoints => healthPoints;

        public void IncreaseHealth(int increaseHealthPoints)
        {
            healthPoints += increaseHealthPoints;

            healthPoints = Mathf.Clamp(healthPoints, 0, maxHealthPoints);
        }

        public void DecreaseHealthPoint()
        {
            healthPoints --;

            healthPoints = Mathf.Clamp(healthPoints, 0, maxHealthPoints);

            if(healthPoints <= 0)
            {
                onDie.Invoke();
            }
        }
    }
}
