using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckCollisions : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    private PlayerController playerController;
    Vector3 PlayerStartPos;
    // public GameObject speedBoosterIcon;
    private InGameRanking ig;
    private float baseSpeed;
    private bool boostFlag;

    private void Start()
    {
        if (gameObject == GameObject.Find("Player"))
            playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        PlayerStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        // speedBoosterIcon.SetActive(false);
        ig = FindObjectOfType<InGameRanking>();
        baseSpeed = playerController.runningSpeed;
        boostFlag = false;
    }

    void PlayerFinished()
    {
        playerController.runningSpeed = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Finish"))
        {
            PlayerFinished();
            /* if (ig.namesTxt[6].text == "Player")
                Debug.Log("W");
            else
                Debug.Log("L"); */
        }
        else if (other.CompareTag("Booster"))
        {
            boostFlag = true;
            // speedBoosterIcon.SetActive(true);
            playerController.runningSpeed *= 1.5f;
            StartCoroutine(SlowAfterAWhileCoroutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = PlayerStartPos;
            boostFlag = false;
            playerController.runningSpeed = baseSpeed;
        }
    }

    public void AddCoin()
    {
        ++score;
        CoinText.text = "Score: " + score.ToString();
    }

    private IEnumerator SlowAfterAWhileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        if (boostFlag == true) {
            playerController.runningSpeed /= 1.5f;
            // speedBoosterIcon.SetActive(false);
            boostFlag = false;
        }
    }
}
