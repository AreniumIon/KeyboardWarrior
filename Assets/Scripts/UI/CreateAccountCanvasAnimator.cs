using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAccountCanvasAnimator : MonoBehaviour
{
    [SerializeField] Transform _targetTransform;

    private static Vector2 CENTER_POS = new Vector2(0f, 0f);
    private static Vector2 START_POS = new Vector2(0f, 2000f);

    private static float MOVE_TIME = 1f;

    private void OnEnable()
    {
        SetToStartPos();
        StartCoroutine(MoveToCenter());
    }

    private void SetToStartPos()
    {
        _targetTransform.localPosition = START_POS;
    }

    private IEnumerator MoveToCenter()
    {
        float timer = 0f;

        while (timer < MOVE_TIME)
        {
            timer += Time.deltaTime;

            float progress = MathFunctions.SmoothStop3(timer / MOVE_TIME);


            float x = Mathf.Lerp(START_POS.x, CENTER_POS.x, progress);
            float y = Mathf.Lerp(START_POS.y, CENTER_POS.y, progress);

            _targetTransform.localPosition = new Vector2(x, y);

            yield return null;
        }
    }
}
