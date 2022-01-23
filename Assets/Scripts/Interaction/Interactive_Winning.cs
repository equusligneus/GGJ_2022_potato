using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive_Winning : Interactive
{
	public RuntimeGameState currentTextRef;

	public override void Interact()
	{
		if (currentTextRef)
			currentTextRef.SetValue(GameState.Winning);
	}
}
