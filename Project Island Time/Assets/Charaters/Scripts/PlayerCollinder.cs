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
    public GameObject player;
    public HUD hud;
    private Animator animator;

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
        animator = player.GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 distanceToPlayer = player.transform.position - transform.position;
        if (distanceToPlayer.magnitude <= interactRange && branch.activeSelf)
        {
            arrow[0].SetActive(true);
            hud.OpenMessagePanel("If only I had something to cut this with...", gameObject);
            if (Input.GetKeyDown(KeyCode.E))
                if (Inventory.instance.Include(axe))
                {
                    StartCoroutine(axeCutting());
                }
        }
        else
        {
            foreach (GameObject arr in arrow)
                arr.SetActive(false);
            hud.CloseMessagePanel(gameObject);
        }
            
    }

    private IEnumerator axeCutting()
    {
        Debug.Log("It's not waiting" +  Time.time);
        animator.SetBool("Cutting", true);
        yield return new WaitForSecondsRealtime(1.75f);
        branch.SetActive(false);
        hud.CloseMessagePanel(gameObject);
        yield return new WaitForSecondsRealtime(1f);
        animator.SetBool("Cutting", false);
        Destroy(gameObject);
        Debug.Log("It did wait" +  Time.time);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
