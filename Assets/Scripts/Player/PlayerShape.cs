using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public interface IMovable
{
	Vector2Int Position { get; }

	bool IsMoving { get; }

	void SetTargetPosition(Vector2Int _targetPosition);

}

public class PlayerShape
{
	public List<IMovable> parts = new List<IMovable>();

	public void Add(IMovable _part)
	{
		if (_part == default || parts.Contains(_part))
			return;

		parts.Add(_part);
	}

	public void Remove(IMovable _part)
		=> parts.Remove(_part);

	public List<Vector2Int> GetNonOverlappingTargetPositions(Vector2Int _delta)
	{
		List<Vector2Int> targetPositions = new List<Vector2Int>();

		foreach (var part in parts)
		{
			if (part == default)
				continue;

			Vector2Int targetPos = part.Position + _delta;

			if (parts.Any(p => p != default && p.Position == targetPos))
				continue;

			targetPositions.Add(targetPos);
		}

		return targetPositions;
	}

	public void Move(Vector2Int _delta)
	{
		foreach (var part in parts)
		{
			if (part == default)
				continue;

			part.SetTargetPosition(part.Position + _delta);
		}
	}
}
