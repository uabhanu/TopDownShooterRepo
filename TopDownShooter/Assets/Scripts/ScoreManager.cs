using Events;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _scoreValue;
    
    [SerializeField] private TMP_Text scoreValueLabel;

    private void Awake()
    {
        _scoreValue = 0; //TODO Get the score value from PlayerPrefs
        scoreValueLabel.text = _scoreValue.ToString();
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void OnEnemyDied(int incrementValue)
    {
        _scoreValue += incrementValue;
        scoreValueLabel.text = _scoreValue.ToString();
    }

    private void SubscribeToEvents()
    {
        GameEventsManager.SubscribeToEvent(GameEvent.EnemyDied , OnEnemyDied);
    }

    private void UnsubscribeFromEvents()
    {
        GameEventsManager.UnsubscribeFromEvent(GameEvent.EnemyDied , OnEnemyDied);
    }
}
