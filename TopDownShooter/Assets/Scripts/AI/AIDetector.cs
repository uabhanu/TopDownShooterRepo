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
        [SerializeField] private int playerLayerMaskValue;
        [SerializeField] private LayerMask collisionsEnabledLayerMasks;
        
        #endregion

        #region Functions
        
        private void Update()
        {
            PlayerInTheCircle();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmosColor;
            Gizmos.DrawWireSphere(transform.position , aiDataSo.DetectorRadius);
        }

        private void PlayerInTheCircle()
        {
            _playerCollider2D = Physics2D.OverlapCircle(transform.position , aiDataSo.DetectorRadius , collisionsEnabledLayerMasks);
        }

        public bool IsPlayerInSight()
        {
            if(PlayerCollider2D != null)
            {
                RaycastHit2D hit2D = Physics2D.Raycast(transform.position , PlayerCollider2D.transform.position - transform.position , aiDataSo.DetectorRadius , collisionsEnabledLayerMasks);
                Debug.DrawRay(transform.position , PlayerCollider2D.transform.position - transform.position , Color.blue);

                if(hit2D.collider != null && hit2D.collider.gameObject.layer == playerLayerMaskValue)
                {
                    return true;       
                }
            }
            
            return false;
        }
        
        public Collider2D PlayerCollider2D
        {
            get => _playerCollider2D;
            set => _playerCollider2D = value;
        }

        #endregion
    }
}
