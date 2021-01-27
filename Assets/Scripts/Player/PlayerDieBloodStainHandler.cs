using UnityEngine;

namespace LessIsMore.Player
{
    public class PlayerDieBloodStainHandler : MonoBehaviour
    {
        // config
        [SerializeField] GameObject bloodStain = null;

        public void AddBloddStain(Transform transformToStain)
        {
            GameObject instance = Instantiate(bloodStain, transform.position, Quaternion.identity);
            instance.transform.parent = transformToStain.transform;
        }
    }
}
