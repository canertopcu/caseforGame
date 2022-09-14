using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{
    public SkinnedMeshRenderer skinnedMesh;
    public void Collect(Transform collector)
    {
        transform.parent = collector;
        Sequence seq = DOTween.Sequence();
        seq.Join( transform.DOLocalMove(Vector3.zero, 1f).OnComplete(() => Destroy(gameObject)));
        seq.Join( transform.DOScale(transform.localScale*0.2f, 1f));
        seq.Join(DOTween.To(() => skinnedMesh.GetBlendShapeWeight(0), (x) => skinnedMesh.SetBlendShapeWeight(0, x), 100f, 1f)); 
    }
}
