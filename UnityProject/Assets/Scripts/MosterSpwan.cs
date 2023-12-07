using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterSpwan : MonoBehaviour
{
    private AudioManager audioManager;

    public GameObject monsterPrifabs;
    public int maxMonsterNum;

    public float spwanTime;

    public List<GameObject> monsters = new List<GameObject>();

    public GameObject[] monsterSpwanPoint;

    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        maxMonsterNum = 1;
        spwanTime = 7f;
        StartCoroutine(SpawnMonster());
    }

    public IEnumerator SpawnMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(spwanTime);

            if (monsters.Count < maxMonsterNum)
            {
                Vector3 spwanPosition = SpwanPoint();

                audioManager.MonsterSpwanSound();
                GameObject monster = Instantiate(monsterPrifabs, spwanPosition, Quaternion.identity);
                monsters.Add(monster);
            }
        }
    }

    private Vector3 SpwanPoint()
    {
        int randomPoint = Random.Range(0, monsterSpwanPoint.Length);
        return monsterSpwanPoint[randomPoint].transform.position;
    }
}