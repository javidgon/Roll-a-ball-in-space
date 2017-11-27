using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is also run every frame, but it's guaranteed to be run after all items
	// have been processed and update
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
