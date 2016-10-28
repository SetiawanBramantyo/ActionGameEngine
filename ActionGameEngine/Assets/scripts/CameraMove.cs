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
        float x_translation = h_translation;
        float z_translation = v_translation/2;
        float y_translation = v_translation/2;
        transform.Translate( new Vector3( x_translation, y_translation, z_translation ) );
	}
}
