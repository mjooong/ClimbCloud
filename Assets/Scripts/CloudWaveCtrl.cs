using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudWaveCtrl : MonoBehaviour
{
    GameObject player;
    float destroyDistance = 10.0f;  //���ΰ� �Ʒ������� 10m

    public GameObject[] Clouds;
    public GameObject Fish;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("cat");        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;

        //���� �Ÿ� �Ʒ� �ı�
        if (transform.position.y < playerPos.y - destroyDistance)
            Destroy(gameObject);
    }

    public void SetHideCloud(int a_Count)
    {   //a_Count ��� ������ �ʰ� �� ���� ����

        List<int> active = new List<int>();
        for(int ii = 0; ii < Clouds.Length; ii++)
        {
            active.Add(ii);
        }

        for(int ii = 0; ii < a_Count; ii++)
        {
            int ran = Random.Range(0, active.Count);
            Clouds[active[ran]].SetActive(false);

            active.RemoveAt(ran);
        }

        active.Clear();

        //--- ����� ���� ��Ű��...
        int range = 10;     //10���� 1Ȯ���� �������� ������ ����

        SpriteRenderer[] a_CloudObj = GetComponentsInChildren<SpriteRenderer>();
        //Active�� Ȱ��ȭ �Ǿ� �ִ� ���� ��ϸ� �������� ���
        for(int ii = 0; ii < a_CloudObj.Length; ii++)
        {
            if (Random.Range(0, range) == 0)
                SpawnFish(a_CloudObj[ii].transform.position);
        }
        //--- ����� ���� ��Ű��...

    }//public void SetHideCloud(int a_Count)

    void SpawnFish(Vector3 a_Pos)
    {
        GameObject go = Instantiate(Fish);
        go.transform.position = a_Pos + Vector3.up * 0.8f;
    }
}
