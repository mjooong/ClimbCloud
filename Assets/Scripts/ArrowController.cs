using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    float speed = 5.0f;
    GameObject player;

    public Image warningImg;
    float waitTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        if(0.0f < waitTime)
        {
            waitTime -= Time.deltaTime;
            WarningDirect();    //���� ������ ����
            return;
        }

        if (warningImg.gameObject.activeSelf == true)
            warningImg.gameObject.SetActive(false); //��� ǥ�� ����

        transform.Translate(0.0f, -speed * Time.deltaTime, 0.0f);
        if (transform.position.y < player.transform.position.y - 10.0f)
            Destroy(gameObject);
    }

    public void InitArrow(float a_PosX)
    {
        player = GameObject.Find("cat");
        transform.position = new Vector3(a_PosX * 1.1f,
                        player.transform.position.y + 10.0f, 0.0f);
        //���⼭ * 1.1f �� ȭ���� �������� ��ġ�� ������ �߾ӿ� �����ֱ� ���ؼ�...

        //��� ǥ�� ��ġ ����ֱ�
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        warningImg.transform.position = new Vector3(screenPos.x,
            warningImg.transform.position.y, warningImg.transform.position.z);
        //��� ǥ�� ��ġ ����ֱ�
    }

    float alpha = 0.0f; //���� ��ȭ �ӵ�
    void WarningDirect() //������ ���� ��ȭ ���� �Լ�
    {
        if (warningImg == null)
            return;

        if (warningImg.color.a >= 1.0f)
            alpha = -6.0f;
        else if (warningImg.color.a <= 0.0f)
            alpha = 6.0f;

        warningImg.color = new Color(1.0f, 1.0f, 1.0f,
                        warningImg.color.a + alpha * Time.deltaTime);
    }
}
