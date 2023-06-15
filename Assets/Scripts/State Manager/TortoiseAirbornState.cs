using System.Threading;
using TMPro;
using UnityEngine;

namespace PetGame
{
    public class TortoiseAirbornState : TortoiseBaseState
    {
        public TortoiseAirbornState(TortoiseStateManager currentContext, TortoiseStateFactory tortoiseStateFactory) : base(currentContext, tortoiseStateFactory) { }
        public override void EnterState()
        {
            Debug.Log("Airborn rn");
            _ctx.animator.SetBool("isAirborn", true);
            _ctx.timerTime = 0;
            _ctx.timer.SetActive(true);
            _ctx.isAirborn = true;
        }

        public override void UpdateState()
        {
            UpdateTimer();

            if (_ctx.isGrounded == true && _ctx.isUpright == false)
            {
                SwitchState(_factory.Righting());
            }
            else if (_ctx.isGrounded == true && _ctx.isUpright == true)
            {
                SwitchState(_factory.Wander());
            }

        }

        public override void ExitState()
        {
            _ctx.animator.SetBool("isAirborn", false);
            _ctx.timer.SetActive(false);
            _ctx.isAirborn = false;
        }

        public override void OnCollisionEnter(Collision2D collision)
        {
            _ctx.audioManger.Play("TortoiseBounce");
        }

        private void UpdateTimer()
        {
            _ctx.timerTime += Time.deltaTime;


            float seconds = Mathf.FloorToInt(_ctx.timerTime % 60);
            float milliseconds = Mathf.FloorToInt((_ctx.timerTime % 1) * 1000);
            milliseconds = Mathf.FloorToInt(milliseconds / 10);

            _ctx.timer.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", seconds, milliseconds);
        }

    }
}