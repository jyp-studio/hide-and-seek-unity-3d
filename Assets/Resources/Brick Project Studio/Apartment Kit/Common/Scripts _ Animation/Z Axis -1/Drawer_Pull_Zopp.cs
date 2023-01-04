﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class Drawer_Pull_Zopp : MonoBehaviour
	{

		public Animator pull;
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
				print("object name");
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
			pull.Play("openpullopp");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			pull.Play("closepushopp");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}