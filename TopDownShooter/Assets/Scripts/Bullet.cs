using System.Collections;
using Events;
using ScriptableObjects;
using UnityEngine;
using Utils;

[RequireComponent(typeof(DestroyUtil))]
public class Bullet : MonoBehaviour
{
    #region Variables
    
    private Vector2 _startPosition;
    
    [SerializeField] private BulletDataSo bulletDataSo;
    [SerializeField] private DestroyUtil destroyUtil;
    [SerializeField] private Rigidbody2D bulletBody2D;
    [SerializeField] private SoundsDataSo soundsDataSo;
    
    #endregion

    #region Functions
    
    private void Start()
    {
        _startPosition = transform.position;
        bulletBody2D.velocity = transform.up * bulletDataSo.TravelSpeed * Time.fixedDeltaTime;
        StartCoroutine(DistanceTravelledCoroutine());
    }

    private IEnumerator DistanceTravelledCoroutine()
    {
        yield return new WaitForSeconds(bulletDataSo.DistanceTravelledCheckTimer);
        DestroyIfMaxDistanceTravelled();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameEventsManager.Invoke(GameEvent.BulletExploded , soundsDataSo.BulletExplosionClip);
        destroyUtil.DestroyObject();
    }

    private void DestroyIfMaxDistanceTravelled()
    {
        var distanceTravelled = Vector2.Distance(_startPosition , transform.position);

        if(distanceTravelled >= bulletDataSo.MaxDistanceTravelled)
        {
            GameEventsManager.Invoke(GameEvent.BulletExploded , soundsDataSo.BulletExplosionClip);
            destroyUtil.DestroyObject();
        }
        
        StartCoroutine(DistanceTravelledCoroutine());
    }
    
    #endregion
}
