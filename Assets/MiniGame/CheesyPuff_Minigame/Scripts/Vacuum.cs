using UnityEngine;
public abstract class Vacuum : MonoBehaviour
{ 
    public bool isMissionCompleted=false;
    public virtual void SetActive(bool state)
    {
        gameObject.SetActive(state);
    }
    public abstract void Interact();

   
    public virtual bool IsMissionCompleted()
    {
        return isMissionCompleted;
    } 
}