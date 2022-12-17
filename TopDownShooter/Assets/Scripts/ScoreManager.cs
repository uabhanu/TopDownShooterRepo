using DataPersistence;
using Events;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private TMP_Text scoreValueLabel;

    #endregion

    #region Functions
    
    private void Awake()
    {
        scoreValueLabel.text = GameDataManager.GameData.Score.ToString();
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void OnEnemyDied(int incrementValue)
    {
        GameDataManager.GameData.Score += incrementValue;
        scoreValueLabel.text = GameDataManager.GameData.Score.ToString();
    }

    private void OnLoad()
    {
        scoreValueLabel.text = GameDataManager.GameData.Score.ToString();
    }

    private void SubscribeToEvents()
    {
        GameEventsManager.SubscribeToEvent(GameEvent.EnemyDied , OnEnemyDied);
        GameEventsManager.SubscribeToEvent(GameEvent.Load , OnLoad);
    }

    private void UnsubscribeFromEvents()
    {
        GameEventsManager.UnsubscribeFromEvent(GameEvent.EnemyDied , OnEnemyDied);
        GameEventsManager.UnsubscribeFromEvent(GameEvent.Load , OnLoad);
    }
    
    #endregion
}
