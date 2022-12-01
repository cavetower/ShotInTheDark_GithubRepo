using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControllerType
{
	
	public static bool isUsingKeyboard {get; private set;}
	
	
	
	public static void SetControllerTypeToKeyboard(bool isKeyboard)
	{
		isUsingKeyboard = isKeyboard;
	}
	

}
