using UnityEngine;
using System.Collections;
using System.Linq;

public class Emitter : MonoBehaviour
{

		public GameObject g;
		public bool isMain;
		public int count;
		public Emitter mainEmitter;
		float time;
		int frame, fps;

		IEnumerator Start ()
		{

				mainEmitter = FindObjectsOfType<Emitter> ().First (e => e.isMain);
				while (true) {
						GameObject _g = (GameObject)Instantiate (g, transform.position, Quaternion.identity);
						_g.transform.parent = transform;
						mainEmitter.count++;
						yield return new WaitForSeconds (0.3f);
				}
		}

		void Update ()
		{
				

				if (isMain) {
						if (1 <= time) {
								fps = frame;

								time = 0;
								frame = 0;
								if (fps <= 20) {
										StopAllCoroutines ();
										Time.timeScale = 0;
										Debug.Break ();
								}			
						}
						
						frame++;
						time += Time.deltaTime;
				}

			
		}
    
		void OnGUI ()
		{
				if (isMain) {
						GUILayout.Label (count.ToString ());
						GUILayout.Label (fps + " FPS");
				}
		}

	
}
