using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
	public int healthRestoration = 1;
	public GameObject lightingParticles;
	public GameObject burstParticles;


	private SpriteRenderer _rederer;
	private Collider2D _collider;

	private void Awake()
	{
		_rederer = GetComponent<SpriteRenderer>();
		_collider = GetComponent<Collider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player")) {
			// Cure Player 
			collision.SendMessageUpwards("AddHealth", healthRestoration);

			// Disable Collider
			//_collider.enabled = false;

			// Visual stuff
			/*_rederer.enabled = false;
			lightingParticles.SetActive(false);
			burstParticles.SetActive(true);

			// Destroy after some  time
			//Destroy(gameObject, 2f);*/

			//Respawn hearts
			StartCoroutine("RespawnHearts");
		}
	}
	private IEnumerator RespawnHearts()
	{
		if(_rederer.enabled == true){
			// Disable Collider
			_collider.enabled = false;

			// Visual stuff
			_rederer.enabled = false;
			lightingParticles.SetActive(false);
			burstParticles.SetActive(true);

		}

		yield return new WaitForSeconds(10f);
		// Disable Collider
		_collider.enabled = true;

		// Visual stuff
		_rederer.enabled = true;
	 	lightingParticles.SetActive(true);
		burstParticles.SetActive(false);
	}
}