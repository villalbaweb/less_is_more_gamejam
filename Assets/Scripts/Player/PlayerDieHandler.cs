using UnityEngine;

namespace LessIsMore.Player
{
    public class PlayerDieHandler : MonoBehaviour
    {
        public void OnPlayerCollision()
        {
            print("die");
        }
    }
}
