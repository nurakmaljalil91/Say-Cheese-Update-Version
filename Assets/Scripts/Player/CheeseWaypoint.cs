using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseWaypoint : MonoBehaviour
{
    [SerializeField]
    private RawImage CheeseWaypointIndicator, EnemyEquipped1WaypointIndicator, EnemyEquipped2WaypointIndicator, EnemyEquipped3WaypointIndicator;
    [SerializeField]
    private Transform CheeseOnMap, EnemyEquipped1Position, EnemyEquipped2Position, EnemyEquipped3Position;
    [SerializeField]
    private GameObject Cheese, EnemyEquipped1, EnemyEquipped2, EnemyEquipped3, CheeseWaypointHolder, Enemy1WaypointHolder, Enemy2WaypointHolder, Enemy3WaypointHolder;
    [SerializeField]
    private Vector3 Offset;

    void Update()
    {
        if (Cheese.activeInHierarchy == true)
        {
            CheeseWaypointHolder.SetActive(true);

            // To stick waypoint in screen
            float minX = CheeseWaypointIndicator.GetPixelAdjustedRect().width / 3.5f;
            float maxX = Screen.width - minX;

            float minY = CheeseWaypointIndicator.GetPixelAdjustedRect().height / 3.5f;
            float maxY = Screen.height - minY;

            // Cheese position
            Vector2 PositionCheese = Camera.main.WorldToScreenPoint(CheeseOnMap.position + Offset);

            PositionCheese.x = Mathf.Clamp(PositionCheese.x, minX, maxX);
            PositionCheese.y = Mathf.Clamp(PositionCheese.y, minY, maxY);

            CheeseWaypointIndicator.transform.position = PositionCheese;
        }
        else
        {
            CheeseWaypointHolder.SetActive(false);
        }

        if (EnemyEquipped1.activeInHierarchy == true)
        {
            Enemy1WaypointHolder.SetActive(true);

            // To stick waypoint in screen
            float minX = EnemyEquipped1WaypointIndicator.GetPixelAdjustedRect().width / 3.5f;
            float maxX = Screen.width - minX;

            float minY = EnemyEquipped1WaypointIndicator.GetPixelAdjustedRect().height / 3.5f;
            float maxY = Screen.height - minY;

            // Cheese position
            Vector2 PositionCheese = Camera.main.WorldToScreenPoint(EnemyEquipped1Position.position + Offset);

            PositionCheese.x = Mathf.Clamp(PositionCheese.x, minX, maxX);
            PositionCheese.y = Mathf.Clamp(PositionCheese.y, minY, maxY);

            EnemyEquipped1WaypointIndicator.transform.position = PositionCheese;
        }
        else
        {
            Enemy1WaypointHolder.SetActive(false);
        }

        if (EnemyEquipped2.activeInHierarchy == true)
        {
            Enemy2WaypointHolder.SetActive(true);

            // To stick waypoint in screen
            float minX = EnemyEquipped2WaypointIndicator.GetPixelAdjustedRect().width / 3.5f;
            float maxX = Screen.width - minX;

            float minY = EnemyEquipped2WaypointIndicator.GetPixelAdjustedRect().height / 3.5f;
            float maxY = Screen.height - minY;

            // Cheese position
            Vector2 PositionCheese = Camera.main.WorldToScreenPoint(EnemyEquipped2Position.position + Offset);

            PositionCheese.x = Mathf.Clamp(PositionCheese.x, minX, maxX);
            PositionCheese.y = Mathf.Clamp(PositionCheese.y, minY, maxY);

            EnemyEquipped2WaypointIndicator.transform.position = PositionCheese;
        }
        else
        {
            Enemy2WaypointHolder.SetActive(false);
        }

        if (EnemyEquipped3.activeInHierarchy == true)
        {
            Enemy3WaypointHolder.SetActive(true);

            // To stick waypoint in screen
            float minX = EnemyEquipped3WaypointIndicator.GetPixelAdjustedRect().width / 3.5f;
            float maxX = Screen.width - minX;

            float minY = EnemyEquipped3WaypointIndicator.GetPixelAdjustedRect().height / 3.5f;
            float maxY = Screen.height - minY;

            // Cheese position
            Vector2 PositionCheese = Camera.main.WorldToScreenPoint(EnemyEquipped3Position.position + Offset);

            PositionCheese.x = Mathf.Clamp(PositionCheese.x, minX, maxX);
            PositionCheese.y = Mathf.Clamp(PositionCheese.y, minY, maxY);

            EnemyEquipped3WaypointIndicator.transform.position = PositionCheese;
        }
        else
        {
            Enemy3WaypointHolder.SetActive(false);
        }
    }
}
