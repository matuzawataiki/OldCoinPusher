using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのアップグレードを管理するクラス
/// </summary>
public class UpgradeManagerScript : MonoBehaviour
{
    ////プレイヤーのアップグレードの種類
    //enum UpgradeType
    //{
    //    BoxSize,//ボックスのサイズ
    //    PlayerMoveSpeed,//プレイヤーの移動速度
    //    JackpotDiversion,//ジャックポットの転換
    //    ShotCoinInterval,//コインを発射できる間隔
    //    PlayerAtackPower//プレイヤーの攻撃力
    //}

    //プレイヤーオブジェクト
    public GameObject playerObject;
    //ボックスオブジェクト
    public GameObject boxObject;
    //コインオブジェクト
    public GameObject coinObject;
    //敵用マネージャーオブジェクト
    public GameObject enemyManagerObject;
    //プレイヤースクリプト
    PlayerScript playerScript;
    //ボックススクリプト
    BoxScript boxScript;
    //コインプッシャースクリプト
    CoinPusherScript coinPusherScript;
    //敵の挙動スクリプト
    EnemyBehaviorScript enemyBehaviorScript;
    //敵用マネージャースクリプト
    EnemyManagerScript enemyManagerScript;
    //ボックスのサイズの増減量
    public float boxSizeFluctuationAmount = 1.0f;
    //プレイヤーの移動速度の増減量
    public float playerMoveSpeedFluctuationAmount = 0.5f;
    //ジャックポットの転換の増減量
    public int jackpotDiversionFluctuationAmount = 1;
    //コインを発射できる間隔の増減量
    public float shotCoinIntervalFluctuationAmount = 0.05f;
    //プレイヤーの攻撃力の増減量
    public int playerAtackPowerFluctuationAmount = 1;
    ////アップグレードの種類
    //UpgradeType upgradeType = UpgradeType.BoxSize;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = playerObject.GetComponent<PlayerScript>();
        boxScript = boxObject.GetComponent<BoxScript>();
        coinPusherScript = playerObject.transform.GetChild(0).GetComponent<CoinPusherScript>();
        enemyBehaviorScript = coinObject.GetComponent<EnemyBehaviorScript>();
        enemyManagerScript = enemyManagerObject.GetComponent<EnemyManagerScript>();
    }
    
    //アップグレード一覧
    //ボックスのサイズをアップグレードする処理
    void UpgradeBoxSize()
    {
        boxScript.UpgradeBoxSize(boxSizeFluctuationAmount);
    }

    //プレイヤーの移動速度をアップグレードする処理
    void UpgradePlayerMoveSpeed()
    {
        playerScript.UpgradePlayerMoveSpeed(playerMoveSpeedFluctuationAmount);
    }

    //ジャックポットの転換をアップグレードする処理
    void UpgradeJackpotDiversion()
    {
        enemyBehaviorScript.UpgradeJackpotDiversion(jackpotDiversionFluctuationAmount);
    }

    //コインを発射できる間隔をアップグレードする処理
    void UpgradeCoinPusherInterval()
    {
        coinPusherScript.UpgradeShotCoinInterval(shotCoinIntervalFluctuationAmount);
    }

    //プレイヤーの攻撃力をアップグレードする処理
    void UpgradePlayerAtackPower()
    {
        enemyManagerScript.UpgradePlayerAtackPower(playerAtackPowerFluctuationAmount);
    }


    //ダウングレード一覧
    //ボックスのサイズをダウングレードする処理
    void DowngradeBoxSize()
    {
        boxScript.DowngradeBoxSize(boxSizeFluctuationAmount);
    }

    //プレイヤーの移動速度をダウングレードする処理
    void DowngradePlayerMoveSpeed()
    {
        playerScript.DowngradePlayerMoveSpeed(playerMoveSpeedFluctuationAmount);
    }

    //ジャックポットの転換をダウングレードする処理
    void DowngradeJackpotDiversion()
    {
        enemyBehaviorScript.DowngradeJackpotDiversion(jackpotDiversionFluctuationAmount);
    }

    //コインを発射できる間隔をダウングレードする処理
    void DowngradeCoinPusherInterval()
    {
        coinPusherScript.DowngradeShotCoinInterval(shotCoinIntervalFluctuationAmount);
    }

    //プレイヤーの攻撃力をダウングレードする処理
    void DowngradePlayerAtackPower()
    {
        enemyManagerScript.DowngradePlayerAtackPower(playerAtackPowerFluctuationAmount);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
