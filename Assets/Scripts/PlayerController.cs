using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;

    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip crashSound;
    public AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) return;
        JumpHandler();
    }

    private void JumpHandler()
    {
        if (!Input.GetKeyDown(KeyCode.Space) || !isOnGround) return;
        dirtParticle.Stop();
        playerAudio.PlayOneShot(jumpSound, 1f);
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
        playerAnim.SetTrigger("Jump_trig");
    }

    private void OnCollisionEnter(Collision collision)
    {
        dirtParticle.Play();

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1f);
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            Debug.Log("Game over!");
        }

        isOnGround = true;

        if (gameOver)
        {
            dirtParticle.Stop();
        }
    }
}
