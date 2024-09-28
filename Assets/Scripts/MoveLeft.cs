using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : GameManager
{
    private readonly float speed = 30;
    private readonly float leftBound = -15;

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver()) return;
        transform.Translate(speed * Time.deltaTime * Vector3.left);

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
