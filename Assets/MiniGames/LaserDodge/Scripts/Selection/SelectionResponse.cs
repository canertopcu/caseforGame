using UnityEngine;

public class SelectionResponse : MonoBehaviour,ISelectResponse
{
    Transform _selection; 
    
    public void OnSelect(Transform selection)
    {
        _selection = selection;
    }


}
