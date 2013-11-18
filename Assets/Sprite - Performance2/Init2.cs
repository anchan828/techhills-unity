using UnityEngine;
using System.Collections;

public class Init2 : MonoBehaviour
{
		float time;
		int count, frame, fps;
		bool init = false;
		public GameObject spaceShipDefault, spaceShipOpacity;
		private GameObject selectedSpaceShip;
		void Start ()
		{
				Application.targetFrameRate = 60;
		}

		void Update ()
		{

				if (init && Input.touchCount > 0) {
						Touch[] touches = Input.touches;

						foreach (var touch in touches) {
								TouchPhase touchPhase = touch.phase;
								switch (touchPhase) {
								case TouchPhase.Began:
								case TouchPhase.Moved:
										Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 0));
										Instantiate (selectedSpaceShip, new Vector2 (screenToWorldPoint.x, screenToWorldPoint.y), Quaternion.identity);
										count++;
										break;
								case TouchPhase.Stationary:
								case TouchPhase.Ended:
								case TouchPhase.Canceled:
								default:
										break;
								}
						}
				}

				if (1 <= time) {
						fps = frame;
						time = 0;
						frame = 0;
				}
				frame++;
				time += Time.deltaTime;
		}

		void DrawButton (string text, GameObject spaceShip)
		{
				if (GUILayout.Button (text, GUILayout.Width (128), GUILayout.Height (128))) {
						selectedSpaceShip = spaceShip;
						init = true;
				}
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
}
