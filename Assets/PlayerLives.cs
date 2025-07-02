using UnityEngine;
using TMPro;

public class PlayerLives : MonoBehaviour
{
    public int livesScore = 5;
    public int score = 0;
    public GameObject[] player;
    public Transform SpawnPoint;
    public GameObject[] livesImages;
    //public TextMeshProUGUI scoreText;
    public AudioSource pickUpSound;
    public float pitchIncrease = 0.1f;
    public GameObject panel;

    void Start()
    {

        pickUpSound = GetComponent<AudioSource>();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Debug.Log("hiting");
            score += 1;
            livesScore -= 1;
            pickUpSound.pitch = pickUpSound.pitch + pitchIncrease;
            pickUpSound.Play();

            if (score >= 10)
            {
                panel.SetActive(true);
            }


            if (livesScore > 0 && livesScore <= livesImages.Length)
            {
                Spawner();
                livesImages[livesScore-1].SetActive(false);

            }
            else
            {

                Debug.Log("No more lives left");
                GameOver();

            }
        }

    }

    void Spawner()
    {
        if (player == null)
        {
            Debug.LogError("Player prefab is not assigned!");
            return;
        }

        if (SpawnPoint == null)
        {
            Debug.LogError("SpawnPoint is not assigned!");
            return;
        }

        if (livesScore > 0 && livesScore <= player.Length)
        {

            GameObject newPlayer = Instantiate(player[livesScore-1], SpawnPoint.position, Quaternion.identity);

            //livesText.text = "Spheres: " + livesScore;
        }
        else
        {
            Debug.LogWarning("No more lives or invalid index for spawning");
        }

    }
    
    void GameOver()
    {
        //GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }


   
}
