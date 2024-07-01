using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public Rigidbody playerrb;
    public float jumpforce=8f;
   
    // public float speed = 8f;
    public float gravitymodifier;
    public bool isonground = true;
    public bool gameover = false;
    private Animator playeranim;
    public ParticleSystem explosioneffect;
    public ParticleSystem dirtparticle;
    private AudioSource playeraudio;
    public AudioClip jumpSound;
    public AudioClip CrashSound;

    // Start is called before the first frame update
    void Start()
    {
        playerrb = GetComponent<Rigidbody>();
        playeranim = GetComponent<Animator>();
        playeraudio = GetComponent<AudioSource>();
        // if we want to have more or less gravity
        Physics.gravity *= gravitymodifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isonground && !gameover)
        {
            playerrb.AddForce(Vector3.up * jumpforce, ForceMode.VelocityChange);
            isonground = false;
            playeranim.SetTrigger("Jump_trig");
            dirtparticle.Stop();
            playeraudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isonground = true;
            dirtparticle.Play();
        }
        else if (collision.gameObject.CompareTag("obstacles"))
        {
            dirtparticle.Stop();
            Debug.Log("Game over");
            gameover = true;
            playeranim.SetBool("Death_b", true);
            playeranim.SetInteger("DeathType_int", 1);
            explosioneffect.Play();
            playeraudio.PlayOneShot(CrashSound, 1.0f);
        }
    }
}

