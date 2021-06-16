using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isInRange;
    private MovePlayer movePlayer;
    public BoxCollider2D collider;

    // Start is called before the first frame update
    void Awake()
    {
        movePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movePlayer.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            //descendre de l'échelle
            movePlayer.isClimbing = false;
            collider.isTrigger = false;
            return;
        }
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            movePlayer.isClimbing = true;
            collider.isTrigger = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            movePlayer.isClimbing = false;
            collider.isTrigger = false;
        }
    }
}
