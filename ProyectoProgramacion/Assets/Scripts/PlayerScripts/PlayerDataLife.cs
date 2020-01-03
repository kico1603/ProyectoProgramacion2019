using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataLife : MonoBehaviour
{
    public float life;
    private float nextLife;

    // Start is called before the first frame update
    void Start()
    {
        life = 150f;
    }

    public void addDamage(float damage) {
        life -= damage;

        if (life <= 0)
        {
            death();
        }

        nextLife = Time.time + 6;

    }

    private void death()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("GameOver");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextLife)
        {
            if (life < 150f) {
                life += 10;
                nextLife = Time.time + 1;
                if (life > 150f)
                    life = 150;
            }
        }

        
    }



}
