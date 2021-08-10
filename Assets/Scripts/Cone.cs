using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour
{
	[SerializeField] private List<Cell> _cells = new List<Cell>();
	public bool isReady = false;
}
