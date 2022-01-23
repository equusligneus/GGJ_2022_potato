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

	private void OnTriggerEnter2D(Collider2D collision)
		=> Switch(true);

	private void OnTriggerExit2D(Collider2D other)
		=> Switch(false);

	private void Switch(bool _on)
	{
		foreach (var s in switchables)
		{
			if (!s)
				continue;

			s.Switch(_on);
		}
	}
}
