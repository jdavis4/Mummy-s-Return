using UnityEngine;
using System.Collections;

	public class InSpace : MonoBehaviour {

		public bool isTrigged = false;
		public int order;



		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.CompareTag("Space"+order))
			{
				isTrigged = true;
			}
		}

		void OnTriggerExit2D(Collider2D other)
		{
			if (other.gameObject.CompareTag("Space" + order))
			{
				isTrigged = false;
			}
		}
	}

