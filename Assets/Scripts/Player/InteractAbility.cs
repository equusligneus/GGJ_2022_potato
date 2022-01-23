using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class InteractAbility : FocusAbility<Interactive>
{
	[SerializeField] private RuntimeBool interactingRef;

	private bool CanInteract
		=> player.CanTurnOrInteract && (!interactingRef || !interactingRef.Value) && currentFocus;

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
		Interact();
	}

	private void Interact()
	{
		Debug.Log("Trying to interact with Item");
		if (!CanInteract)
			return;

		Debug.Log("Item interacted with");
		currentFocus.Interact();
		StartCoroutine(SetInteraction());
	}

	private IEnumerator SetInteraction()
	{
		if (interactingRef)
		{
			interactingRef.SetValue(true);
			yield return null;
			interactingRef.SetValue(false);
		}
	}
}
