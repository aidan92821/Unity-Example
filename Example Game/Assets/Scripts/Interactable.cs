using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract class for interactable objects
public abstract class Interactable : MonoBehaviour
{
    // Flag to determine whether to use events for interaction
    public bool useEvents;

    // Message displayed to player when looking at an interactable
    [SerializeField] public string promptMessage;
    
    // Method called when the player looks at the interactable
    public virtual string OnLook()
    {
        // Returns the prompt message to display when the player looks at the interactable
        return promptMessage;
    }

    // Method to handle interaction with the interactable
    public void BaseInteract()
    {
        // If using events, invoke the InteractionEvent associated with this interactable
        if (useEvents)
        {
            InvokeInteractionEvent();
        }

        // Call the Interact method to handle interaction-specific behavior
        Interact();
    }

    // Virtual method to be overridden by subclasses to define specific interaction behavior
    protected virtual void Interact()
    {
        // This method is a template to be overridden by subclasses
        // Subclasses will implement their own interaction logic
    }

    private void InvokeInteractionEvent()
    {
        // Check if an InteractionEvent component is attached to this GameObject
        InteractionEvent interactionEvent = GetComponent<InteractionEvent>();

    }
}
