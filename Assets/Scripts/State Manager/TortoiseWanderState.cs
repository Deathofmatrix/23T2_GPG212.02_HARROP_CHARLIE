using System.Collections;
//using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
//using static UnityEngine.Rendering.DebugUI;
using UnityEngine.Rendering;
//using static UnityEngine.RuleTile.TilingRuleOutput;

namespace PetGame
{
    public class TortoiseWanderState : TortoiseBaseState
    {
        public TortoiseWanderState(TortoiseStateManager currentContext, TortoiseStateFactory tortoiseStateFactory) : base(currentContext, tortoiseStateFactory) { }

        public override void EnterState()
        {
            Debug.Log("Wander RN rn");
        }

        public override void UpdateState()
        {
            _ctx.movementTimer += Time.deltaTime;
            if (_ctx.movementTimer >= _ctx.movementDuration)
            {
                PickNextAction();
                _ctx.movementTimer = 0;
            }

            if (_ctx.isMoving)
            {
                _ctx.rigidBody2D.MovePosition(_ctx.rigidBody2D.position + Vector2.right * _ctx.speed * Time.deltaTime);
            }

            if ( _ctx.food.activeInHierarchy )
            {
                SwitchState(_factory.Eating());
            }
        }

        public override void ExitState()
        {
            _ctx.speed = 0;
            _ctx.animator.SetBool("isMoving", false);
        } 

        public override void OnCollisionEnter(Collision2D collision)
        {
        }

        private void PickNextAction()
        {
            int pick = Random.Range(0, 3);

            if (pick == 0)
            {
                _ctx.moveRight = true;
                Move();
            }
            else if (pick == 1)
            {
                _ctx.moveRight = false;
                Move();
            }
            else if (pick == 2)
            {
                Idle();
            }

            Debug.Log(pick);
        }

        private void Move()
        {
            _ctx.speed = _ctx.moveRight ? 1 : -1;
            _ctx.isMoving = true;
            _ctx.animator.SetBool("isMoving", true);
            _ctx.spriteRenderer.flipX = !_ctx.moveRight;
        }

        private void Idle()
        {
            _ctx.isMoving = false;
            _ctx.animator.SetBool("isMoving", false);
        }
    }
}

