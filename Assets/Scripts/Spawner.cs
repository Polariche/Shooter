using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnerDebug))]
public class Spawner : Bullet {

	public enum SpawnMode {
		Simple = 0,
		Advanced = 1
	}

	public SpawnMode mode = SpawnMode.Simple;
	public AnimationCurve spawnPoint = new AnimationCurve(new Keyframe(0f, 0f));
	public float spawnTime = 0;

	public float initialSpeed;
	public float initialAngle;
	
	void Update() {
		time += Time.deltaTime;

		if (mode == 0) {
			if (time > spawnTime) {
				//TODO: spawnTime이 Time.deltaTime과 비슷할 때의 정확도 개선
				time -= spawnTime;
				bulletManager.Create(this);
			}
		} else {

		}
	}

	
}
