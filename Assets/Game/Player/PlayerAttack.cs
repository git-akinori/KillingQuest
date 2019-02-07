using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator playerAnimator;
    
    float requireTouchTime;

    void Start()
    {
        playerAnimator = GameManager.Member.PlayerBehaviour.Animator;
    }

    public IEnumerator AttackCoroutine()
    {
        if (!playerAnimator) { playerAnimator = GameManager.Member.PlayerBehaviour.Animator; }

        while (playerAnimator)
        {
            // タッチされたら
            if (AppUtil.GetTouchInfo() == TouchInfo.Began)
            {
                var elapsedTime = 0f;

                yield return null;

                // タッチしたままなら
                while ((AppUtil.GetTouchInfo() == TouchInfo.Stationary || AppUtil.GetTouchInfo() == TouchInfo.Stationary) && elapsedTime < requireTouchTime)
                {
                    elapsedTime += Time.deltaTime;

                    yield return null;
                }

                // 一定時間経過後
                if (elapsedTime >= requireTouchTime)
                {
                    playerAnimator.SetTrigger("special");
                }

                // タッチが離れたら
                else if (AppUtil.GetTouchInfo() == TouchInfo.Ended)
                {
                    playerAnimator.SetTrigger("AttackMotion");
                }
            }
            // タッチされていないなら
            else
            {
                yield return null;
            }
        }
        yield return null;
    }

    public float RequireTouchTime { set { requireTouchTime = value; } }
}
