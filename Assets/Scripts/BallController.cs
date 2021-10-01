using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField] private Text text; 
    [SerializeField] private GameObject particles;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Image panelImage;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private InputField inputField;
    
    private float speed = 0.2f;
    private Rigidbody ballRigidbody;
    public static bool gameOver;
    private int collectedCoins;
    private float maxSpeed = 2f;
    private bool updated = false;

    private void Awake()
    {
        SceneManager.sceneLoaded += Load;
    }

    private void Load(Scene scene, LoadSceneMode mode)
    {
        gameOver = false;
    }
    void Start()
    {
        collectedCoins = 0;
        text.text = collectedCoins.ToString();
        ballRigidbody = GetComponent<Rigidbody>();
        ballRigidbody.velocity = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
            return;
        
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            MoveBall();
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1))
        {
            ballRigidbody.useGravity = true;
            gameOver = true;
        }
        UpSpeed();
        SaveGame();
    }

    private void SaveGame()
    {
        if(!gameOver) return;
        
        _canvas.gameObject.SetActive(true);
        
    }

    private void MoveBall()
    {
        if (ballRigidbody.velocity.x > 0)
        {
            ballRigidbody.velocity = new Vector3(0, 0, speed);
        } else if (ballRigidbody.velocity.z > 0)
        {
            ballRigidbody.velocity = new Vector3(speed, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Coin")) return;
        collectedCoins++;
        text.text = collectedCoins.ToString();
        Destroy(other.gameObject);
        Instantiate(audioSource, transform.position, Quaternion.identity);
        // Instantiate(particles, transform.position, Quaternion.identity);
    }

    private void UpSpeed()
    {
        if(gameOver) return;
        int rest = collectedCoins % 5;
        UpdateSpeed(rest);
        if (rest != 0 || (speed >= maxSpeed) || updated) return;
        speed += 0.2f;
        updated = true;

    }

    private void UpdateSpeed(int rest)
    {
        if (rest != 0)
        {
            updated = false;
        }
    }

    public void SaveScore()
    {
        HighScore highScore = new HighScore();
        highScore.user = inputField.text;
        highScore.score = collectedCoins;
        ListHighScore.SaveNewHighScore(highScore);
        SceneManager.LoadScene(0);
    }
}
