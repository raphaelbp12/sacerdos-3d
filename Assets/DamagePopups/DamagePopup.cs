/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UtilsClass {        
    // Get Color from Hex string FF00FFAA
    public static Color GetColorFromString(string color) {
        float red = Hex_to_Dec01(color.Substring(0,2));
        float green = Hex_to_Dec01(color.Substring(2,2));
        float blue = Hex_to_Dec01(color.Substring(4,2));
        float alpha = 1f;
        if (color.Length >= 8) {
            // Color string contains alpha
            alpha = Hex_to_Dec01(color.Substring(6,2));
        }
        return new Color(red, green, blue, alpha);
    }

    public static float Hex_to_Dec01(string hex) {
        return Hex_to_Dec(hex)/255f;
    }

    public static int Hex_to_Dec(string hex) {
        return Convert.ToInt32(hex, 16);
    }
}

public class DamagePopup : MonoBehaviour {
    [SerializeField]
    int normalDamageFontSize = 36;
    [SerializeField]
    int criticalDamageFontSize = 45;
    private Transform targetHealthBar;

    // Create a Damage Popup
    public static DamagePopup Create(Transform target, int damageAmount, bool isCriticalHit) {
        Vector3 worldToScreenPos = Camera.main.WorldToScreenPoint(target.position);
        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, worldToScreenPos, Quaternion.identity);

        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(target, damageAmount, isCriticalHit);

        damagePopupTransform.transform.SetParent(canvas.transform);
        return damagePopup;
    }

    private static int sortingOrder;

    private const float DISAPPEAR_TIMER_MAX = 1f;

    public TextMeshProUGUI textMesh;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;

    private void Awake() {
        textMesh = transform.gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void Setup(Transform target, int damageAmount, bool isCriticalHit) {
        targetHealthBar = target;

        textMesh.SetText(damageAmount.ToString());
        if (!isCriticalHit) {
            // Normal hit
            textMesh.fontSize = normalDamageFontSize;
            textColor = UtilsClass.GetColorFromString("FFC500");
        } else {
            // Critical hit
            textMesh.fontSize = criticalDamageFontSize;
            textColor = UtilsClass.GetColorFromString("FF2B00");
        }
        textMesh.color = textColor;
        disappearTimer = DISAPPEAR_TIMER_MAX;

        // sortingOrder++;
        // textMesh.sortingOrder = sortingOrder;

        moveVector = new Vector3(2, 5, 0) * 60f;
    }

    private void Update() {
        Vector3 worldToScreenPos = Camera.main.WorldToScreenPoint(targetHealthBar.position);
        transform.position = worldToScreenPos + moveVector * Time.deltaTime;
        moveVector -= moveVector * 20f * Time.deltaTime;

        if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f) {
            // First half of the popup lifetime
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        } else {
            // Second half of the popup lifetime
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0) {
            // Start disappearing
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0) {
                Destroy(gameObject);
            }
        }
    }

}
