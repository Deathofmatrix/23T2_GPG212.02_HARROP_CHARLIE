using EasyAudioSystem;
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
        public SpriteRenderer heartSprite;
        public GameObject ball;
        public GameObject food;
        public Camera mainCamera;
        public AudioManager audioManger;
        public GameObject timer;
        public GameObject particles;

        public float movementTimer;
        public float movementDuration = 1f;
        public bool isMoving = false;
        public bool isGrounded = true;
        public bool isUpright = true;
        public bool moveRight;
        public float uprightThreshold = 0.6f;
        public float rotationSpeed;
        public bool hasEaten;
        public bool isAirborn;
        public float timerTime;

        private void Awake()
        {
            states = new TortoiseStateFactory(this);
            Camera mainCamera = Camera.main;
            audioManger = FindObjectOfType<AudioManager>();
            ball = GameObject.Find("Ball");
        }

        private void Start()
        { 
            currentState = states.Wander();
            
            currentState.EnterState();
            Debug.Log(currentState);
        }

        private void Update()
        {
            IsUpright();

            if (!isGrounded && !isAirborn)
            {
                SwitchToAirborn();
            }


            currentState.UpdateState();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                isGrounded = true;
            }

            currentState.OnCollisionEnter(collision);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                isGrounded = false;
            }
        }

        /*public void SwitchToPlaying()
        {
            CurrentState.SwitchStatePublic(states.Playing());
        }*/

        public void SwitchToEating()
        {
            CurrentState.SwitchStatePublic(states.Eating());
        }
        public void SwitchToAirborn()
        {
            CurrentState.SwitchStatePublic(states.Airborn());
        }
        public void SwitchToRighting()
        {
            CurrentState.SwitchStatePublic(states.Righting());
        }

        private void IsUpright()
        {
            //Debug.Log(transform.up.y);
            if (transform.up.y > uprightThreshold)
            {
                isUpright = true;
            }
            else
            {
                isUpright = false;
            }
        }
    }
}