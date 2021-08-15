using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour
{
	public List<Cell> Cells = new List<Cell>();
	public bool isReady = false;
	public Transform OutPositionToCone;
	public Circle CircleOut;

	private void OnMouseDown()
	{
		GameHandler.Instance.SelectedCone(this);
		var check = false;
		foreach (var cellCheck in Cells)
		{
			if (cellCheck.CircleBusy != null || GameHandler.Instance.SelectedCones.Count == 2)
			{
				if (!CheckFill())
				{
					check = true;
				}
				else
				{
					GameHandler.Instance.SelectedCones[0].Cells.Reverse();
					foreach (var cell in GameHandler.Instance.SelectedCones[0].Cells)
					{
						if (!cell.IsBusy && GameHandler.Instance.SelectedCones[0].CircleOut)
						{
							cell.CircleBusy = GameHandler.Instance.SelectedCones[0].CircleOut;
							cell.CircleBusy.isOut = false;
							cell.CircleBusy.SetPosition(cell.Transform.position);
							cell.IsBusy = true;
							GameHandler.Instance.SelectedCones[0].CircleOut = null;

							break;
						}
					}
					GameHandler.Instance.SelectedCones[0].Cells.Reverse();
				}
				break;
			}
			else
			{
				check = false;
			}
		}
		if (!check)
		{
			GameHandler.Instance.SelectedCones = new List<Cone>();
			return;
		}




		if (GameHandler.Instance.SelectedCones.Count < 2)
		{
			InAndOutCircleFromCell();
		}
		else if(GameHandler.Instance.SelectedCones[0] == GameHandler.Instance.SelectedCones[1])
		{
			InAndOutCircleFromCell();
			GameHandler.Instance.SelectedCones = new List<Cone>();
			return;
			
		}
		else if (!CheckCircle())
		{
			GameHandler.Instance.SelectedCones[0].Cells.Reverse();
			foreach (var cell in GameHandler.Instance.SelectedCones[0].Cells)
			{
				if (!cell.IsBusy && GameHandler.Instance.SelectedCones[0].CircleOut)
				{
					cell.CircleBusy = GameHandler.Instance.SelectedCones[0].CircleOut;
					cell.CircleBusy.isOut = false;
					cell.CircleBusy.SetPosition(cell.Transform.position);
					cell.IsBusy = true;
					GameHandler.Instance.SelectedCones[0].CircleOut = null;
					break;
				}
			}
			GameHandler.Instance.SelectedCones[0].Cells.Reverse();
			GameHandler.Instance.SelectedCones = new List<Cone>();
			return;
		}
		else
		{
			GameHandler.Instance.SelectedCones[1].Cells.Reverse();
			foreach (var cell in GameHandler.Instance.SelectedCones[1].Cells)
			{
				if (cell.IsBusy == false)
				{
					cell.IsBusy = true;
					cell.CircleBusy = GameHandler.Instance.SelectedCones[0].CircleOut;
					GameHandler.Instance.SelectedCones[0].CircleOut.SetPosition(cell.Transform.position);
					GameHandler.Instance.SelectedCones[0].CircleOut.isOut = false;
					GameHandler.Instance.SelectedCones[0].CircleOut = null;

					break;

				}
			}
			GameHandler.Instance.SelectedCones[1].Cells.Reverse();
			GameHandler.Instance.SelectedCones = new List<Cone>();

		}

	}

	private bool CheckCircle()
	{
		var check = false;
		Circle circleTemp = default;
		foreach (var cell in GameHandler.Instance.SelectedCones[1].Cells)
		{
			if (cell.IsBusy)
			{
				circleTemp = cell.CircleBusy;
				break;
			}
		}
		if(circleTemp != null)
		{
			if(circleTemp.Id == GameHandler.Instance.SelectedCones[0].CircleOut.Id)
			{
				check = true;
			}
		}
		else
		{
			if (!GameHandler.Instance.SelectedCones[1].Cells[Cells.Count - 1].IsBusy)
			{
				check = true;
			}
			else
			{
				check = false;
			}
			
		}

		return check;
	}
	private bool CheckFill()
	{
		bool check = true;
		if(GameHandler.Instance.SelectedCones.Count != 2)
		{
			return false;
		}
		foreach (var cellCheck in GameHandler.Instance.SelectedCones[1].Cells)
		{
			if (!cellCheck.IsBusy)
			{
				check = false;
			}
		}
		return check;
	}
	public void InAndOutCircleFromCell()
	{
		foreach (var cell in Cells)
		{
			if (cell.IsBusy && CircleOut == null )
			{
				if ( !cell.CircleBusy.isOut)
				{
					cell.CircleBusy.SetPosition(OutPositionToCone.position);
					cell.CircleBusy.isOut = true;
					cell.IsBusy = false;
					CircleOut = cell.CircleBusy;
					cell.CircleBusy = null;
					
				}
				return;
			}
		}
		Cells.Reverse();
		foreach (var cell in Cells)
		{
			if (!cell.IsBusy && CircleOut)
			{
				cell.CircleBusy = CircleOut;
				cell.CircleBusy.isOut = false;
				cell.CircleBusy.SetPosition(cell.Transform.position);
				cell.IsBusy = true;
				CircleOut = null;
				Cells.Reverse();
				return;
			}
		}
		Cells.Reverse();

	}

}
