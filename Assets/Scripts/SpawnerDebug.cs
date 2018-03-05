using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpawnerDebug : MonoBehaviour {

	private Spawner spawner;
	
	void Awake() {
		spawner = GetComponent<Spawner>();
	}
	// Update is called once per frame
	void Update () {
		spawner.speedCurve.keys[0].value = spawner.initialSpeed;
		Debug.Log(spawner.speedCurve.keys[0].value);

		Debug.DrawRay(transform.position, transform.up, Color.green);
	}
}
