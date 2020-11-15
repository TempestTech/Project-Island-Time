using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollinder : MonoBehaviour
{
    [SerializeField] public GameObject[] arrow;
    [SerializeField] public GameObject branch;
    [SerializeField] public Items axe;
    public float interactRange;
    public Transform player;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        arrow[0].SetActive(true);
    //        isInRange = true;
    //        Debug.Log("You are in interact range with " + gameObject.tag + "!!");
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        foreach (GameObject obj in arrow)
    //            obj.SetActive(false);
    //        isInRange = false;
    //        Debug.Log("You got out of interact range with " + gameObject.tag + "!!");
    //    }
    //}

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= interactRange)
        {
            arrow[0].SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
                if (Inventory.instance.Include(axe))
                    Destroy(branch);
                else
                    arrow[1].SetActive(true);
        }
        else
        {
            foreach (GameObject arr in arrow)
                arr.SetActive(false);
        }
            
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
