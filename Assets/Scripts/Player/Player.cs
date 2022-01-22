using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	[SerializeField] private InputActionAsset inputs;

	public InputAction MovementAction { get; private set; } = default;

	public Vector2 MoveInputRaw
	{
		get
		{
			if (MovementAction == default)
				return default;

			return MovementAction.ReadValue<Vector2>();
		}
	}

	public Vector2Int MoveInput
	{
		get
		{
			var inputRaw = MoveInputRaw;

			if (Mathf.Abs(inputRaw.x) > Mathf.Abs(inputRaw.y))
				inputRaw.y = 0f;
			else
				inputRaw.x = 0f;

			return new Vector2Int(Mathf.RoundToInt(inputRaw.x), Mathf.RoundToInt(inputRaw.y));
		}
	}

	public InputAction InteractAction { get; private set; } = default;
	public InputAction SwitchAction { get; private set; } = default;
	public InputAction OpenMenuAction { get; private set; } = default;
	public bool IsLocked { get; internal set; } = false;
	public bool CanChangeDirection { get; private set; } = true;

	public PlayerShape Shape { get; } = new PlayerShape();

	private void Awake()
	{
		// solve all the input stuff here
		if (!inputs)
			return;

		var inGameMap = inputs.FindActionMap("InGame");
		if(inGameMap != default)
		{
			MovementAction = inGameMap.FindAction("Move");
			InteractAction = inGameMap.FindAction("Interact");
			SwitchAction = inGameMap.FindAction("Switch");
		}
		inputs.Enable();
	}

	public bool CanMove(Vector2Int _direction)
	{
		return true;
	}
}
