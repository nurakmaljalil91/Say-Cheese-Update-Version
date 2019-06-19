using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeWaypoint : MonoBehaviour
{
    [SerializeField]
    private RawImage HomeWaypointIndicator;
    [SerializeField]
    private Transform HomeOnMap;
    [SerializeField]
    private GameObject Home, HomeWaypointHolder;
    [SerializeField]
    private Vector3 Offset;

    // Update is called once per frame
    void Update()
    {
        HomeWaypointHolder.SetActive(true);

        // To stick waypoint in screen
        float minX = HomeWaypointIndicator.GetPixelAdjustedRect().width / 3.5f;
        float maxX = Screen.width - minX;

        float minY = HomeWaypointIndicator.GetPixelAdjustedRect().height / 3.5f;
        float maxY = Screen.height - minY;

        // Cheese position
        Vector2 PositionHome = Camera.main.WorldToScreenPoint(HomeOnMap.position + Offset);

        PositionHome.x = Mathf.Clamp(PositionHome.x, minX, maxX);
        PositionHome.y = Mathf.Clamp(PositionHome.y, minY, maxY);

        HomeWaypointIndicator.transform.position = PositionHome;
    }
}
