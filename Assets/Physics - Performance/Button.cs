using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
		public GameObject _2D, _3D;

		void OnGUI ()
		{
				_Button ("2D", _2D);
				_Button ("3D", _3D);
		}

		void _Button (string d, GameObject g)
		{
				if (GUILayout.Button (d, GUILayout.Width (128), GUILayout.Height (128))) {
						g.SetActive (true);
						gameObject.SetActive (false);
				}
		}
}
