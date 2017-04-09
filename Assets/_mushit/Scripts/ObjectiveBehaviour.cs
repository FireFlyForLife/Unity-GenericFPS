using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveBehaviour : MonoBehaviour {
    public Text enemyCounter;
    public Text gameOverText;
    public int enemiesRemaning;
    public bool ended = false;

    void Start() {

    }

    void Update() {
        CountEnemies();

        enemyCounter.text = "Enemies Remaining: " + enemiesRemaning;
    }

    void FixedUpdate()
    {

    }

    public void CountEnemies()
    {
        enemiesRemaning = 0;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            Destroyable d = enemy.GetComponent<Destroyable>();
            if(d != null && !d.isDestroyed())
            {
                enemiesRemaning++;
            }
        }

        if (enemiesRemaning == 0)
        {
            GameOver(true);
        }
    }

    public void GameOver(bool won)
    {
        if (ended)
            return;

        ended = true;

        string txt;
        if (won)
            txt = "You defeated all the enemies!";
        else
            txt = "You failed! an enemy got to the airfield!";

        gameOverText.text = txt;
        gameOverText.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag.Equals("Enemy"))
        {
            GameOver(false);
        }
    }
}
