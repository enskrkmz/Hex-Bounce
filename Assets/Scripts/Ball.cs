using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ball : MonoBehaviour
{
    private SpriteRenderer ballRenderer;
    private Rigidbody2D ballRb;
    [SerializeField] private float bounceSpeed;
    [SerializeField] private Color[] colors;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private AudioSource bounceSound;
    private int score = 0;
    private int highScore;
    

    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        ballRenderer = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.HasKey("highscore"))
        {
            highScore = PlayerPrefs.GetInt("highscore");
            highScoreText.text = "HÝGH SCORE: " + highScore;
        }
        else
        {
            highScore = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("startingedge"))
        {
            ballRb.AddForce(Vector2.up * (bounceSpeed/1.3f), ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("edge"))
        {
            SpriteRenderer collisioncolor = collision.gameObject.GetComponent<SpriteRenderer>();
            if (ballRenderer.color == collisioncolor.color)
            {   
                ballRb.AddForce(Vector2.up * bounceSpeed, ForceMode2D.Impulse);
                score++;
                scoreText.text = "SCORE: " + score;
                bounceSound.Play();
                if (score > highScore)
                {
                    highScore = score;
                    PlayerPrefs.SetInt("highscore", highScore);
                }
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("changer"))
        {
            int rnd = Random.Range(0, 6);
            ballRenderer.color = colors[rnd];
        }
    }

}
