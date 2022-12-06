using System;
using UnityEngine;

namespace Events
{
    public class GameEventsManager
    {
        #region Actions
        protected static event Action PlayerGunReloadingAction;
        protected static event Action<AudioClip> BulletExplodedAction;
        protected static event Action HitAction;
        protected static event Action<AudioClip> ShootAction;

        #endregion

        #region Subscribe Functions
		
        public static void SubscribeToEvent(GameEvent gameEvent , Action actionFunction)
        {
            switch(gameEvent)
            {
                case GameEvent.Hit:
                    HitAction += actionFunction;
                break;
                
                case GameEvent.PlayerGunReloading:
                    PlayerGunReloadingAction += actionFunction;
                break;
            }
        }
        
        public static void SubscribeToEvent(GameEvent gameEvent , Action<AudioClip> actionFunction)
        {
            switch(gameEvent)
            {
                case GameEvent.BulletExploded:
                    BulletExplodedAction += actionFunction;
                break;
                
                case GameEvent.Shoot:
                    ShootAction += actionFunction;
                break;
            }
        }

        #endregion
        
        #region Unsubscribe Functions

        public static void UnsubscribeFromEvent(GameEvent gameEvent , Action actionFunction)
        {
            switch(gameEvent)
            {
                case GameEvent.Hit:
                    HitAction -= actionFunction;
                break;
                
                case GameEvent.PlayerGunReloading:
                    PlayerGunReloadingAction -= actionFunction;
                break;
            }
        }
        
        public static void UnsubscribeFromEvent(GameEvent gameEvent , Action<AudioClip> actionFunction)
        {
            switch(gameEvent)
            {
                case GameEvent.BulletExploded:
                    BulletExplodedAction -= actionFunction;
                break;
                
                case GameEvent.Shoot:
                    ShootAction -= actionFunction;
                break;
            }
        }

        #endregion
        
        #region Invoke Functions

        public static void Invoke(GameEvent gameEvent)
        {
            switch(gameEvent)
            {
                case GameEvent.Hit:
                    HitAction?.Invoke();    
                break;
                
                case GameEvent.PlayerGunReloading:
                    PlayerGunReloadingAction?.Invoke();
                break;
            }
        }
        
        public static void Invoke(GameEvent gameEvent , AudioClip clipToPlay)
        {
            switch(gameEvent)
            {
                case GameEvent.BulletExploded:
                    BulletExplodedAction?.Invoke(clipToPlay);
                break;
                
                case GameEvent.Shoot:
                    ShootAction?.Invoke(clipToPlay);
                break;
            }
        }

        #endregion
    }
}
