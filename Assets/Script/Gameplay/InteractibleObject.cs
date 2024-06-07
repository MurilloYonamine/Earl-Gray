using UnityEngine;
using UnityEngine.EventSystems;

public class InteractibleObject : TwoStateObject, IPointerClickHandler
{
    [SerializeField] private bool isSelectable = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isSelectable) return;
        SwapState();
        Debug.Log("Clicou");
    }

    public override void Active()
    {
        base.Active();
        Debug.Log("Ativo");
    }

    public override void Desactive()
    {
        base.Desactive();
        Debug.Log("Desativado");
    }
}
