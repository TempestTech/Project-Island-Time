using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoat : MonoBehaviour
{
    [SerializeField] public Items[] requireList;
    public float interactRange;
    public GameObject player;
    public HUD hud;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.transform.position - transform.position;
        if (distanceToPlayer.magnitude <= interactRange)
        {
            if (Inventory.instance.Include(requireList[0]) && Inventory.instance.Include(requireList[1]) && Inventory.instance.Include(requireList[2]))
            {
                hud.OpenMessagePanel("Looks like I'm going home...", gameObject);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    
                }
            }
            else
            {
                hud.OpenMessagePanel("How will I know where to go?", gameObject);
            }
        }
        else
        {
            hud.CloseMessagePanel(gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
