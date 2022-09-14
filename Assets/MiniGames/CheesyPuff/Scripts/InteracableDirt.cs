using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracableDirt : AInteractable
{
    private P3dChannelCounter channelCounter;
    private void Start()
    {
        channelCounter = GetComponentInChildren<P3dChannelCounter>();
    }

    public override bool IsInteractable()
    { 
        isInteractable = channelCounter.RatioA > 0.1f;
        return isInteractable;
    }

}
