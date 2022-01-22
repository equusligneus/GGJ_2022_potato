using UnityEngine;

[RequireComponent(typeof(Player))]
public class WorldSwitchAbility : MonoBehaviour
{
    [SerializeField] RuntimeBool isInTransitRef = default;
    [SerializeField] RuntimeWorld currentWorldRef = default;

	private Player player;

	public bool CanChangeWorld
		=> currentWorldRef && isInTransitRef && !isInTransitRef.Value;

	private void Start()
	{
		player = GetComponent<Player>();
		if(player.SwitchAction != default)
			player.SwitchAction.performed += SwitchAction_performed;
	}

	private void OnDestroy()
	{
		if (player.SwitchAction != default)
			player.SwitchAction.performed -= SwitchAction_performed;
	}

	private void SwitchAction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		if (!CanChangeWorld)
			return;

		// Do checking here!!!

		SetWorld(currentWorldRef.Value == World.Default ? World.Alternative : World.Default);
	}

	void SetWorld(World _world)
	{
        if (!CanChangeWorld)
            return;

        currentWorldRef.SetValue(_world);
	}
}