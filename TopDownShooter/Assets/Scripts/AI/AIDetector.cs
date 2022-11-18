using ScriptableObjects;
using UnityEngine;

namespace AI
{
    public class AIDetector : MonoBehaviour
    {
        #region Variables
        
        private Collider2D _playerCollider2D;

        [SerializeField] private AIData aiDataSo;
        [SerializeField] private Color gizmosColor;
        [SerializeField] private LayerMask playerLayerMask;
        
        #endregion

        #region Functions
        
        private void Update()
        {
            _playerCollider2D = DetectPlayerCollider2D();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmosColor;
            Gizmos.DrawWireSphere(transform.position , aiDataSo.DetectorRadius);
        }

        private Collider2D DetectPlayerCollider2D()
        {
            Collider2D playerCollider = Physics2D.OverlapCircle(transform.position , aiDataSo.DetectorRadius , playerLayerMask);
            return playerCollider;
        }
        
        #endregion
    }
}
