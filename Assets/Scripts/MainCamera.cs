using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private GameObject[] heroes;
    private CinemachineVirtualCamera virtualCamera;
    private float distanceFromFirstToSecond;
    private GameObject followObject;
    private Vector2 pos1;
    private Vector2 pos2;
    private float size;
    [SerializeField]
    private float maxRangeBetweenHeroes;
    [SerializeField]
    private float maxSizeCamera;

    void Start()
    {
        followObject = new GameObject();
        heroes = GameObject.FindGameObjectsWithTag("hero");
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = followObject.transform;
    }

    void Update()
    {
        FollowPosition();
        FollowSize();
    }

    private void FollowPosition()
    {
        pos1 = heroes[0].transform.position;
        pos2 = heroes[1].transform.position;
        distanceFromFirstToSecond = (pos1 - pos2).magnitude / 2;
        followObject.transform.position = Vector3.Lerp(pos1, pos2, distanceFromFirstToSecond / Vector3.Distance(pos1, pos2));
    }

    private void FollowSize()
    {
        size = 5 + Vector3.Distance(pos1, pos2)/maxRangeBetweenHeroes*maxSizeCamera;
        virtualCamera.m_Lens.OrthographicSize = size;
    }
}
