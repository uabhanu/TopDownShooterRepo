using DataPersistence;
using DataPersistence.Data;
using Events;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    [RequireComponent(typeof(DestroyUtil) , typeof(DestroyedCheckerUtil) , typeof(ObjectSpawnerUtil))]
    public class DamageableUtil : MonoBehaviour , IDataPersistence
    {
        #region Variables

        private DestroyedCheckerUtil _destroyedCheckerUtil;
        private int _health;
        
        [SerializeField] private AIDataSo aiDataSo;
        [SerializeField] private bool isEnemy;
        [SerializeField] private int maxHealth;
        [SerializeField] private Slider healthBarSlider;
        [SerializeField] private string objType;

        #endregion

        #region MonoBehaviour Functions
        
        private void Awake()
        {
            _destroyedCheckerUtil = GetComponent<DestroyedCheckerUtil>();
            _health = maxHealth;
            healthBarSlider.value = (float)_health / maxHealth;
        }

        private void OnTriggerEnter2D(Collider2D col2D)
        {
            GameObject collidedObj = col2D.gameObject;
            BulletDataSo collidedObjBulletData = collidedObj.GetComponent<Bullet>().BulletData;

            if(_health > 0)
            {
                _health -= collidedObjBulletData.Damage;
                healthBarSlider.value = (float)_health / maxHealth;
            }
            
            if(_health <= 0)
            {
                if(isEnemy)
                {
                    GameEventsManager.Invoke(GameEvent.EnemyDied , aiDataSo.DeathScoreValue);
                }
                
                _destroyedCheckerUtil.IsDead = true;
                Die();
            }
        }

        #endregion

        #region User Defined Custom Functions
        
        private void Die()
        {
            GetComponent<DestroyUtil>().DestroyObject();
            GetComponent<ObjectSpawnerUtil>().SpawnObject();
        }
        
        public void LoadData(GameData gameData)
        {
            switch(objType)
            {
                case "Full Obstacle":
                    _health = gameData.FullObstacleHealth;
                    healthBarSlider.value = (float)_health / maxHealth;
                break;
                
                case "Moving Enemy":
                    _health = gameData.MovingEnemyHealth;
                    healthBarSlider.value = (float)_health / maxHealth;
                break;
                
                case "Player":
                    _health = gameData.PlayerHealth;
                    healthBarSlider.value = (float)_health / maxHealth;
                break;
                
                case "Stationary Enemy":
                    _health = gameData.StationaryEnemyHealth;
                    healthBarSlider.value = (float)_health / maxHealth;
                break;
            }
        }

        public void SaveData(ref GameData gameData)
        {
            switch(objType)
            {
                case "Full Obstacle":
                    gameData.FullObstacleHealth = _health;
                break;
                
                case "Moving Enemy":
                    gameData.MovingEnemyHealth = _health;
                break;
                
                case "Player":
                    gameData.PlayerHealth = _health;
                break;
                
                case "Stationary Enemy":
                    gameData.StationaryEnemyHealth = _health;
                break;
            }
        }

        #endregion
    }
}
