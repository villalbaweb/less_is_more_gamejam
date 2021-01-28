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

        public void IncreaseHealth(int increaseHealthPoints)
        {
            healthPoints += increaseHealthPoints;

            if(healthPoints > maxHealthPoints) 
            {
                healthPoints = maxHealthPoints;
            }
        }

        public void DecreaseHealthPoint()
        {
            healthPoints --;

            if(healthPoints <= 0)
            {
                onDie.Invoke();
            }
        }
    }
}
