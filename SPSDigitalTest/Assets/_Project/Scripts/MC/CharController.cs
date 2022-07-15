using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField] CharacterController _MC;
    [SerializeField] float _velocity;
    Vector3 _mousePreviousPosition;
    bool firstTouch;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _mousePreviousPosition;
            delta = delta.normalized;
            if (firstTouch) firstTouch = false;
            else _MC.Move(new Vector3(delta.x * -_velocity*Time.deltaTime, -1, -2*delta.y * _velocity* Time.deltaTime));
        }
        else firstTouch = true;
        _mousePreviousPosition = Input.mousePosition;
    }


}
