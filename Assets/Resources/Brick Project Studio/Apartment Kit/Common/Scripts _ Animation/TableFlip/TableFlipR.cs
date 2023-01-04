using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFlipR: MonoBehaviour {

	public Animator FlipR;
	public bool open;
	public Transform Player;

	void Start (){
		open = false;
	}

	void OnMouseOver (){
		{
			if (Player)
            {
				if (open == false) {
					if (Input.GetKeyDown(KeyCode.F)) {
						StartCoroutine (opening ());
					}
				} else {
					if (open == true) {
						if (Input.GetKeyDown(KeyCode.F)) {
							StartCoroutine (closing ());
						}
					}
                }
			}
		}
	}

	IEnumerator opening(){
		print ("you are opening the door");
        FlipR.Play ("Rup");
		open = true;
		yield return new WaitForSeconds (.5f);
	}

	IEnumerator closing(){
		print ("you are closing the door");
        FlipR.Play ("Rdown");
		open = false;
		yield return new WaitForSeconds (.5f);
	}


}

