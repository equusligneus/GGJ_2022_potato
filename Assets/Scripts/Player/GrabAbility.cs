using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class GrabAbility : MonoBehaviour
{
    [SerializeField] private RuntimeGrid currentGrid;
    [SerializeField] private RuntimeInt2 currentPositionRef;
    [SerializeField] private RuntimeInt2 currentDirectionRef;

    [SerializeField] private RuntimeGrabbable grabbedObjectRef;

    private Player player;

    private bool HasObject => grabbedObjectRef.Value;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
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
            PickUp(currentGrid.Value.GetComponentAt<Grabbable>(currentPositionRef.Value + currentDirectionRef.Value));
	}

    private void Drop()
	{
        Debug.Log("Dropping Item");
        player.Shape.Remove(grabbedObjectRef.Value);
        grabbedObjectRef.SetValue(default);
	}

    private void PickUp(Grabbable _grabbable)
	{
        Debug.Log("Trying to grab Item");
        if (!_grabbable)
            return;

        Debug.Log("Item grabbed");

        player.Shape.Add(_grabbable);
        grabbedObjectRef.SetValue(_grabbable);
	}
}
