using UnityEngine;

public class TwoStateObject : MonoBehaviour
{
    [field: SerializeField] public bool IsActive { get; private set; }

    public void SwapState()
    {
        if (IsActive)
        {
            Desactive();
        }
        else
        {
            Active();
        }
    }

    public virtual void Active()
    {
        IsActive = true;
    }

    public virtual void Desactive()
    {
        IsActive = false;
    }
}
