using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPusherScript : MonoBehaviour
{
    //�R�C�����˗p�̕ϐ��ꗗ
    //�R�C���I�u�W�F�N�g���i�[����ϐ�
    public GameObject coinObject;

    //�R�C���̔��ˑ��x
    float coinShotSpeed = 800.0f;

    //�R�C���𔭎˂𐧌�����t���O
    bool shotCoinLimitFlag = false;

    //�����ŃR�C���𔭎˂���t���O
    bool autoShotCoinFlag = false;

    //�R�C���𔭎˂ł���Ԋu�i�b�j
    float shotCoinInterval = 0.3f;

    //�R�C���𔭎˂ł���Ԋu�̃^�C�}�[
    float shotCoinTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //�R�C���𔭎˂��鏈��
    void ShotCoin()
    {
        //�蓮�ŃR�C���𔭎˂��Ă���Ƃ�
        if (!autoShotCoinFlag)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                //�����ŃR�C���𔭎˂���悤�ɐ؂�ւ���
                autoShotCoinFlag = true;
            }
        }
        //�����ŃR�C���𔭎˂��Ă���Ƃ�
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                //�蓮�ŃR�C���𔭎˂���悤�ɐ؂�ւ���
                autoShotCoinFlag = false;
            }
        }

        //�R�C���̔��˂𐧌�����Ă��Ȃ��ꍇ�́A�R�C���𔭎˂ł���
        if (!shotCoinLimitFlag)
        {
            if (Input.GetKey(KeyCode.Space) || autoShotCoinFlag)
            {
                //�R�C���I�u�W�F�N�g�𐶐����鏈��
                CreateCoinObject();

                //�R�C���̔��˂𐧌�����
                shotCoinLimitFlag = true;
            }
        }
        //�R�C���̔��˂𐧌�����Ă���ꍇ�́A�R�C���̔��˂𐧌�����
        else
        {
            //�R�C���̔��˂𐧌����鎞�Ԃ̍X�V
            shotCoinTimer += Time.deltaTime;

            //�R�C���̔��˂𐧌����鎞�Ԃ��o�߂����ꍇ�A�R�C���̔��˂𐧌�����������
            if (shotCoinTimer >= shotCoinInterval)
            {
                shotCoinLimitFlag = false;
                shotCoinTimer = 0.0f;
            }
        }
    }

    //�R�C���I�u�W�F�N�g�𐶐����鏈��
    void CreateCoinObject()
    {
        //�R�C���̔��ˈʒu���v���C���[�̑O���ɐݒ�
        Vector3 playerPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        //�R�C���I�u�W�F�N�g�𐶐����A�v���C���[�̑O���ɔ��˂���
        GameObject coin = Instantiate(coinObject, playerPos, Quaternion.identity);

        //�R�C����Rigidbody�R���|�[�l���g�̎擾
        Rigidbody coinRigidbody = coin.GetComponent<Rigidbody>();

        //�R�C����Rigidbody�ɗ͂������āA�R�C����O���ɔ��˂���
        coinRigidbody.AddForce(transform.forward * coinShotSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        ShotCoin();//�R�C���𔭎˂��鏈��
    }
}
