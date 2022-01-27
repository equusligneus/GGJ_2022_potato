using System.Collections.Generic;
using UnityEngine;

public abstract class Switchable : MonoBehaviour
{
	public abstract void Switch(bool _on);
}

[RequireComponent(typeof(BoxCollider2D))]
public class PressurePlate : MonoBehaviour
{
	public List<Switchable> switchables;
	private int pressCharges = 0;

	private void OnTriggerEnter2D(Collider2D collision)
		=> SetPressed(true);

	private void OnTriggerExit2D(Collider2D other)
		=> SetPressed(false);

	private void SetPressed(bool _on)
	{
		pressCharges += _on ? 1 : -1;

		if (pressCharges < 0 || pressCharges > 1)
			return;

		foreach (var s in switchables)
		{
			if (!s)
				continue;

			s.Switch(pressCharges > 0);
		}
	}
}
