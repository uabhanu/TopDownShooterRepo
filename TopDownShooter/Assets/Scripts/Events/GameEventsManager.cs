using System;

namespace Events
{
    public class GameEventsManager
    {
        #region Actions
        protected static event Action PlayerGunReloadingAction;

        #endregion

        #region Functions
		
        public static void SubscribeToEvent(GameEvent gameEvent , Action actionFunction)
        {
            switch(gameEvent)
            {
                case GameEvent.PlayerGunReloading:
                    PlayerGunReloadingAction += actionFunction;
                break;
            }
        }

        public static void UnsubscribeFromEvent(GameEvent gameEvent , Action actionFunction)
        {
            switch(gameEvent)
            {
                case GameEvent.PlayerGunReloading:
                    PlayerGunReloadingAction -= actionFunction;
                break;
            }
        }

        public static void Invoke(GameEvent gameEvent)
        {
            switch(gameEvent)
            {
                case GameEvent.PlayerGunReloading:
                    PlayerGunReloadingAction?.Invoke();
                break;
            }
        }

        #endregion
    }
}
