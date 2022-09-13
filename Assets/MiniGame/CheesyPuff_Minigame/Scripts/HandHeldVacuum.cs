using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHeldVacuum : Vacuum
{
    public Transform collectPoint;
    public InteracableCheeses Interactable;

    public override void Interact()
    {
        isMissionCompleted = !Interactable.IsInteractable(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.GetComponent<Collectable>().Collect(collectPoint); 
        }
    }

}
