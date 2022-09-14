using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterVacuum :  Vacuum
{
    public InteracableDirt Interactable;

    public override void Interact()
    {
        isMissionCompleted = !Interactable.IsInteractable();
    }

}
