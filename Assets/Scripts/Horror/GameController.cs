using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject blood;
    public GameObject winPanel;

    public float time = 3;
    public GameObject monster;
    public AudioSource audioSource;
    public AudioClip winSound;
    public float firstSpawnTime = 2;
    public float secondSpawnTime = 2;

    private void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    public void LooseGame()
    {
        blood.SetActive(true);
        StartCoroutine(Restart());
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
        audioSource.clip = winSound;
        monster.SetActive(false);
        audioSource.Play();
        StartCoroutine(Restart());
    }

    IEnumerator SpawnMonster()
    {
        yield return new WaitForSeconds(firstSpawnTime);
        audioSource.Play();
        yield return new WaitForSeconds(secondSpawnTime);
        monster.SetActive(true);
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
