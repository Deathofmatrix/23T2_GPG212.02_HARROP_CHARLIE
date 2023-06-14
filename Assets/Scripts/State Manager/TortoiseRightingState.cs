using UnityEngine;

namespace PetGame
{
    public class TortoiseRightingState : TortoiseBaseState
    {
        public TortoiseRightingState(TortoiseStateManager currentContext, TortoiseStateFactory tortoiseStateFactory) : base(currentContext, tortoiseStateFactory) { }
        public override void EnterState()
        {
            Debug.Log("Righting rn");
            _ctx.animator.SetBool("isAirborn", true);
            _ctx.movementTimer = 0;
        }

        public override void UpdateState()
        {
            _ctx.movementTimer += Time.deltaTime;
            if (_ctx.movementDuration < _ctx.movementTimer)
            {
                Flip();
            }

            if (_ctx.isUpright)
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

        private void Flip()
        {
            _ctx.rigidBody2D.rotation = 0;
        }

    }
}