using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPosition;
    public float speed;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float clampX = Mathf.Clamp(playerPosition.transform.position.x, minX, maxX);
        float clampY = Mathf.Clamp(playerPosition.transform.position.y, minY, maxY);

        Vector2 playerClampedPos = new Vector2(clampX, clampY);

        if (playerPosition != null)
        {
            transform.position = Vector2.Lerp(transform.position, playerClampedPos, speed);
        }
       
    }
}
