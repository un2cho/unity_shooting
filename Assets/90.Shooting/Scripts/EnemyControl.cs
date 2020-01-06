using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyControl : MonoBehaviour
{
    //적의 이동속도
    public float EnemySpeed = 50.0f;
    //나의 트랜스폼 컴포넌트
    private Transform myTransform = null;
    //피격 이펙트
    public GameObject Explosion = null;
    
    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveAmount = EnemySpeed * Time.deltaTime * Vector3.back;
        myTransform.Translate(moveAmount);

        if (myTransform.position.y < -50.0f)
        {
            InitPosition();
        }
    }
    /// <summary>
    /// 내 위치 초기화 함수
    /// </summary>
    void InitPosition()
    {
        myTransform.position = new Vector3(Random.Range(-60.0f,60.0f), 50.0f, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            MainControl.Score += 100;
            Debug.Log("Bullet Trigger Enter");

            Instantiate(Explosion, myTransform.position, Quaternion.identity);
            
            InitPosition();
            Destroy(other.gameObject);
        }
    }
}
