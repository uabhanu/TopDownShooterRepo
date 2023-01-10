using UnityEngine;

namespace Utils
{
    public class UIFollowCharacterUtil : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;

        private void Update()
        {
            transform.position = targetTransform.position;
        }
    }
}
