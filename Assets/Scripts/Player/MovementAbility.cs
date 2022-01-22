using UnityEngine;

[RequireComponent(typeof(Player))]
public class MovementAbility : MonoBehaviour
{
	private Player player;

	[SerializeField] private RuntimeGrid gridRef;

	[SerializeField] private RuntimeBool isMovingRef;

	[SerializeField] private RuntimeInt2 PositionRef;
	[SerializeField] private RuntimeInt2 DirectionRef;
	[SerializeField] private RuntimeInt2 MoveTargetRef;

	[SerializeField] private float moveSpeed = 5.0f;

	private bool CanMoveAtAll
		=> !player.IsLocked && gridRef && isMovingRef && PositionRef && DirectionRef && MoveTargetRef;

	public void Start()
		=> player = GetComponent<Player>();

	private void Update()
	{
		if (!CanMoveAtAll)
			return;

		if(isMovingRef.Value)
		{
			DoMove();
			return;
		}

		Vector2Int input = player.MoveInput;
		SetDirection(input);
		SetMovement(input);
	}

	private void DoMove() 
	{
		Vector3 targetWorldPos = gridRef.Value.ToWorldPos(MoveTargetRef.Value);

		transform.position = Vector3.MoveTowards(transform.position, targetWorldPos, moveSpeed * Time.deltaTime);

		if (Vector3.Distance(transform.position, targetWorldPos) < Vector3.kEpsilon)
		{
			isMovingRef.SetValue(false);
			PositionRef.SetValue(MoveTargetRef.Value);
		}
	}

	private void SetDirection(Vector2Int _input)
	{
		if(player.CanChangeDirection)
			DirectionRef.SetValue(_input);
	}

	private void SetMovement(Vector2Int _input) 
	{
		Vector2Int target = MoveTargetRef.Value + _input;
		if(CanMove(_input))
		{
			isMovingRef.SetValue(true);
			MoveTargetRef.SetValue(target);
		}
	} 

	private bool CanMove(Vector2Int _direction)
	{
		return true;
	}
}
