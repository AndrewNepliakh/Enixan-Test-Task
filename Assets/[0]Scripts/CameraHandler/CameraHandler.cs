using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraHandler : MonoBehaviour
{
    private Camera _camera;
    private readonly Vector3 _startCameraPosition = new Vector3(10.0f, 35.0f, -8.0f);
    
    private float _zoomModifierSpeed = 0.05f;
    private float _yMin = 5.0f;
    private float _yMax = 35.0f;

    public TextMeshProUGUI _text1; 
    public TextMeshProUGUI _text2; 
    public TextMeshProUGUI _text3; 
    public TextMeshProUGUI _text4; 

    private void Start()
    {
        _camera = Camera.main;
        if (_camera != null) _camera.transform.position = _startCameraPosition;
    }

    private void Update()
    {
#if UNITY_EDITOR
        MouseMovementCamera();
#endif
        
#if UNITY_ANDROID && !UNITY_EDITOR
        TouchMovementCamera();
#endif
    }

    private void MouseMovementCamera()
    {
        float deltaX;
        float deltaZ;
        float axisY = Input.mouseScrollDelta.y;

        if (Input.GetMouseButton(0))
        {
            deltaX = Input.GetAxis("Mouse X");
            deltaZ = Input.GetAxis("Mouse Y");
            _camera.transform.position += new Vector3(-deltaX, axisY, -deltaZ);
            var pos = _camera.transform.position;

            SetClampCoordinates(axisY);
        }
        else
        {
            SetClampCoordinates(axisY);
        }
    }
    
    private void SetClampCoordinates(float axisY)
    {
        var pos = _camera.transform.position;
        _camera.transform.position =
            new Vector3(Mathf.Clamp(pos.x, -0.8f, 21.0f),
                Mathf.Clamp(pos.y + axisY, _yMin, _yMax),
                Mathf.Clamp(pos.z, -8.0f, 21.0f));
    }

    private void TouchMovementCamera()
    {
        _text4.text = "Touch count: " + Input.touchCount;

        if (Input.touchCount == 1)
        {
            var firstTouch = Input.GetTouch(0);
            
            var deltaX = -firstTouch.deltaPosition.x / 2.0f * Time.deltaTime;
            var deltaZ = -firstTouch.deltaPosition.y / 2.0f * Time.deltaTime;
            var pos = _camera.transform.position;
            _camera.transform.position += new Vector3(deltaX, 0.0f, deltaZ);
            
            _text1.text = "Camera position: " + _camera.transform.position;
            _text2.text = "Delta X: " + deltaX;
            _text3.text = "Delta Y: " + deltaZ;
            
            SetClampCoordinates(0.0f);
        }
        
        if (Input.touchCount == 2)
        {
            var firstTouch = Input.GetTouch(0);
            var secondTouch = Input.GetTouch(1);
            
            var firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
            var secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;
        
            var touchesPrevPosDifference = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
            var touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;
            
            var zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * _zoomModifierSpeed;
            
            if (touchesPrevPosDifference > touchesCurPosDifference)
            {
                var Ypos = _camera.transform.localPosition.y;
                Ypos += zoomModifier;
                var pos = _camera.transform.position;
                _camera.transform.localPosition = new Vector3(pos.x, Mathf.Clamp(Ypos, _yMin, _yMax), pos.z);
            }
            
            if (touchesPrevPosDifference < touchesCurPosDifference)
            {
                var Ypos = _camera.transform.localPosition.y;
                Ypos -= zoomModifier;
                var pos = _camera.transform.position;
                _camera.transform.localPosition = new Vector3(pos.x, Mathf.Clamp(Ypos, _yMin, _yMax), pos.z);
            }
        }
    }
}