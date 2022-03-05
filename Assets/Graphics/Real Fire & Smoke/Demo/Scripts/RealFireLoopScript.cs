using UnityEngine;
using System.Collections;

namespace RealFireSmoke
{
	public class RealFireLoopScript : MonoBehaviour
	{

		public GameObject chosenEffect;
		public float loopTimeLimit = 2.0f;

		void Start ()
		{
			PlayEffect();
		}


		public void PlayEffect()
		{
			StartCoroutine("EffectLoop");
		}
	

		IEnumerator EffectLoop()
		{
			GameObject effectPlayer = (GameObject) Instantiate(chosenEffect, transform.position, transform.rotation);

			yield return new WaitForSeconds(loopTimeLimit);

			Destroy (effectPlayer);
			PlayEffect();
		}
	}
}