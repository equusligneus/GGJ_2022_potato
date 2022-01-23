using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelStateWatcher))]
public class Grabbable : Focusable, IMovable
{
	[SerializeField] private GridSystem grid;
	[SerializeField] private RuntimeFloat moveSpeedRef;

	[SerializeField] private Vector2Int position;
	private Vector2Int target;
	private LevelStateWatcher watcher;

	public Vector2Int Position => position;

	public bool IsMoving { get; private set; } = true;

	private bool CanMoveAtAll
		=> watcher.IsInLevel && grid && moveSpeedRef;

	public void SetTargetPosition(Vector2Int _targetPosition)
	{
		if (!CanMoveAtAll)
			return;

		IsMoving = true;
		target = _targetPosition;
	}

	private void Start()
	{
		watcher = GetComponent<LevelStateWatcher>();
	}

	private void Update()
	{
		if (!CanMoveAtAll)
			return;

		if (!IsMoving)
			return;

		Vector3 targetWorldPos = grid.ToWorldPos(target);

		transform.position = Vector3.MoveTowards(transform.position, targetWorldPos, moveSpeedRef.Value * Time.deltaTime);

		if (Vector3.Distance(transform.position, targetWorldPos) < Vector3.kEpsilon)
		{
			IsMoving = false;
			position = target;
		}
	}
}
