using System;
using UnityEngine;

namespace Events
{
    public class InputEventsManager
    {
        #region Actions
		
        protected static event Action MouseLeftClickedAction;
        protected static event Action<Vector2> MouseMovedAction;
        protected static event Action<Vector2> MovementKeysPressedAction;

        #endregion

        #region Functions
		
        public static void SubscribeToEvent(InputEvent inputEvent , Action actionFunction)
        {
            switch(inputEvent)
            {
                case InputEvent.MouseLeftClicked:
                    MouseLeftClickedAction += actionFunction;
                break;
            }
        }
        
        public static void SubscribeToEvent(InputEvent inputEvent , Action<Vector2> actionFunction)
        {
            switch(inputEvent)
            {
                case InputEvent.MouseMoved:
                    MouseMovedAction += actionFunction;
                break;
                
                case InputEvent.MovementKeysPressed:
                    MovementKeysPressedAction += actionFunction;
                break;
            }
        }
        
        public static void UnsubscribeFromEvent(InputEvent inputEvent , Action actionFunction)
        {
            switch(inputEvent)
            {
                case InputEvent.MouseLeftClicked:
                    MouseLeftClickedAction -= actionFunction;
                break;
            }
        }
        
        public static void UnsubscribeFromEvent(InputEvent inputEvent , Action<Vector2> actionFunction)
        {
            switch(inputEvent)
            {
                case InputEvent.MouseMoved:
                    MouseMovedAction -= actionFunction;
                break;
                
                case InputEvent.MovementKeysPressed:
                    MovementKeysPressedAction -= actionFunction;
                break;
            }
        }

        public static void Invoke(InputEvent inputEvent)
        {
            switch(inputEvent)
            {
                case InputEvent.MouseLeftClicked:
                    MouseLeftClickedAction?.Invoke();
                break;
            }
        }
        
        public static void Invoke(InputEvent inputEvent , Vector2 movementVector)
        {
            switch(inputEvent)
            {
                case InputEvent.MouseMoved:
                    MouseMovedAction?.Invoke(movementVector);
                break;
                
                case InputEvent.MovementKeysPressed:
                    MovementKeysPressedAction?.Invoke(movementVector);
                break;
            }
        }
        
        #endregion
    }
}
