using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraConfiner : MonoBehaviour
{
    [SerializeField] CinemachineConfiner confiner;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBounds();
    }

    public void UpdateBounds()
    {
        Collider2D bounds = GameObject.Find("CameraConfiner").GetComponent<Collider2D>();
        confiner.m_BoundingShape2D= bounds;
    }
  
}
