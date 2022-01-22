using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelStateWatcher))]
public class Grabbable : MonoBehaviour, IMovable
{
	public Vector2Int Position => Vector2Int.zero;

	public bool IsMoving => false;

	public void SetTargetPosition(Vector2Int _targetPosition)
	{
		
	}
}
