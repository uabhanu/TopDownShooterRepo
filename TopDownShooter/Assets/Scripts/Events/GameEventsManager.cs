using System;

namespace Events
{
    public class GameEventsManager
    {
        #region Actions
		
        protected static event Action ReloadingAction;

        #endregion

        #region Functions
		
        public static void SubscribeToEvent(GameEvent gameEvent , Action actionFunction)
        {
            switch(gameEvent)
            {
                case GameEvent.Reloading:
                    ReloadingAction += actionFunction;
                break;
            }
        }

        public static void UnsubscribeFromEvent(GameEvent gameEvent , Action actionFunction)
        {
            switch(gameEvent)
            {
                case GameEvent.Reloading:
                    ReloadingAction -= actionFunction;
                break;
            }
        }

        public static void Invoke(GameEvent gameEvent)
        {
            switch(gameEvent)
            {
                case GameEvent.Reloading:
                    ReloadingAction?.Invoke();
                break;
            }
        }

        #endregion
    }
}
