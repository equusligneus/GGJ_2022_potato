using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SwitchableAnim : Switchable
{
	public override void Switch(bool _on)
	{
		GetComponent<Animator>().SetBool("isOn", _on);
	}
}
