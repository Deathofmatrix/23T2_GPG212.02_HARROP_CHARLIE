using UnityEngine;

namespace PetGame
{
    public abstract class TortoiseBaseState
    {
        protected TortoiseStateManager _ctx;
        protected TortoiseStateFactory _factory;
        public TortoiseBaseState(TortoiseStateManager currentContext, TortoiseStateFactory tortoiseStateFactory)
        {
            _ctx = currentContext;
            _factory = tortoiseStateFactory;
        }
        public abstract void EnterState();

        public abstract void UpdateState();

        public abstract void ExitState();

        public abstract void OnCollisionEnter(Collision2D collision);

        protected void SwitchState(TortoiseBaseState newState)
        {
            ExitState();

            newState.EnterState();

            _ctx.CurrentState = newState;
        }

        public void SwitchStatePublic(TortoiseBaseState newState)
        {
            SwitchState(newState);
        }
    }
}