using UnityEngine;

namespace LessIsMore.Player
{
    public class PlayerHealthController : MonoBehaviour
    {
        // config
        [SerializeField] int maxHealthPoints = 20;
        [SerializeField] int healthPoints = 20;

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
        }
    }
}
