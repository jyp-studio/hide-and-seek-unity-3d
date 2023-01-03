﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class OvenFlip: MonoBehaviour
	{

		public Animator openandcloseoven;
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
			print("you are opening the Window");
			openandcloseoven.Play("OpenOven");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the Window");
			openandcloseoven.Play("ClosingOven");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}