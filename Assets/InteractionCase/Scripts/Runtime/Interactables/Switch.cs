using UnityEngine;
using InteractionSystem.Core;
public class Switch : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionType interactionType;

    public InteractionType InteractionType => interactionType;

    public void InteractInstant()
    {
        
    }


    public void InteractHold(float holdProgress)
    {
        
    }


    public void InteractToggle()
    {
        
    }
}