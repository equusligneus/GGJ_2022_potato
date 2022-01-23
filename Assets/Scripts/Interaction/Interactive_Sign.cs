using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive_Sign : Interactive
{
	[TextArea(1, 5)]
	public string text;

	public RuntimeString currentTextRef;

	public override void Interact()
	{
		if (currentTextRef)
			currentTextRef.SetValue(text);
	}
}
