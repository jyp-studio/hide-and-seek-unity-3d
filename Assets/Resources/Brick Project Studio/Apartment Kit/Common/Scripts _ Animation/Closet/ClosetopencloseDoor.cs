using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class ClosetopencloseDoor : MonoBehaviour
	{

		public Animator Closetopenandclose;
		public bool open;
		public Transform Player;

		void Start()
		{
			open = false;
		}

		void OnMouseOver()
		{
			if (Player)
			{
				if (open == false)
				{
					if (Input.GetKeyDown(KeyCode.F))
					{
						StartCoroutine(opening());
					}
				}
				else
				{
					if (open == true)
					{
						if (Input.GetKeyDown(KeyCode.F))
						{
							StartCoroutine(closing());
						}
					}
				}
			}
		}

		IEnumerator opening()
		{
			print("you are opening the door");
			Closetopenandclose.Play("ClosetOpening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			Closetopenandclose.Play("ClosetClosing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}