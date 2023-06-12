using PetGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetGame
{
    public class TortoiseStateManager : MonoBehaviour
    {
        TortoiseBaseState currentState;
        TortoiseStateFactory states;
        /*public TortoiseWanderState WanderState = new TortoiseWanderState();
        public TortoiseHappyState HappyState = new TortoiseHappyState();
        public TortoiseEatingState EatingState = new TortoiseEatingState();
        public TortoisePlayingState PlayingState = new TortoisePlayingState();*/

        public TortoiseBaseState CurrentState { get { return currentState; } set { currentState = value; } }
        public float speed;
        public Animator animator;
        public Rigidbody2D rigidBody2D;
        public SpriteRenderer spriteRenderer;

        public float movementTimer;
        public float movementDuration = 1f;
        public bool isMoving = false;

        private void Awake()
        {
            states = new TortoiseStateFactory(this);
        }

        private void Start()
        {
            currentState = states.Wander();
            
            currentState.EnterState();
            Debug.Log(currentState);
        }

        private void Update()
        {
            currentState.UpdateState();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            currentState.OnCollisionEnter();
        }

        /*public void SwitchState(TortoiseBaseState state)
        {
            currentState = state;
            state.EnterState(this);
            Debug.Log(currentState);
        }*/
    }
}