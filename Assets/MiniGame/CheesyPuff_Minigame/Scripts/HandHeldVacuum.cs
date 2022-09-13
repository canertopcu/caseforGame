using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHeldVacuum : Vacuum
{
    public Transform lookAtPoint;
    public Transform collectPoint;
    public InteracableCheeses Interactable;

    public override void Interact()
    {
        isMissionCompleted = !Interactable.IsInteractable();
        transform.DOLookAt(lookAtPoint.position,0.3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.GetComponent<Collectable>().Collect(collectPoint); 
        }
    }

}
