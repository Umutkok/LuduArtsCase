using UnityEngine;
using InteractionSystem.Core;
public class Key : MonoBehaviour, IInteractable
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
