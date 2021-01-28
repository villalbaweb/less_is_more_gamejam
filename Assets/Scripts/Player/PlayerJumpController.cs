using UnityEngine;
using LessIsMore.Core;
using UnityEngine.Events;

namespace LessIsMore.Player
{
    public class PlayerJumpController : MonoBehaviour
    {
        // config
        [Tooltip("Max jump stamina, this will be reduced based on the Timer's settings.")]
        [SerializeField] float maxStamina = 14f;
        [SerializeField] UnityEvent onJump = null;
        [SerializeField] UnityEvent onLand = null;

        // cache
        Rigidbody2D _rigidbody2D;
        PlayerJumpAimController _playerJumpAimController;
        PlayerGroundedRaycastDetector _playerGroundedRaycastDetector;
        Timer _timer;

        // state
        MouseButtonState _mouseState;
        float _jumpStamina;
        float _reduceStaminePerTick;
        bool _canJump;

        private void Awake() 
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerJumpAimController = GetComponent<PlayerJumpAimController>();
            _playerGroundedRaycastDetector = GetComponent<PlayerGroundedRaycastDetector>();
            _timer = GetComponent<Timer>();
            
            _mouseState = MouseButtonState.Release;
            _jumpStamina = maxStamina;
            _reduceStaminePerTick = (_timer.TickTime / _timer.TotalTime) * maxStamina;

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
            CanJumpCheck();
            JumpControl();
        }

        private void CanJumpCheck()
        {
            _canJump = _playerGroundedRaycastDetector.IsGroundedOnLayers() && _rigidbody2D.velocity.magnitude <= 0.01;
        }

        private void JumpControl()
        {
            if (_canJump)
            {
                onLand.Invoke();

                StartJumpLoading();
            }

            if (_mouseState == MouseButtonState.Hold && !Input.GetMouseButton(0))
            {
                Jump();
            }
        }

        private void StartJumpLoading()
        {
            if(_mouseState == MouseButtonState.Release && Input.GetMouseButton(0))
            {
                _mouseState = MouseButtonState.Hold;
                _timer.StartTimer();
                _jumpStamina = maxStamina;
            }
        }

        private void Jump()
        {
            _mouseState = MouseButtonState.Release;
            _timer.StopTimer();

            if(!_rigidbody2D) return;

            onJump.Invoke();

            Vector2 jumpVector = new Vector2(_playerJumpAimController.AimDirection.x * _jumpStamina, _playerJumpAimController.AimDirection.y * _jumpStamina);
            _rigidbody2D.AddForce(jumpVector, ForceMode2D.Impulse);
        }

        private void TimerOnTick()
        {
            if(Mathf.Approximately(_jumpStamina, 0f)) return;

            _jumpStamina -= _reduceStaminePerTick;
        }

        private void TimerOnFinish()
        {
            _jumpStamina = 0;
        }
    }
}
