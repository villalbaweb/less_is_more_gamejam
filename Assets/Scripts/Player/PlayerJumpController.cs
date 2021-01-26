using UnityEngine;
using LessIsMore.Core;

namespace LessIsMore.Player
{
    public class PlayerJumpController : MonoBehaviour
    {
        // config
        [SerializeField] float maxStamina = 14f;

        // cache
        Rigidbody2D _rigidbody2D;
        PlayerJumpAimController _playerJumpAimController;
        PlayerGroundedRaycastDetector _playerGroundedRaycastDetector;
        Timer _timer;

        // state
        MouseButtonState _mouseState;
        float _jumpStamina;

        private void Awake() 
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerJumpAimController = GetComponent<PlayerJumpAimController>();
            _playerGroundedRaycastDetector = GetComponent<PlayerGroundedRaycastDetector>();
            _timer = GetComponent<Timer>();
            
            _mouseState = MouseButtonState.Release;
            _jumpStamina = maxStamina;

            _timer.StopTimer();
        }

        private void OnEnable() 
        {
            _timer.OnTick += TimerOnTick;
            _timer.OnFinished += TimerOnFinish; 
        }

        private void OnDisable() 
        {
            _timer.OnTick -= TimerOnTick;
            _timer.OnFinished -= TimerOnFinish;
        }

        // Update is called once per frame
        void Update()
        {
            JumpControl();
        }

        private void JumpControl()
        {
            bool canJump = _playerGroundedRaycastDetector.IsGroundedOnLayers() 
                && _mouseState == MouseButtonState.Release 
                && Input.GetMouseButton(0);

            if (canJump)
            {
                _playerJumpAimController.SetAimVisibility(true);
                _mouseState = MouseButtonState.Hold;
                _timer.StartTimer();
                _jumpStamina = maxStamina;
            }

            if (_mouseState == MouseButtonState.Hold && !Input.GetMouseButton(0))
            {
                _mouseState = MouseButtonState.Release;
                _timer.StopTimer();
                Jump();
            }
        }

        private void Jump()
        {
            if(!_rigidbody2D) return;

            _playerJumpAimController.SetAimVisibility(false);
            _playerJumpAimController.ResetLoadIndicator();

            Vector2 jumpVector = new Vector2(_playerJumpAimController.AimDirection.x * _jumpStamina, _playerJumpAimController.AimDirection.y * _jumpStamina);
            _rigidbody2D.AddForce(jumpVector, ForceMode2D.Impulse);
        }

        private void TimerOnTick()
        {
            _jumpStamina--;
            _playerJumpAimController.IncreaseLoadIndicator(0.1f);
        }

        private void TimerOnFinish()
        {
            _jumpStamina = 0;
        }
    }
}
