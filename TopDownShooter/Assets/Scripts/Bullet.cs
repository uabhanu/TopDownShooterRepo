using UnityEngine;

[RequireComponent(typeof(DestroyUtil))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletDataSo bulletDataSo;
    [SerializeField] private DestroyUtil destroyUtil;
    [SerializeField] private Rigidbody2D bulletBody2D;

    //private void FixedUpdate()
    //{
    //    bulletBody2D.velocity = transform.right * bulletDataSo.TravelSpeed * Time.fixedDeltaTime;
    //}

    private void CalculateTravelDirection()
    {

    }
}
