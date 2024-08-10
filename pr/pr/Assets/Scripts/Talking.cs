using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talking : MonoBehaviour
{
    private Animator animator;
    public KeyCode Talk;
    public Text talkText;
    private AudioSource say;
    float talkRange = 7;
    Transform player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        say = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance <= talkRange)
        {
            talkText.gameObject.SetActive(true);
            animator.transform.LookAt(player);
            if (Input.GetKey(Talk))
            {
                animator.Play("Talk");
                say.Play();
            }
        }
        else
        {
            talkText.gameObject.SetActive(false);
        }
    }
}
