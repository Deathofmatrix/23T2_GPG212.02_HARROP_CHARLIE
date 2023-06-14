using TMPro;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace PetGame
{
    public class TortoisePlayingState : TortoiseBaseState
    {
        public TortoisePlayingState(TortoiseStateManager currentContext, TortoiseStateFactory tortoiseStateFactory) : base(currentContext, tortoiseStateFactory) { }
        public override void EnterState()
        {
            Debug.Log("Playing rn");
            if (_ctx.ball.activeInHierarchy == false)
            {
                _ctx.ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                _ctx.ball.transform.position = new Vector2(_ctx.ball.transform.position.x, 3);
                _ctx.ball.SetActive(true);
            }
            else
            {
                _ctx.ball.SetActive(false);
            }
            
            //_ctx.speed = 3;
        }

        public override void UpdateState()
        {
            /*Vector2 direction = _ctx.ball.transform.position - _ctx.transform.position;
            direction.Normalize();
            direction.y = 0;

            direction.x = Mathf.Clamp(direction.x, -1, 1);

            Debug.Log(direction);
            _ctx.rigidBody2D.MovePosition(_ctx.rigidBody2D.position + direction * _ctx.speed * Time.deltaTime);*/

            SwitchState(_factory.Wander());
        }

        public override void ExitState()
        {
            
        }

        public override void OnCollisionEnter(Collision2D collision)
        {
            /*if (collision.gameObject.CompareTag("Ball"))
            {
                SwitchState(_factory.Happy());
            }*/
        }

    }
}