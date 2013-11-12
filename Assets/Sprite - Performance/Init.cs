using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour
{

		public GameObject spaceShipDefault, spaceShipOpacity;
		GameObject selectedSpaceShip;
		float time;
		int count, frame, fps;
		bool init = false;

		void Start ()
		{
				Application.targetFrameRate = 60;
		}

		IEnumerator Initialize ()
		{
				for (int x= -2; x <2; x++) {
						for (int y = -4; y < 4; y++) {
								Instantiate (selectedSpaceShip, new Vector2 (x, y), Quaternion.identity);
								count++;
						}
				}

				while (true) {
						yield return new WaitForSeconds (0.25f);
						Instantiate (selectedSpaceShip, new Vector2 (Random.Range (-2f, 2f), Random.Range (-5f, 5f)), Quaternion.identity);
						count++;
				}

		}

		void Update ()
		{
				if (1 <= time) {
						fps = frame;
						time = 0;
						frame = 0;
				}
				frame++;
				time += Time.deltaTime;
		}

		void OnGUI ()
		{
				GUI.skin.box.richText = true;
				if (!init) {
						DrawButton ("SpriteDefault", spaceShipDefault);
						DrawButton ("SpriteOpacity", spaceShipOpacity);
				} else {
						GUILayout.Box ("<size=30>" + fps + " fps</size>");
						GUILayout.Box ("<size=30>" + count.ToString () + "</size>");
				}
		}

		void DrawButton (string text, GameObject spaceShip)
		{
				if (GUILayout.Button (text, GUILayout.Width (128), GUILayout.Height (128))) {
						selectedSpaceShip = spaceShip;
						init = true;
						StartCoroutine (Initialize ());
				}
		}

}
