using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellEditor : MonoBehaviour
{

	public int Id;
	private Transform _transform;
	public Transform Transform { get { return _transform; } }
	public CircleEditor CircleBusy;
	public CircleEditor StartCircleBusy;
	public bool IsBusy;

	private void Start()
	{
		_transform = GetComponent<Transform>();
		if (CircleBusy != null)
		{
			CircleBusy.OnActiveToCellAction += DellCircle;
			StartCircleBusy = CircleBusy;
			CircleBusy.transform.position = transform.position;
			CircleBusy.SetStartPosition();
		}
	}
	public void DellCircle()
	{
		CircleBusy = null;
		IsBusy = false;
	}
	public void Restart()
	{
		if (StartCircleBusy != null)
		{
			CircleBusy = StartCircleBusy;
			CircleBusy.transform.position = CircleBusy.StartPosition;
			IsBusy = true;
		}
		else
		{
			CircleBusy = null;
			IsBusy = false;

		}
	}
}
