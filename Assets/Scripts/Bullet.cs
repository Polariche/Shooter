using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour {

	public bool active = true;
	public float time = 0;

	public AnimationCurve speedCurve = new AnimationCurve(new Keyframe(1f, 5f));
	public AnimationCurve angleCurve = new AnimationCurve(new Keyframe(0f, 0f));

	protected BulletManager bulletManager {
		get { return GameObject.FindWithTag("BulletManager").GetComponent<BulletManager>(); }
	}

	// Update is called once per frame
	void Update () {
		if (active) {
			time += Time.deltaTime;
			transform.position += transform.up * speedCurve.Evaluate(time) * Time.deltaTime;
			transform.Rotate(Vector3.forward * (angleCurve.Evaluate(time)) * Time.deltaTime);

			CheckActive();
		}
	}

	public void Copy(Bullet o) {
		//Copy properties from other bullet
		//TODO: copy 2D Collider
		GetComponent<SpriteRenderer>().sprite = o.GetComponent<SpriteRenderer>().sprite;
		this.speedCurve = o.speedCurve;
		this.angleCurve = o.angleCurve;
	}

	public void CheckActive() {
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		if (Math.Abs(transform.position.x) > 10 || Math.Abs(transform.position.y) > 6 ) {
			active = false;
			bulletManager.inactiveBullets.Enqueue(this);
		}
	}
	
}
