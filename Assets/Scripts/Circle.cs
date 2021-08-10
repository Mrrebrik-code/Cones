using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
	private Transform _transform;
	[SerializeField] private int _id;
	public bool isOut = false;
	public int Id{ get{ return _id; } }

	private void Start()
	{
		_transform = GetComponent<Transform>();
	}
	public void SetPosition(Vector3 position)
	{
		_transform.position = position;
	}
}
