using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LessIsMore.Core
{
    public class GetMouseWorldPosition : MonoBehaviour
    {
        public Vector3 GetMouseWorldPos()
        {
            Vector3 vec = GetMouserWorldPositionWithZ(Input.mousePosition, Camera.main);
            vec.z = 0f;
            return vec;
        }

        public Vector3 GetMouserWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
        {
            Vector3 worldPos = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPos;
        }
    }
}
