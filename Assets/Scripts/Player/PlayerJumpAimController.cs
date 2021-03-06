﻿using UnityEngine;
using LessIsMore.Core;

namespace LessIsMore.Player
{
    public class PlayerJumpAimController : MonoBehaviour
    {
        // cache
        private Transform _aimTransform;
        private Transform _aimLoadTransform;
        private GetMouseWorldPosition _getMouseWorldPosition;
        private Timer _timer;

        // properties
        public Vector3 AimDirection => aimDirection;

        // state
        Vector3 aimDirection;
        SpriteRenderer _spriteRenderer;

        private void Awake() 
        {
            _aimTransform = transform.Find("Aim");
            _aimLoadTransform = _aimTransform.Find("Aim Load");
            _spriteRenderer = _aimTransform.GetComponent<SpriteRenderer>();
            _getMouseWorldPosition = GetComponent<GetMouseWorldPosition>();
            _timer = GetComponent<Timer>();

            ResetLoadIndicator();
        }

        private void OnEnable() 
        {
            _timer.OnTick += TimerOnTick;
        }

        private void OnDisable() 
        {
            _timer.OnTick -= TimerOnTick;
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

        public void OnJumpStart()
        {
            SetAimVisibility(false);
            ResetLoadIndicator();
        }

        public void OnJumpLand()
        {
            SetAimVisibility(true);
        }

        private void SetAimVisibility(bool isVisible)
        {
            _spriteRenderer.enabled = isVisible;
        }

        private void ResetLoadIndicator()
        {
            _aimLoadTransform.localPosition = new Vector3(-1f, 0, 0);
        }

        public void IncreaseLoadIndicator(float xFactor)
        {
            _aimLoadTransform.localPosition = new Vector3(_aimLoadTransform.localPosition.x + xFactor, 0, 0);
        }

        private void TimerOnTick()
        {
            float xFactor = (_timer.TickTime / _timer.TotalTime) * 2;

            _aimLoadTransform.localPosition = new Vector3(_aimLoadTransform.localPosition.x + xFactor, 0, 0);
        }
    }
}