using UnityEngine;

namespace Utils
{
    [RequireComponent(typeof(DestroyUtil))]
    public class UIFollowCharacterUtil : MonoBehaviour
    {
        private DestroyUtil _destroyUtil;
        
        [SerializeField] private Transform targetTransform;

        private void Awake()
        {
            _destroyUtil = GetComponent<DestroyUtil>();
        }

        private void Update()
        {
            if(targetTransform != null)
            {
                transform.position = targetTransform.position;   
            }
            else
            {
                _destroyUtil.DestroyObject();
            }
        }
    }
}
