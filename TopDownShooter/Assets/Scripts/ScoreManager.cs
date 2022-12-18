using DataPersistence;
using Events;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour , IDataPersistence
{
    #region Variables

    [SerializeField] private int _score;
    
    [SerializeField] private TMP_Text scoreValueLabel;

    #endregion

    #region Functions
    
    private void Awake()
    {
        scoreValueLabel.text = _score.ToString();
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void OnEnemyDied(int incrementValue)
    {
        _score += incrementValue;
        scoreValueLabel.text = _score.ToString();
    }

    private void SubscribeToEvents()
    {
        GameEventsManager.SubscribeToEvent(GameEvent.EnemyDied , OnEnemyDied);
    }

    private void UnsubscribeFromEvents()
    {
        GameEventsManager.UnsubscribeFromEvent(GameEvent.EnemyDied , OnEnemyDied);
    }
    
    public void LoadData(GameData gameData)
    {
        _score = gameData.Score;
        scoreValueLabel.text = _score.ToString();
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.Score = _score;
    }
    
    #endregion
}
