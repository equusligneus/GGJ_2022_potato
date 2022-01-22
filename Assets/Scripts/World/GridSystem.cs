using UnityEngine;

public class GridSystem : MonoBehaviour
{
	[SerializeField] private Transform myOriginOverride;
	[SerializeField] private Vector2 tileSize;
	[SerializeField] private Vector2Int entryPoint;

	[SerializeField] private RuntimeBool isPlayerMoving;
	[SerializeField] private RuntimeInt2 playerMoveTarget;

	public Vector3 Origin
		=> myOriginOverride ? myOriginOverride.position : transform.position;

	public Vector3 ToWorldPos(Vector2Int _gridPos)
		=> Origin + new Vector3(_gridPos.x * tileSize.x, _gridPos.y * tileSize.y, 0f);

	public Vector2Int EntryPoint => entryPoint;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(Origin, 0.125f);

		Gizmos.color = Color.green;
		Gizmos.DrawSphere(ToWorldPos(entryPoint), 0.125f);
	}
}
