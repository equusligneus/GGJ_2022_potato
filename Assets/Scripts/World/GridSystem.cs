using UnityEngine;

public class GridSystem : MonoBehaviour
{
	[SerializeField] private Transform myOriginOverride;
	[SerializeField] private float tileSize;
	[SerializeField] private Vector2Int entryPoint;

	[SerializeField] private RuntimeBool isPlayerMoving;
	[SerializeField] private RuntimeInt2 playerMoveTarget;

	public Vector3 Origin
		=> myOriginOverride ? myOriginOverride.position : transform.position;

	public Vector2Int EntryPoint
		=> entryPoint;

	public Vector3 ToWorldPos(Vector2Int _gridPos)
		=> Origin + new Vector3(_gridPos.x * tileSize, _gridPos.y * tileSize, 0f);

	public bool CanShapeMove(PlayerShape _shape, Vector2Int _direction)
	{
		var targetPositions = _shape.GetNonOverlappingTargetPositions(_direction);

		foreach(var pos in targetPositions)
		{
			if (Physics2D.OverlapCircle(ToWorldPos(pos), 0.4f * tileSize))
				return false;
		}

		return true;
	}

	public T GetComponentAt<T>(Vector2Int _gridPos) where T : Component
	{
		var collider = Physics2D.OverlapCircle(ToWorldPos(_gridPos), 0.4f * tileSize);
		if (!collider)
		{
			Debug.LogFormat("Northing at {0}", _gridPos);
			return default;
		}

		Debug.LogFormat("Getting Component {0} on {1}", typeof(T).Name, collider.gameObject.name);

		return collider.GetComponent<T>();
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(Origin, 0.125f);

		Gizmos.color = Color.green;
		Gizmos.DrawSphere(ToWorldPos(entryPoint), 0.125f);
	}
}
