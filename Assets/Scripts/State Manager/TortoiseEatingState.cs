using EasyAudioSystem;
using UnityEngine;

namespace PetGame
{
    public class TortoiseEatingState : TortoiseBaseState
    {
        public TortoiseEatingState(TortoiseStateManager currentContext, TortoiseStateFactory tortoiseStateFactory) : base(currentContext, tortoiseStateFactory) { }
        public override void EnterState()
        {
            Debug.Log("Eating rn");
            if (_ctx.hasEaten)
            {
                _ctx.food.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                _ctx.food.transform.position = new Vector2(_ctx.food.transform.position.x, 3);
                _ctx.food.SetActive(true);
            }
            
            _ctx.speed = 3;
            _ctx.hasEaten = false;
            _ctx.animator.SetBool("isEating", false);
        }

        public override void UpdateState()
        {
            Vector2 direction = _ctx.food.transform.position - _ctx.transform.position;
            //direction.Normalize();
            direction.y = 0;

            direction.x = Mathf.Clamp(direction.x, -1, 1);

            _ctx.spriteRenderer.flipX = direction.x < 0;
            FlipParticles();
            //Debug.Log(direction);
            _ctx.rigidBody2D.MovePosition(_ctx.rigidBody2D.position + direction * _ctx.speed * Time.deltaTime);

            _ctx.movementTimer += Time.deltaTime;

            if (_ctx.movementTimer >= _ctx.movementDuration && _ctx.hasEaten)
            {
                SwitchState(_factory.Happy());
                _ctx.movementTimer = 0;
            }

        }

        public override void ExitState()
        {
            _ctx.animator.SetBool("isEating", false);
            //_ctx.hasEaten = false;
            _ctx.particles.GetComponent<ParticleSystem>().Stop();
        }

        public override void OnCollisionEnter(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Food"))
            {
                _ctx.particles.GetComponent<ParticleSystem>().Play();
                _ctx.audioManger.Play("Eating");
                _ctx.speed = 0;
                _ctx.food.SetActive(false);
                _ctx.animator.SetBool("isEating", true);

                _ctx.hasEaten = true;

                _ctx.movementTimer = 0;
            }
        }

        private void FlipParticles()
        {
            if (_ctx.spriteRenderer.flipX)
            {
                _ctx.particles.transform.localPosition = new Vector3(-0.56056f, -0.4060201f, 0);
            }
            else if (!_ctx.spriteRenderer.flipX)
            {
                _ctx.particles.transform.localPosition = new Vector3(0.56056f, -0.4060201f, 0);
            }
        }

    }
}