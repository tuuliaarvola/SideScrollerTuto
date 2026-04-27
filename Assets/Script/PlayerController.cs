using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    //float is for desimile numbers
    public float jumpForce = 10;
    public float gravityModifier;
    //bool is a variable which is either true or false
    public bool isOnGround = true;
    public bool gameOver;
    public GameObject gameOverScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //for character movement, rigidbody not automatic like transform
        playerRb = GetComponent<Rigidbody>();
        //character animation
        playerAnim = GetComponent<Animator>();
        //for sfx
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {   //input for spacebar
        //&& = and
        //!= = if not
        //!gameOver = not game over
        //space for jump if player is on the ground and game is not over
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround= false;
            //jump animation
            playerAnim.SetTrigger("Jump_trig");
            //stops dirt effect
            dirtParticle.Stop();
            //sfx for jumping
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        //game over if player hits the obstacle
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            //these happen if game is over:
            //log text
            Debug.Log("Game Over");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            //particle effect
            explosionParticle.Play();
            //dirt effect stops
            dirtParticle.Stop();
            //crashing sfx
            playerAudio.PlayOneShot(crashSound, 1.0f);
            //brings game over screen up
            gameOverScreen.gameObject.SetActive(true);
        }
    }
}
