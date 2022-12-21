using Events;
using UnityEngine;
using Utils;

[RequireComponent(typeof(ObjectSpawnerUtil))]
public class LevelProgression : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyObjsInTheScene;
    [SerializeField] private int _totalEnemiesCount;

    private void Start()
    {
        GetEnemiesInScene();
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void GetEnemiesInScene()
    {
        _enemyObjsInTheScene = GameObject.FindGameObjectsWithTag($"Enemy");
        _totalEnemiesCount = _enemyObjsInTheScene.Length;
    }

    private void OnEnemyDied(int notCurrentlyInUse)
    {
        if(_totalEnemiesCount > 0)
        {
            _totalEnemiesCount--;   
        }

        if(_totalEnemiesCount == 0)
        {
            GetComponent<ObjectSpawnerUtil>().SpawnObject();
        }
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
