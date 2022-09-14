
using UnityEngine;

public interface ISelector
{
    Transform GetSelection();
    void Check(Ray ray);
}
public interface ISelectResponse
{
    void OnSelect(Transform selection); 
    
}

public interface IMoveResponse
{ 
    void OnMove(Vector3 deltaPosition,Transform selectedObject);
}
 
public interface IRaycastProvider
{
    Ray CreateRay(Vector3 position);
}
