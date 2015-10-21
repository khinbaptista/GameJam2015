using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
	public float SmoothDampTime = 0.2f;
	[HideInInspector]
    
    public Vector3 CameraOffset;
	public bool UseFixedUpdate = false;
	
	private Transform _transform;
	private Vector3 _smoothDampVelocity;

    private Transform _target;


    void Awake()
	{
		_transform = gameObject.transform;
        _target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	
	void LateUpdate()
	{
		if( !UseFixedUpdate )
			updateCameraPosition();
	}


	void FixedUpdate()
	{
		if( UseFixedUpdate )
			updateCameraPosition();
	}


	void updateCameraPosition()
	{
        Vector3 newPosition = _target.position - CameraOffset;
        newPosition.z = transform.position.z;
        if (_target.GetComponent<Rigidbody2D>().velocity.x > 0 )
		{
            _transform.position = Vector3.SmoothDamp( _transform.position, newPosition, ref _smoothDampVelocity, SmoothDampTime );
		}
		else
		{
			var leftOffset = CameraOffset;
			leftOffset.x *= -1;
			_transform.position = Vector3.SmoothDamp( _transform.position, newPosition, ref _smoothDampVelocity, SmoothDampTime );
		}
	}
	
}
