using UnityEngine;
using System.Collections;

public class Mecanim2D : MonoBehaviour
{


		Animator animator;
		Vector2 direction = Vector2.zero;

		bool isWalking {
				get {
						return Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0;
				}
		}

		void Start ()
		{
				animator = GetComponent<Animator> ();
		}

		void Update ()
		{

				if (Input.GetKey (KeyCode.DownArrow)) {
						direction = new Vector2 (0, -1);
				}

				if (Input.GetKey (KeyCode.UpArrow)) {
						direction = new Vector2 (0, 1);
				}

				if (Input.GetKey (KeyCode.LeftArrow)) {
						direction = new Vector2 (-1, 0);
				}

				if (Input.GetKey (KeyCode.RightArrow)) {
						direction = new Vector2 (1, 0);
				}

				animator.SetFloat ("horizontal", direction.x);	
				animator.SetFloat ("vertical", direction.y);	
				animator.SetBool ("walk", isWalking);


				if (isWalking) {
						transform.Translate (direction * Time.deltaTime);
				}

		}
}
