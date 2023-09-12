using UnityEngine;
using System.Collections;

public class ParallaxScript : MonoBehaviour
{
	private float lenght, startpos;
	public GameObject cam;
	public float parallaxEffect;
	[SerializeField]
	float smooth;

	void Awake()
	{
		startpos = transform.position.x;
		lenght = GetComponent<SpriteRenderer>().bounds.size.x;
		cam = Camera.main.gameObject;
	}

	void FixedUpdate()
	{
		float temp = (cam.transform.position.x * (1 - parallaxEffect));
		float dist = (cam.transform.position.x * (parallaxEffect));

		//transform.position = Vector3.Lerp(transform.position,new Vector3(startpos + dist, transform.position.y, transform.position.z),smooth * Time.deltaTime);
		transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
		if (temp > startpos + lenght) startpos += lenght;
		else if (temp < startpos - lenght) startpos -= lenght;
	}
}
