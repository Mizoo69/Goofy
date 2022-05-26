using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement25 : MonoBehaviour
{
    public float MoveSpeed = 175;

    public Rigidbody2D rb;

    Vector2 movement;

    public static string havekey = "n";

    public GameObject YouPassed;

    public GameObject YouFailed;

    public GameObject CountDown;

    public GameObject Question;

    public static int keyCount = 0;

    public CountdownTimer timer;

    public TextMeshProUGUI keys;

    public TextMeshProUGUI speedText;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);

        Vector3 Player = transform.localScale;
        if (movement.x < 0.01)
        {
            Player.x = -60;
        }
        if (movement.x > 0.01)
        {
            Player.x = 60;
        }

        transform.localScale = Player;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Key")
        {
            keyCount++;
            keys.text = ("Keys: " + keyCount);
        }

        if (other.tag == "Candy")
        {
            MoveSpeed = MoveSpeed + 30;
            StartCoroutine(ShowMessage("Speed increased", 2));
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Door") && (keyCount == 5))
        {
            Question.SetActive(true);
            timer.saveYourTime();
            CountDown.SetActive(false);
            keyCount = 0;
            MoveSpeed = 175;
            timer.StopTimer();
            keys.text = "";
        }

        if (other.gameObject.tag == "Enemy")
        {
            YouFailed.SetActive(true);
            CountDown.SetActive(false);
            keyCount = 0;
            MoveSpeed = 175;
            timer.StopTimer();
            keys.text = "";
        }
    }

    IEnumerator ShowMessage (string message, float delay)
    {
        speedText.text = message;
        speedText.enabled = true;
        yield return new WaitForSeconds(delay);
        speedText.enabled = false;
    }
}
