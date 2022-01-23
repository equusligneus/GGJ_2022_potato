using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class GrabAbility : FocusAbility<Grabbable>
{
    [SerializeField] private RuntimeGrabbable grabbedObjectRef;

    private bool HasObject => grabbedObjectRef.Value;

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
        if (!currentGrid || !currentGrid.Value || !grabbedObjectRef)
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
	}

    private void PickUp()
	{
        Debug.Log("Trying to grab Item");
        if (!currentFocus)
            return;

        Debug.Log("Item grabbed");

        player.Shape.Add(currentFocus);
        grabbedObjectRef.SetValue(currentFocus);
	}
}
