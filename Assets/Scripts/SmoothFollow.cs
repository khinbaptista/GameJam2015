using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
    public Vector2 MaxXAndY;        // The maximum x and y coordinates the camera can have.
    public Vector2 MinXAndY;        // The minimum x and y coordinates the camera can have.

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

	    Vector3 smoothedPosition;
        if (_target.GetComponent<Rigidbody2D>().velocity.x > 0 )
		{
            smoothedPosition = Vector3.SmoothDamp( _transform.position, newPosition, ref _smoothDampVelocity, SmoothDampTime );
		}
		else
		{
			var leftOffset = CameraOffset;
			leftOffset.x *= -1;
            smoothedPosition = Vector3.SmoothDamp( _transform.position, newPosition, ref _smoothDampVelocity, SmoothDampTime );
		}

        smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, MinXAndY.x, MaxXAndY.x);
        smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, MinXAndY.y, MaxXAndY.y);

        _transform.position = smoothedPosition;
	}
	
}
