using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class OpenPauseMenuAbility : MonoBehaviour
{
	private Player player;

	[SerializeField] private RuntimeBool requirePauseRef;
	private bool CanPause
		=> player.CanReceiveInput && requirePauseRef;

	// Start is called before the first frame update
	protected void Start()
	{
		player = GetComponent<Player>();
		if (player.OpenMenuAction != default)
			player.OpenMenuAction.performed += OpenMenuAction_performed;
	}

	private void OnDestroy()
	{
		if (player.OpenMenuAction != default)
			player.OpenMenuAction.performed -= OpenMenuAction_performed;
	}

	private void OpenMenuAction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		if (CanPause)
			requirePauseRef.SetValue(true);
	}
}
