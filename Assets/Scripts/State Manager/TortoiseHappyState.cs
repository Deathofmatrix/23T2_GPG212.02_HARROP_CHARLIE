using UnityEngine;

namespace PetGame
{
    public class TortoiseHappyState : TortoiseBaseState
    {
        public TortoiseHappyState(TortoiseStateManager currentContext, TortoiseStateFactory tortoiseStateFactory) : base(currentContext, tortoiseStateFactory) { }
        public override void EnterState()
        {
            Debug.Log("Happyy rn");
            _ctx.heartSprite.enabled = true;
            _ctx.animator.SetBool("isHappy", true);
        }

        public override void UpdateState()
        {
            _ctx.movementTimer += Time.deltaTime;
            if (_ctx.movementTimer >= _ctx.movementDuration)
            {
                SwitchState(_factory.Wander());
                _ctx.movementTimer = 0;
            }
        }

        public override void ExitState()
        {
            _ctx.heartSprite.enabled = false;
            _ctx.animator.SetBool("isHappy", false);
        }

        public override void OnCollisionEnter(Collision2D collision)
        {
            
        }

    }
}