using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;

    public Rigidbody Rig;

    private bool _isGrounded;

    public int Score;

    public UI UI;

    private void Start()
    {
        UI.SetScoreText(Score);
    }
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * MoveSpeed;
        float zMove = Input.GetAxis("Vertical") * MoveSpeed;
        
        Rig.velocity = new Vector3(xMove, Rig.velocity.y, zMove);

        Vector3 vel = Rig.velocity;
        vel.y = 0f;

        if (vel.x != 0 || vel.y != 0)
        {
            transform.forward = vel;
        }

        if (Input.GetKeyDown(KeyCode.Space)&& _isGrounded==true)
        {
            _isGrounded = false;
            Rig.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }

        if (transform.position.y < -10f)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal==Vector3.up)
        {
            _isGrounded = true;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        Score += amount;
        UI.SetScoreText(Score);
    }
}
