using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour {

    [SerializeField]
    GameObject m_objectToInstantiate;

    [SerializeField]
    Vector2 m_cameraOffset = new Vector2(0.0005f,0.001f);

    public void InstantiateWithCamera(int numberToInstantiate)
    {
        Camera.main.cullingMask = 0;

        float width = 1;
        if (numberToInstantiate > 2)
            width = 0.5f - m_cameraOffset.x;

        float height = 1;
        if (numberToInstantiate > 1)
            height = 0.5f - m_cameraOffset.y;

        for(uint i = 0; i < numberToInstantiate; ++i)
        {
            GameObject go = GameObject.Instantiate(m_objectToInstantiate);
            Camera cam = go.GetComponentInChildren<Camera>();
            if(!cam)
            {
                GameObject obj = new GameObject("Camera");
                cam = obj.AddComponent<Camera>();
                obj.transform.parent = go.transform;
            }

            cam.rect = new Rect(i > 1 ? width + m_cameraOffset.x * 2 : 0, i % 2 * (height + m_cameraOffset.y * 2), width, height);
        }
    }

    public void Instantiate(int numberToInstantiate)
    {
        for (uint i = 0; i < numberToInstantiate; ++i)
        {
            GameObject go = GameObject.Instantiate(m_objectToInstantiate);
        }
    }
}
