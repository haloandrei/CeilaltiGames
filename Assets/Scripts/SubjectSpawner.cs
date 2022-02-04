using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubjectSpawner : MonoBehaviour
{
    public GameObject[] subjects;
    public Transform leftSpawn, rightSpawn;

	public static int waveNumber = 0;
	public static int bossWave = 10;

	public TextMeshProUGUI waveText;
	public Vector2 posX, posY;
	public GameObject mainCamera, player, boss;
	public float pauseTime, spawnIntervalTime, focusOnBossTime;
	//public AudioClip boss2Music, bossDefeatedMusic;

	IEnumerator coroutine;
	Vector2 pos, bossPos;
	bool spawningWave, focusedOnBoss;

	void Start()
	{
		waveNumber = 0;
		spawningWave = true;
		coroutine = SpawnWave();
		StartCoroutine(coroutine);
	}

	void Update()
	{
		if (waveNumber > bossWave)
		{
			return;
		}
		else if (waveNumber == bossWave)
		{
			//boss2.SetActive(true);
			if (boss != null)
			{
				bossPos = boss.transform.position;
				if (!focusedOnBoss)
				{
					focusedOnBoss = true;
					coroutine = FocusOnBoss();
					StartCoroutine(coroutine);
				}
				return;
			}
		}

		if (!spawningWave && GameObject.FindGameObjectWithTag("Enemy") == null)
		{
			spawningWave = true;
			coroutine = SpawnWave();
			StartCoroutine(coroutine);
		}
	}

	IEnumerator FocusOnBoss()
	{
		mainCamera.GetComponent<CameraFollow>().target = boss.transform;
		yield return new WaitForSeconds(focusOnBossTime);
		mainCamera.GetComponent<CameraFollow>().target = player.transform;
	}

	IEnumerator SpawnWave()
	{
		yield return new WaitForSeconds(pauseTime / 3);
		waveNumber++;
		waveText.text = "WAVE " + waveNumber;
		waveText.gameObject.SetActive(true);
		yield return new WaitForSeconds(pauseTime / 3);
		waveText.gameObject.SetActive(false);
		yield return new WaitForSeconds(pauseTime / 3);

		// Spawn mobs
		if (waveNumber < bossWave)
			for (int i = 0; i <= (waveNumber + 1) / 2; ++i)
			{ // wavenumber + 1 ca sa inceapa cu 2 skeletoni in loc de 1
				//if (GameOverManager.gameOver)
				//{
				//	i--;
				//	yield return new WaitForSeconds(1);
				//	continue;
				//}
				pos.x = Random.Range(posX.x, posX.y);
				pos.y = Random.Range(posY.x, posY.y);

				Instantiate(subjects[Random.Range(0, subjects.Length)], pos, Quaternion.identity);
				yield return new WaitForSeconds(spawnIntervalTime);
			}

		spawningWave = false;
	}
}
