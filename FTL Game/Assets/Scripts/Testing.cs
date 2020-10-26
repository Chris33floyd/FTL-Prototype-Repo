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
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 position = UtilsClass.GetMouseWorldPosition();
			int value = grid.GetValue(position);
			grid.SetValue(position, value + 5);
		}
		//Right Mouse button
		if (Input.GetMouseButtonDown(1))
		{
			
		}
	}
}
