using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LessIsMore.Core;

namespace LessIsMore.Player
{
    public class PlayerJumpAimController : MonoBehaviour
    {
        // cache
        private Transform _aimTransform;
        private GetMouseWorldPosition _getMouseWorldPosition;

        // properties
        public Vector3 AimDirection => aimDirection;

        // state
        Vector3 aimDirection;

        private void Awake() 
        {
            _aimTransform = transform.Find("Aim");
            _getMouseWorldPosition = GetComponent<GetMouseWorldPosition>();
        }

        // Update is called once per frame
        void Update()
        {
            AimTorwardsMouse();
        }

        private void AimTorwardsMouse()
        {
            Vector3 mousePosition = _getMouseWorldPosition.GetMouseWorldPos();
            aimDirection = (mousePosition - transform.position).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            _aimTransform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
}