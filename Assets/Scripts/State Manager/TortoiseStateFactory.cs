namespace PetGame
{
    public class TortoiseStateFactory
    {
        TortoiseStateManager _context;

        public TortoiseStateFactory(TortoiseStateManager currentContext)
        {
            _context = currentContext;
        }

        public TortoiseBaseState Wander()
        {
            return new TortoiseWanderState(_context, this);
        }
        public TortoiseBaseState Happy()
        {
            return new TortoiseHappyState(_context, this);
        }
        public TortoiseBaseState Playing()
        {
            return new TortoisePlayingState(_context, this);
        }
        public TortoiseBaseState Eating()
        {
            return new TortoiseEatingState(_context, this);
        }
        public TortoiseBaseState Airborn()
        {
            return new TortoiseAirbornState(_context, this);
        }
        public TortoiseBaseState Righting()
        {
            return new TortoiseRightingState(_context, this);
        }
    }
}
