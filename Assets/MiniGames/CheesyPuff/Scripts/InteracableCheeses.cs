using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracableCheeses : AInteractable
{

    public override bool IsInteractable()
    {
        isInteractable = transform.childCount > 0;
        return isInteractable;
    }
}
