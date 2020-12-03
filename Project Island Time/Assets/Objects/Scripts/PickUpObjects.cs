using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpObjects : MonoBehaviour
{
    public Items item;
    public Transform player;

    public float pickUpRange;
    public HUD hud;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= pickUpRange)
        {
            hud.OpenMessagePanel("Hmm, what's this?...", gameObject);
            if (Input.GetKeyDown(KeyCode.E))
                pickUp();
        }
        else
            hud.CloseMessagePanel(gameObject);
    }

    private void pickUp()
    {
        Debug.Log("You are picked up " + item.itemName);
        Inventory.instance.Add(item);
        Destroy(gameObject);
        hud.CloseMessagePanel(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickUpRange);
    }
}
