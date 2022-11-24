using ScriptableObjects;
using UnityEngine;

namespace AI
{
    public class AIDetector : MonoBehaviour
    {
        #region Variables

        private Collider2D _playerCollider2D;
        
        [SerializeField] private AIDataSo aiDataSo;
        [SerializeField] private Color gizmosColor;
        [SerializeField] private LayerMask playerLayerMask;

        #endregion

        #region Functions
        
        private void Update()
        {
            DetectPlayerCollider2D();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmosColor;
            Gizmos.DrawWireSphere(transform.position , aiDataSo.DetectorRadius);
        }

        private void DetectPlayerCollider2D()
        {
            _playerCollider2D = Physics2D.OverlapCircle(transform.position , aiDataSo.DetectorRadius , playerLayerMask);
        }

        public bool IsTargetInSight()
        {
            return _playerCollider2D;
        }

        public GameObject Target()
        {
            return _playerCollider2D.gameObject;
        }
        
        #endregion
    }
}
