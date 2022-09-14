using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRayProvider : MonoBehaviour,IRaycastProvider
{
    public Ray CreateRay(Vector3 pos)
    {
        return Camera.main.ScreenPointToRay(pos);
    }
     
}
