using UnityEngine;

[RequireComponent(typeof(Player))]
public class WorldSwitchAbility : MonoBehaviour
{
    [SerializeField] RuntimeBool isInTransit = default;
    [SerializeField] RuntimeWorld currentWorld = default;

	private Player player;

	public bool CanChangeWorld
		=> currentWorld != default && isInTransit != default && !isInTransit.Value;

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

		SetWorld(currentWorld.Value == World.Default ? World.Alternative : World.Default);
	}

	void SetWorld(World _world)
	{
        if (!CanChangeWorld)
            return;

        currentWorld.SetValue(_world);
	}
}