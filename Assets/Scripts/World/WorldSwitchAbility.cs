using UnityEngine;

public class WorldSwitchAbility : MonoBehaviour
{
    [SerializeField] RuntimeBool isInTransit = default;
    [SerializeField] RuntimeWorld currentWorld = default;

    void SetWorld(World _world)
	{
        if (currentWorld == default || isInTransit == default || isInTransit.Value)
            return;

        currentWorld.SetValue(_world);
	}
}