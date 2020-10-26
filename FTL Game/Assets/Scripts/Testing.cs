using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class Testing : MonoBehaviour
{
	private Grid grid;

    void Start()
    {
		grid = new Grid(20, 10, 10f, Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
		//Left Mouse Button
		//if (Input.GetMouseButtonDown(0))
		//{
		//	grid.SetValue(UtilsClass.GetMouseWorldPosition(), 56);
		//}
		////Right Mouse button
		//if (Input.GetMouseButtonDown(1))
		//{
		//	Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
		//}
    }
}
