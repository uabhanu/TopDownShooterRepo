using Events;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Variables
    
    [SerializeField] private AudioSource backgroundMusicSource;
    [SerializeField] private AudioSource inGameSoundsSource;
    
    #endregion
    
    #region MonoBehaviour Functions
    
    private void Awake()
    {
        backgroundMusicSource.Play();
        SubscribeToEvents();
    }
    
    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    #endregion
    
    #region User Defined Event Functions

    private void OnBulletExploded(AudioClip clipToPlay)
    {
        inGameSoundsSource.clip = clipToPlay;
        inGameSoundsSource.Play();
    }

    private void OnShoot(AudioClip clipToPlay)
    {
        inGameSoundsSource.clip = clipToPlay;
        inGameSoundsSource.Play();
    }
    
    private void SubscribeToEvents()
    {
        GameEventsManager.SubscribeToEvent(GameEvent.BulletExploded , OnBulletExploded);
        GameEventsManager.SubscribeToEvent(GameEvent.Shoot , OnShoot);
    }

    private void UnsubscribeFromEvents()
    {
        GameEventsManager.UnsubscribeFromEvent(GameEvent.BulletExploded , OnBulletExploded);
        GameEventsManager.UnsubscribeFromEvent(GameEvent.Shoot , OnShoot);
    }
    
    #endregion
}
