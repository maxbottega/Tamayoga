using UnityEngine;
using UnityEditor;
using System.Collections;

public class ES2ClearPlayerPrefsInspector : Editor
{
	[MenuItem ("Easy Save/Clear PlayerPrefs")]
    private static void ClearPlayerPrefs() 
    {
    	PlayerPrefs.DeleteAll();
    }
}