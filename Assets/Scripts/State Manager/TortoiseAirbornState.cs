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
        }

        public override void UpdateState()
        {
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
        }

        public override void OnCollisionEnter(Collision2D collision)
        {

        }

    }
}