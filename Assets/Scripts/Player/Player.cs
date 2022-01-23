using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	[SerializeField] private InputActionAsset inputs;

	[SerializeField] private RuntimeBool menuOpenRef;
	[SerializeField] private RuntimeBool interactingRef;
	[SerializeField] private RuntimeBool movingRef;

	[SerializeField] private RuntimeWorld worldRef;

	[SerializeField] private RuntimeFloat currentMoveSpeed;
	[SerializeField] private float normalSpeed = 5f;
	[SerializeField] private float dragSpeed = 2.5f;

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

	public bool CanReceiveInput
		=> !(menuOpenRef && menuOpenRef.Value) && !(movingRef && movingRef.Value);
	public bool CanTurnOrInteract
		=> CanReceiveInput && !(interactingRef && interactingRef.Value);

	public bool CanFocus
		=> !worldRef || worldRef.Value == World.Default;

	public PlayerShape Shape { get; } = new PlayerShape();

	private void Awake()
	{
		if (!inputs)
			return;

		var inGameMap = inputs.FindActionMap("InGame");
		if (inGameMap != default)
		{
			MovementAction = inGameMap.FindAction("Move");
			InteractAction = inGameMap.FindAction("Interact");
			SwitchAction = inGameMap.FindAction("Switch");
			OpenMenuAction = inGameMap.FindAction("Pause");
		}
		inputs.Enable();

		SetNormalSpeed();
	}

	public bool CanMove(Vector2Int _direction)
	{
		return true;
	}

	public void SetNormalSpeed()
	{
		if (currentMoveSpeed)
			currentMoveSpeed.SetValue(normalSpeed);
	}

	public void SetDragSpeed()
	{
		if (currentMoveSpeed)
			currentMoveSpeed.SetValue(dragSpeed);
	}
}
