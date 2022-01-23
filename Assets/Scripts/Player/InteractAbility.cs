using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class InteractAbility : FocusAbility<Interactive>
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if (player.InteractAction != default)
            player.InteractAction.performed += InteractAction_performed;
    }

	private void OnDestroy()
    {
        if (player.InteractAction != default)
            player.InteractAction.performed -= InteractAction_performed;
    }

    private void InteractAction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!currentGrid || !currentGrid.Value)
            return;

        Interact();
    }

    private void Interact()
    {
        Debug.Log("Trying to interact with Item");
        if (!currentFocus)
            return;

        Debug.Log("Item interacted with");
        currentFocus.Interact();
    }
}
