using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementResponse : MonoBehaviour, IMoveResponse
{ 
    public void OnMove(Vector3 deltaPosition, Transform selection)
    {
        selection.position += deltaPosition * Time.deltaTime;
    }
}
