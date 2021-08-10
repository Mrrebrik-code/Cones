using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
	private Transform _transform;
	public Transform Transform { get{ return _transform; } }

	private void Start()
	{
		_transform = GetComponent<Transform>();
	}

	public Circle CircleBusy{ get; set; }
	public bool IsBusy;
}
