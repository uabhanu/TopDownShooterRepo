using System.Collections;
using UnityEngine;
using Utils;

[RequireComponent(typeof(DestroyUtil))]
public class Explosion : MonoBehaviour
{
    private DestroyUtil _destroyUtil;

    [SerializeField] private AnimationClip clip;
    
    private void Start()
    {
        _destroyUtil = GetComponent<DestroyUtil>();
        StartCoroutine(DestroyAfterAnimationEnumerator());
    }

    private IEnumerator DestroyAfterAnimationEnumerator()
    {
        yield return new WaitForSeconds(clip.length);
        _destroyUtil.DestroyObject();
    }
}
