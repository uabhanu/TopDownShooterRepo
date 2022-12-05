using Events;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundMusicSource;
    [SerializeField] private AudioSource inGameSoundsSource;
    
    private void Awake()
    {
        backgroundMusicSource.Play();
        SubscribeToEvents();
    }
    
    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    public void OnShoot(AudioClip clipToPlay)
    {
        inGameSoundsSource.clip = clipToPlay;
        inGameSoundsSource.Play();
    }
    
    private void SubscribeToEvents()
    {
        GameEventsManager.SubscribeToEvent(GameEvent.Shoot , OnShoot);
    }

    private void UnsubscribeFromEvents()
    {
        GameEventsManager.UnsubscribeFromEvent(GameEvent.Shoot , OnShoot);
    }
}
