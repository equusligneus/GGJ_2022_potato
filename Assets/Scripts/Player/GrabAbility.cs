using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class GrabAbility : FocusAbility<Grabbable>
{
    [SerializeField] private RuntimeGrabbable grabbedObjectRef;
    [SerializeField] private RuntimeBool interactingRef;

    private bool HasObject => grabbedObjectRef.Value;

    private bool CanInteract
        => player.CanReceiveInput && currentGrid && currentGrid.Value && grabbedObjectRef;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(player.InteractAction != default)
			player.InteractAction.performed += InteractAction_performed;
    }

	private void OnDestroy()
	{
        if (player.InteractAction != default)
            player.InteractAction.performed -= InteractAction_performed;
	}

	private void InteractAction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
        if (!CanInteract)
            return;

        if (HasObject)
            Drop();
        else
            PickUp();
	}

    private void Drop()
	{
        Debug.Log("Dropping Item");
        player.Shape.Remove(grabbedObjectRef.Value);
        grabbedObjectRef.SetValue(default);
        if (interactingRef)
            interactingRef.SetValue(false);
	}

    private void PickUp()
	{
        Debug.Log("Trying to grab Item");
        if (!currentFocus)
            return;

        Debug.Log("Item grabbed");

        player.Shape.Add(currentFocus);
        grabbedObjectRef.SetValue(currentFocus);
        if (interactingRef)
            interactingRef.SetValue(true);
    }
}
