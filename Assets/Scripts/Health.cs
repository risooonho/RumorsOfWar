﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public Texture2D barEmpty;
	public Texture2D barFull;
	public float display;

	public Vector2 size;
	public Vector2 addedPosition;
	private Vector2 barPosition;

	private float health;
	[SerializeField] private float healthMax;

	public void Awake() {
		health = healthMax;
	}

	public void Update() {
		display = ((health * 100) / healthMax) / 100;
	}

	public void TakeDamage(GameObject damageDealer, float damage) {
		health -= damage;
		if (health <= 0) {
			health = 0;
			Die ();
		}
		if (damageDealer != null) {
			Debug.Log(gameObject.name + " was hit by " + damageDealer.name);
		}
	}

	public void HealDamage(GameObject healer, float healValue) {
		health += healValue;
		if (health > healthMax) {
			health = healthMax;
		}
		if (healer != null) {
			Debug.Log(gameObject.name + " was hit by " + healer.name);
		}
	}

	public void Die() {
		Debug.Log (gameObject.name + " is dead");
		gameObject.SetActive (false);
	}

	public void OnGUI() {
		// draw the background:
		barPosition = Camera.main.WorldToScreenPoint (transform.position);

		GUI.BeginGroup (new Rect (barPosition.x + addedPosition.x, barPosition.y + addedPosition.y, size.x, size.y));
        GUI.Box (new Rect (0,0, size.x, size.y),barEmpty);
 
	     // draw the filled-in part:
	     GUI.BeginGroup (new Rect (0, 0, size.x * display, size.y));
	         GUI.Box (new Rect (0,0, size.x, size.y),barFull);
	     GUI.EndGroup ();
	 
	     GUI.EndGroup (); 
	}
}
