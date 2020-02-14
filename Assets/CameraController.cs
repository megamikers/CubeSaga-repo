using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Vector3 offset;
	public Transform target;

	private float currentZoom = 10f;
	private float currentSpin = 0f;

	public float zoomInSpeed = 3f;
	public float spinSpeed = 75f;
	public float minZoom = 6.5f;
	public float maxZoom = 15f;
	public float pitch = 2f;

	void Update () 
	{
		currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomInSpeed; // zoom in and out with the scroll wheel
		currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

		currentSpin -= Input.GetAxis("Horizontal") * spinSpeed * Time.deltaTime;
	}

    void LateUpdate()
    {
		transform.position = target.position - offset * currentZoom; //Set camera position
		transform.LookAt(target.position + Vector3.up * pitch);
		transform.RotateAround(target.position, Vector3.up, currentSpin);
    }
}
