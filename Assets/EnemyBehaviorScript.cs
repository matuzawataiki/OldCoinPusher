using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// �G�l�~�[�̓����ɂ��R�C���̋����𐧌䂷��N���X
/// </summary>
public class EnemyBehaviorScript : MonoBehaviour
{
    //�R�C�������p�̕ϐ��ꗗ
    //�R�C���̓�������
    float coinFreezeTime = 0.0f;
    //�R�C�����𓀂��鎞��
    float coinUnfreezeTime = 5.0f;
    //�R�C���̓�����Ԃ��Ǘ�����t���O
    bool isCoinFreeze = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.name == "Tornado(Clone)")
        {
            Rigidbody rb = transform.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 20.0f, ForceMode.Impulse);
        }
        else if(other.transform.parent.name == "Freeze(Clone)")
        {
            CoinFreeze();//�R�C���𓀌����鏈��
        }
    }

    //�R�C���𓀌����鏈��
    void CoinFreeze()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.color = Color.blue;
        Rigidbody rb = transform.gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        isCoinFreeze = true;
    }

    // �R�C�����𓀂��鏈��
    void CoinUnFreeze()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.color = Color.white;
        Rigidbody rb = transform.gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        isCoinFreeze = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isCoinFreeze)
        {
            coinFreezeTime += Time.deltaTime;
            //�R�C���̓������Ԃ��𓀎��Ԃ𒴂�����𓀂���
            if (coinFreezeTime >= coinUnfreezeTime)
            {
                CoinUnFreeze();//�R�C�����𓀂��鏈��
                coinFreezeTime = 0.0f;
            }
        }
    }
}
