using UnityEngine;

namespace PetGame
{
    public class TortoiseEatingState : TortoiseBaseState
    {
        public TortoiseEatingState(TortoiseStateManager currentContext, TortoiseStateFactory tortoiseStateFactory) : base(currentContext, tortoiseStateFactory) { }
        public override void EnterState()
        {
            Debug.Log("Eating rn");
            _ctx.food.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            _ctx.food.transform.position = new Vector2(_ctx.food.transform.position.x, 3);
            _ctx.food.SetActive(true);
            _ctx.speed = 3;
        }

        public override void UpdateState()
        {
            Vector2 direction = _ctx.food.transform.position - _ctx.transform.position;
            direction.Normalize();
            direction.y = 0;

            direction.x = Mathf.Clamp(direction.x, -1, 1);

            Debug.Log(direction);
            _ctx.rigidBody2D.MovePosition(_ctx.rigidBody2D.position + direction * _ctx.speed * Time.deltaTime);
        }

        public override void ExitState()
        {
            _ctx.ball.SetActive(false);
        }

        public override void OnCollisionEnter(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Food"))
            {
                SwitchState(_factory.Happy());
            }
        }

    }
}