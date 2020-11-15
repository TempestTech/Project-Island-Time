using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    //public Items item;
    public GameObject player;
    public float interactRange;
    public float pushPower = 2.0f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.transform.position - transform.position;
        if (distanceToPlayer.magnitude <= interactRange && Input.GetKey(KeyCode.E))
            pushObj();
    }

    private void pushObj()
    {
        Vector3 pushDirection;
        // only move in 1 direction
        if (Mathf.Abs(player.transform.forward.x) >= Mathf.Abs(player.transform.forward.z))
            pushDirection = new Vector3(player.transform.forward.x * pushPower, 0, 0);
        else
            pushDirection = new Vector3(0, 0, player.transform.forward.z * pushPower);
        rb.MovePosition(transform.position + pushDirection * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
