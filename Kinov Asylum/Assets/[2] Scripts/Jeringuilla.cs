using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jeringuilla : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprRenderer;
    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    private BoxCollider2D door;
    private Transform pos;
    public GameObject lightJeringuilla;

    public static bool canWin;

    public AudioClip jeringuillaClip;

    void Start()
    {
        pos = GetComponent<Transform>();
        door = GameObject.Find("FinalDoor").GetComponent<BoxCollider2D>();

        sprRenderer.enabled = false;
        coll.enabled = false;
        anim.enabled = false;
        lightJeringuilla.SetActive(false);

        canWin = false;
        StartCoroutine(Appearance());
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //SceneManager.LoadScene("03_Victory");
            PlayerController.health = 100f;
            canWin = true;
            door.isTrigger = true;
            Destroy(gameObject);
        }
    }

    private IEnumerator Appearance()
    {
        yield return new WaitForSeconds(30);
        sprRenderer.enabled = true;
        coll.enabled = true;
        anim.enabled = true;
        lightJeringuilla.SetActive(true);
    }
}
