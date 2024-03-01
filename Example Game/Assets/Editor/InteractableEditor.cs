using UnityEditor;

// Custom editor class for the Interactable component
[CustomEditor(typeof(Interactable), true)]
public class InteractableEditor : Editor
{
    // Override the default inspector GUI
    public override void OnInspectorGUI()
    {
        // Get the Interactable component instance
        Interactable interactable = (Interactable)target;

        // Check if the target is of type EventOnlyInteractable
        if (target.GetType() == typeof(EventOnlyInteractable))
        {
            // Display a text field for the prompt message
            interactable.promptMessage = EditorGUILayout.TextField("Prompt Message", interactable.promptMessage);

            // Display a help box indicating that EventOnlyInteractable can only use UnityEvents
            EditorGUILayout.HelpBox("EventOnlyInteract can ONLY use UnityEvents.", MessageType.Info);

            // Ensure that the InteractionEvent component is added to the GameObject
            EnsureInteractionEventComponent(interactable);

        }
        else
        {
            // Call the base inspector GUI method
            base.OnInspectorGUI();

            // Check if events are enabled for this Interactable
            ManageInteractionEventComponent(interactable);
        }
    }

    private static void ManageInteractionEventComponent(Interactable interactable)
    {
        if (interactable.useEvents)
        {
            // If events are enabled and the InteractionEvent component is not added, add it
            if (interactable.GetComponent<InteractionEvent>() == null)
            {
                interactable.gameObject.AddComponent<InteractionEvent>();
            }
        }
        else
        {
            // If events are not enabled and the InteractionEvent component is added, remove it
            if (interactable.GetComponent<InteractionEvent>() != null)
            {
                DestroyImmediate(interactable.GetComponent<InteractionEvent>());
            }
        }
    }

    private static void EnsureInteractionEventComponent(Interactable interactable)
    {
        if (interactable.GetComponent<InteractionEvent>() == null)
        {
            interactable.useEvents = true;
            interactable.gameObject.AddComponent<InteractionEvent>();
        }
    }
}
