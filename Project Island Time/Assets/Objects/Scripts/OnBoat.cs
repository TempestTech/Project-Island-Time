using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnBoat : MonoBehaviour
{
    [SerializeField] public Items[] requireList;
    [SerializeField] public GameObject arrow;
    public float interactRange;
    public GameObject player;
    public HUD hud;

    public Image black;
    public Animator animator;
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
            arrow.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Inventory.instance.Include(requireList[0]) && Inventory.instance.Include(requireList[1]) && Inventory.instance.Include(requireList[2]))
                {
                    StartCoroutine(EndGame());
                }
                else
                {
                    hud.OpenMessagePanel("How will I know where to go?", gameObject);
                }
            }
        }
        else
        {
            arrow.SetActive(false);
            hud.CloseMessagePanel(gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }

    IEnumerator EndGame()
    {
        hud.OpenMessagePanel("Looks like I'm going home...", gameObject);
        yield return new WaitForSecondsRealtime(2.0f);
        animator.SetBool("FadeOut", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
