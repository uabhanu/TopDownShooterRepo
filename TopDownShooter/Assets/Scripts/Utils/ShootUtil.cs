using UnityEngine;

public class ShootUtil : MonoBehaviour
{
    [SerializeField] private GameObject objectToShoot;
    [SerializeField] private Transform _barrelTransform;

    public void ShootObject()
    {
        Instantiate(objectToShoot , _barrelTransform.position , Quaternion.identity);
    }
}
