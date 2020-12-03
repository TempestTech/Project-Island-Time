using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    //public Items item;
    [SerializeField] public GameObject indicator;
    public GameObject player;
    public float interactRange;
    public float pushPower = 2.0f;

    private Rigidbody rb;
    private Animator animator;
    private Vector3 indicatorOffset;
    private GameObject lastInRange;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = player.GetComponent<Animator>();
        indicatorOffset = indicator.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = player.transform.position - transform.position;
        if (distanceToPlayer.magnitude <= interactRange)
        {
            lastInRange = gameObject;
            indicator.SetActive(true);
            if (Input.GetKey(KeyCode.E))
                pushObj();
            //else
            if (Input.GetKeyUp(KeyCode.E))
                animator.SetBool("PushingS", false);
        }
        else
        {
            if (lastInRange == gameObject)
                indicator.SetActive(false);
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            //animator.SetBool("PushingS", false);
        }

    }

    private void pushObj()
    {
        rb.constraints = RigidbodyConstraints.None;
        if (animator.GetBool("PushingS") == false)
        {
            Debug.Log("set pushing true");
            animator.SetBool("PushingS", true);
        }
        Vector3 pushDirection;
        // only move in 1 direction
        if (Mathf.Abs(player.transform.forward.x) >= Mathf.Abs(player.transform.forward.z))
            pushDirection = new Vector3(player.transform.forward.x * pushPower, 0, 0);
        else
            pushDirection = new Vector3(0, 0, player.transform.forward.z * pushPower);
        rb.MovePosition(transform.position + pushDirection * Time.deltaTime);
        //indicator.transform.Translate(new Vector3(pushDirection.x, -pushDirection.z, 0) * pushPower * Time.deltaTime);
        //transform.Translate(pushDirection * Time.deltaTime);
        indicator.transform.position = transform.position + indicatorOffset;
    }

    private void FixedUpdate()
    {
        rb.useGravity = false;
        rb.AddForce(Physics.gravity * (rb.mass * rb.mass));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
