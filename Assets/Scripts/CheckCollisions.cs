using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckCollisions : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    public PlayerController playerController;
    Vector3 PlayerStartPos;
    public GameObject speedBoosterIcon;

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

        if (other.CompareTag("Booster"))
        {
            playerController.runningSpeed *= 1.5f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = PlayerStartPos;
        }
    }

    public void AddCoin()
    {
        ++score;
        CoinText.text = "Score: " + score.ToString();
    }
}
