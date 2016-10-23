using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour
{
    private bool _isMoving;
    private float _startAngle;
    private float _targetAngle;
    private float _rotateAngle;
    private float _nextAngle;
    private float _t;
    private Vector3 _targetPos;

    void Start()
    {
        _isMoving = false;
        _startAngle = transform.eulerAngles.y;
        _targetAngle = 0;
        _rotateAngle = 0;
        _nextAngle = 0;
        _t = 0;
    }
	
    // Update is called once per frame
    void Update()
    {
        if ( !_isMoving )
        {
            if (Input.GetButtonDown("CameraRotate"))
            {
                Camera camera = GetComponent<Camera>();
                Vector3 cameraCenter = camera.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, camera.nearClipPlane));
                Vector3 fwd = transform.TransformDirection(Vector3.forward);
                Vector3 targetLocalPoint = new Vector3();
                RaycastHit info;
                if (Physics.Raycast( cameraCenter, fwd, out info ))
                    targetLocalPoint.z = info.distance;
            
                _targetPos = transform.TransformPoint( targetLocalPoint );
                _startAngle = transform.eulerAngles.y;
                _rotateAngle = ( 90f * Input.GetAxis("CameraRotate") );
                _targetAngle = ClampAngle( _startAngle + _rotateAngle );
                _nextAngle = 0;
                _t = 0;
                _isMoving = true;
            }
        }
        else
        {
            _t += Time.deltaTime * 1f;
            _nextAngle = Mathf.Lerp( _startAngle, _startAngle + _rotateAngle, _t );
            //Debug.Log( string.Format( "target={0},cur={1},dist={3},rot={4},next={2}", _targetAngle, transform.eulerAngles.y, _nextAngle, (transform.eulerAngles.y - _startAngle), _rotateAngle ) );

            float angleDiff = _nextAngle - transform.eulerAngles.y;
            transform.RotateAround(_targetPos, Vector3.up, angleDiff);

            if ( _t >= 1
                || Mathf.Abs( Mathf.DeltaAngle( _startAngle, transform.eulerAngles.y ) ) >= Mathf.Abs( _rotateAngle ) )
            {
                angleDiff = _targetAngle - transform.eulerAngles.y;
                transform.RotateAround(_targetPos, Vector3.up, angleDiff);
                _isMoving = false;
            }
        }

    }

    float ClampAngle(float angle)
    {
        angle %= 360;
        if(angle > 360) angle -= 360;
        if(angle < 0) angle += 360;
        return angle;
    }
}
