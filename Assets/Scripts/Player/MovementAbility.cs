using UnityEngine;

[RequireComponent(typeof(Player))]
public class MovementAbility : MonoBehaviour, IMovable
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

	public Vector2Int Position
		=> PositionRef ? PositionRef.Value : Vector2Int.zero;

	public bool IsMoving
		=> isMovingRef && isMovingRef.Value;

	public void Start()
	{
		player = GetComponent<Player>();
		player.Shape.Add(this);
	}

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
		if (gridRef.Value.CanShapeMove(player.Shape, _input))
			player.Shape.Move(_input);
	} 

	public void SetTargetPosition(Vector2Int _targetPosition)
	{
		isMovingRef.SetValue(true);
		MoveTargetRef.SetValue(_targetPosition);
	}
}
