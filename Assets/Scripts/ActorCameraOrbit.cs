using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorCameraOrbit : MonoBehaviour
{
    public int HorizontalOffset = 1;

    public int VerticalOffset = -1;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles += new Vector3(
                Input.GetAxis("Mouse Y") * VerticalOffset,
                Input.GetAxis("Mouse X") * HorizontalOffset,
                0f);
        }
    }
}
