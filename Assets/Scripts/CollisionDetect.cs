using TMPro;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int collisionCounter;
    private BallMovement ballMovement;
    private Rigidbody rb;

    [SerializeField] private float velocityThreshold = 0.01f;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private GameObject loseText;
    

    void Start()
    {
        ballMovement = GetComponent<BallMovement>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!ballMovement.allowInput)
        {
            if (rb.linearVelocity.sqrMagnitude < velocityThreshold &&
            rb.angularVelocity.sqrMagnitude < velocityThreshold)
            {
                gameOver();
            }
        }
    }

    void gameOver()
    {
        gameOverPanel.SetActive(true);
        if (collisionCounter >= 1)
        {
            winText.gameObject.SetActive(true);
            winText.text = "You Win with " + collisionCounter + " collisions!";
            loseText.SetActive(false);
        }
        else
        {
            winText.gameObject.SetActive(false);
            loseText.SetActive(true);
        }
    }

    public void restart()
    {
        transform.position = ballMovement.initialPosition;
        ballMovement.allowInput = true;
        collisionCounter = 0;
        gameOverPanel.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (ballMovement.allowInput)
            {
                ballMovement.allowInput = false;
            }
            collisionCounter += 1;
        }
    }
}
