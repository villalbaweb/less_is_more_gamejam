using UnityEngine;

namespace LessIsMore.Player
{
    public class PlayerRotationController : MonoBehaviour
    {
        // cache
        Transform _bodyTransform;
        PlayerJumpAimController _playerJumpAimController;


        void Awake()
        {
            _bodyTransform = transform.Find("Body");
            _playerJumpAimController = GetComponent<PlayerJumpAimController>();
        }

        void Update()
        {
            CalculatePlayerOrientation();
        }

        private void CalculatePlayerOrientation()
        {
            float playerXDirection = _playerJumpAimController.AimDirection.x < 0
                ? -1
                : 1;
            Vector3 playerDirection = new Vector3(playerXDirection, 1, 1);
            _bodyTransform.localScale = playerDirection;

        }
    }
}