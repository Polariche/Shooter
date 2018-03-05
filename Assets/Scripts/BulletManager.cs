using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BulletManager : MonoBehaviour
{
	public Queue<Bullet> inactiveBullets = new Queue<Bullet>();
	public bool destroy = false;

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.zero;

		if (destroy) {
			DestroyBullets();
			destroy = false;
		}
	}

	public void Create(Spawner spawner) {
		Create(spawner, 0);
	}

	private void DestroyBullets() {
		GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
		foreach (GameObject bullet in bullets) {
			Destroy(bullet);
		}
		inactiveBullets.Clear();
	}
	
	public void Create(Spawner spawner, float timeOffset) {
		GameObject o;
		Bullet bulletComponent;

		if (inactiveBullets.Count > 0)
		{
			o = inactiveBullets.Dequeue().gameObject;
			bulletComponent = o.GetComponent<Bullet>();
			bulletComponent.active = true;
		}
		else
		{
			o = new GameObject("Bullet");
			o.tag = "Bullet";
			o.transform.parent = this.transform;
			bulletComponent = o.AddComponent<Bullet>();
		}

		o.transform.position = spawner.transform.position;
		o.transform.rotation = spawner.transform.rotation;
		bulletComponent.Copy(spawner);
		bulletComponent.time = timeOffset;
	}
}
