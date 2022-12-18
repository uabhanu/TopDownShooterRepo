using Events;
using ScriptableObjects;
using UnityEngine;

namespace Utils
{
    [RequireComponent(typeof(DestroyUtil) , typeof(DestroyedCheckerUtil))]
    public class DamageableUtil : MonoBehaviour
    {
        #region Variables

        private DestroyedCheckerUtil _destroyedCheckerUtil;
        
        [SerializeField] private AIDataSo aiDataSo;
        [SerializeField] private bool isEnemy;
        [SerializeField] private int _health;
        [SerializeField] private HealthDataSo healthDataSo;
        
        #endregion

        #region MonoBehaviour Functions
        
        private void Awake()
        {
            _destroyedCheckerUtil = GetComponent<DestroyedCheckerUtil>();
            _health = healthDataSo.MaxHealth;
        }

        private void OnTriggerEnter2D(Collider2D col2D)
        {
            GameObject collidedObj = col2D.gameObject;
            BulletDataSo collidedObjBulletData = collidedObj.GetComponent<Bullet>().BulletData;
            
            if(_health > 0)
            {
                _health -= collidedObjBulletData.Damage;
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
        }
        
        #endregion
    }
}
