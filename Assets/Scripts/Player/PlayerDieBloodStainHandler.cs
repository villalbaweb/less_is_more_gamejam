using UnityEngine;

namespace LessIsMore.Player
{
    public class PlayerDieBloodStainHandler : MonoBehaviour
    {
        // config
        [SerializeField] GameObject bloodStain = null;

        public void AddBloddStain()
        {
            Instantiate(bloodStain, transform.position, Quaternion.identity);
        }
    }
}
