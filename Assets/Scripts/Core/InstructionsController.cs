using UnityEngine;

namespace LessIsMore.Core
{
    public class InstructionsController : MonoBehaviour
    {
        // state
        SpriteRenderer _spriteRenderer;
        Timer _timer;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _timer = GetComponent<Timer>();
            SubscribeTimerEvents();
        }

        void SubscribeTimerEvents()
        {
            _timer.OnFinished += RemoveTitle;
            _timer.OnTick += TimerTickAction;
        }

        void UnsubscribeTimerEvents()
        {
            _timer.OnFinished -= RemoveTitle;
            _timer.OnTick -= TimerTickAction;
        }

        void RemoveTitle()
        {

            SetAlpha(0);
            UnsubscribeTimerEvents();
        }

        void TimerTickAction()
        {
            SetAlpha(_timer.GetTimeLeft() / _timer.GetTotalTime());
        }

        private void SetAlpha(float value)
        {
            Color tmp = _spriteRenderer.color;
            tmp.a = value;
            _spriteRenderer.color = tmp;
        }
    }
}
