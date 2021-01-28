using UnityEngine;

namespace LessIsMore.Player
{
    public class PlayerAnimatorControllerHandler : MonoBehaviour
    {
        // cache
        Animator _animator;

        private void Awake() 
        {
            _animator = GetComponent<Animator>();    
        }

        public void OnHurtTrigger()
        {
            _animator.SetTrigger("IsHurt");
        }

        public void OnJumpTrigger()
        {
            _animator.SetBool("IsJumping", true);
        }
    }
}
