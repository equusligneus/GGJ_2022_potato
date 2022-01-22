using UnityEngine;

[RequireComponent(typeof(GridSystem))]
public class LevelController : MonoBehaviour
{
	[SerializeField] private RuntimeGrid currentGridRef;
	[SerializeField] private RuntimeLevel currentLevelRef;
	
	[SerializeField] private Level myLevel;
	[SerializeField] private GridSystem myGrid;
	[SerializeField] private Transform myCameraTargetPoint;
	
	[SerializeField] private RuntimeBool isPlayerMovingRef;
	[SerializeField] private RuntimeInt2 playerMoveTargetRef;
	[SerializeField] private RuntimeVec3 cameraMoveTargetRef;

	private void Start()
	{
		if (!currentLevelRef)
			return;

		currentLevelRef.OnValueChanged += CurrentLevel_OnValueChanged;
		CurrentLevel_OnValueChanged(currentLevelRef.Value);
	}

	private void OnDestroy()
	{
		if (!currentLevelRef)
			return;

		currentLevelRef.OnValueChanged -= CurrentLevel_OnValueChanged;
	}

	private void OnDrawGizmos()
	{
		if (!myCameraTargetPoint)
			return;

		Gizmos.color = Color.red;
		Gizmos.DrawSphere(myCameraTargetPoint.position, 0.125f);
	}

	private void CurrentLevel_OnValueChanged(Level _value)
	{
		if (_value == myLevel)
			SetLevelActive();
	}

	private void SetLevelActive()
	{
		if (cameraMoveTargetRef && myCameraTargetPoint)
			cameraMoveTargetRef.SetValue(myCameraTargetPoint.position);

		if (!currentGridRef)
			return;

		currentGridRef.SetValue(myGrid);

		if(isPlayerMovingRef && playerMoveTargetRef)
		{
			isPlayerMovingRef.SetValue(true);
			playerMoveTargetRef.SetValue(myGrid.EntryPoint);
		}
	}
}
