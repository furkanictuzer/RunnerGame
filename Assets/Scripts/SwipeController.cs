using System;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [SerializeField] private float xClamp;
    
    private float _firstValue;
    private float _currentValue;

    private float _lastSumValue;
    private float _screenWidth;

    private bool _touchable = true;

    private const float Sensitivity = 10f;
    private float _sumValue;

    private void Awake()
    {
        LevelManager.Instance.AddMethodFinish(DisableSwipe);
        LevelManager.Instance.AddMethodFail(DisableSwipe);
    }

    private void Start()
    {
        _screenWidth = Screen.width;
    }

    private void Update()
    {
        if (!_touchable) return;

        Move(GetTouchedPos());

    }

    private float GetTouchedPos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _firstValue = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _currentValue = Input.mousePosition.x;

            _sumValue = _currentValue - _firstValue;
            
            _sumValue /= _screenWidth;

            _sumValue *= Sensitivity;
            _sumValue += _lastSumValue;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _lastSumValue = _sumValue;
        }

        return _sumValue;
    }

    private void Move(float value)
    {
        var pos = transform.position;
        
        pos = Vector3.Lerp(
            pos, 
            new Vector3(value, pos.y, pos.z),
            10f * Time.deltaTime);

        pos.x = Mathf.Clamp(pos.x, -xClamp, xClamp);

        transform.position = pos;
    }

    private void DisableSwipe()
    {
        _touchable = false;
    }

}