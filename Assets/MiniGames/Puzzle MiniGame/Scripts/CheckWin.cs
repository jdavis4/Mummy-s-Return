using UnityEngine;
using System.Collections;

public class CheckWin : MonoBehaviour {


	[HideInInspector] public InSpace[] space;
	private bool win = false;
	[HideInInspector] public int nextlevel;
	[HideInInspector] public bool incorrect = false;
	[HideInInspector] public GUISkin skin;
	public string nextScene = "TestScene";


		void Start()
		{
			space = FindObjectsOfType<InSpace>();
		}


		void OnGUI()
		{
			if (!win)
			{
				if (GUI.Button(new Rect(Screen.width / 2 - 100, 0, 200, 100), "Check Puzzle"))
				{
					bool temp = true;
					for (int i = 0; i < space.Length; i++)
					{
						if (space[i].isTrigged == false)
						{
							temp = false;
						}

					}
					if (temp == true)
					{
						win = true;
						//GameObject.FindGameObjectWithTag("WinSound").GetComponent<AudioSource>().enabled = true;
					}
					else
					{
						incorrect = true;

					}

				}
				if (incorrect)
				{
					//GameObject.FindGameObjectWithTag("IncorrectSound").GetComponent<AudioSource>().enabled = true;
					GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 300, 200), "<size=50>Try Again</size>", skin.label);
					StartCoroutine(WaitSec());
				}
			}
			if (win)
			{
				GUI.Label(new Rect(Screen.width / 2 - 100, 0, 200, 100), "<size=50>Correct!</size>");


				if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "<size=25>Next Task</size>"))
				{
					Application.LoadLevel(nextScene);
				}
			}
		}

		IEnumerator WaitSec()
		{
			yield return new WaitForSeconds(1);
			incorrect = false;
			//GameObject.FindGameObjectWithTag("IncorrectSound").GetComponent<AudioSource>().enabled = false;
		}
	}


