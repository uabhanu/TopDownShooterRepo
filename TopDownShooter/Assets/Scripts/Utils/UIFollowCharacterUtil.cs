using UnityEngine;

namespace Utils
{
    public class UIFollowCharacterUtil : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Transform characterToFollowTransform;

        private void Update()
        {
            if(characterToFollowTransform == null) return;
                
            transform.position = mainCamera.WorldToScreenPoint(characterToFollowTransform.position);
        }
    }
}
