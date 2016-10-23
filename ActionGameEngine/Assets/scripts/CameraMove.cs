using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public float speed = 10.0f;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float h_translation = Input.GetAxis( "Horizontal" ) * speed * Time.deltaTime;
        float v_translation = Input.GetAxis( "Vertical" ) * speed * Time.deltaTime;
        transform.Translate( h_translation, v_translation, 0 );
	}
}
