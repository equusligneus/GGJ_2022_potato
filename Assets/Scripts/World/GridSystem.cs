using System;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
	[SerializeField] private Transform myOriginOverride;
	[SerializeField] private float tileSize;
	[SerializeField] private Vector2Int entryPoint;

	[SerializeField] private RuntimeBool isPlayerMoving;
	[SerializeField] private RuntimeInt2 playerMoveTarget;

	public Vector2Int fieldSize;

	public Vector3 Origin
		=> myOriginOverride ? myOriginOverride.position : transform.position;

	public Vector2Int EntryPoint
		=> entryPoint;

	public Vector3 ToWorldPos(Vector2Int _gridPos)
		=> Origin + new Vector3(_gridPos.x * tileSize, _gridPos.y * tileSize, 0f);

	public Vector2Int ToGridPos(Vector3 position)
		=> tileSize > 0 ? new Vector2Int(Mathf.RoundToInt((position.x - Origin.x) / tileSize), Mathf.RoundToInt((position.y - Origin.y) / tileSize)) : Vector2Int.zero;

	public bool CanShapeMove(PlayerShape _shape, Vector2Int _direction)
	{
		var targetPositions = _shape.GetNonOverlappingTargetPositions(_direction);

		foreach (var pos in targetPositions)
		{
			if (CollisionTest(pos))
				return false;
		}

		return true;
	}


	public T GetComponentAt<T>(Vector2Int _gridPos) where T : Component
	{
		var collider = CollisionTest(_gridPos);
		if (!collider)
		{
			Debug.LogFormat("Nothing at {0}", _gridPos);
			return default;
		}

		Debug.LogFormat("Getting Component {0} on {1}", typeof(T).Name, collider.gameObject.name);

		return collider.GetComponent<T>();
	}

	private Collider2D CollisionTest(Vector2Int _position)
	{
		var collider = Physics2D.OverlapCircle(ToWorldPos(_position), 0.4f * tileSize);
		if (!collider || collider.isTrigger)
			return default;

		return collider;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(Origin, 0.125f);

		Gizmos.color = Color.green;
		Gizmos.DrawSphere(ToWorldPos(entryPoint), 0.125f);

		Gizmos.color = Color.grey;
		for (int x = 0; x < fieldSize.x; ++x)
		{
			for (int y = 0; y < fieldSize.y; ++y)
			{
				Gizmos.DrawWireCube(ToWorldPos(new Vector2Int(x, y)), Vector3.one * tileSize);
			}
		}
	}
}
