using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Square : MonoBehaviour {

   
    private List<Color> colors = new List<Color>() {
        Color.red, 
        Color.green, 
        Color.blue,
        Color.yellow,
        Color.black,
        Color.white
    };
    private int currentColor;

    private bool playerCameUp = false;
    
    private SpriteRenderer sprite;

    private PlayerController playerController;
    private TMP_Text text;

    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
        playerController = FindObjectOfType<PlayerController>();
        text = GetComponentInChildren<TMP_Text>();
    }
    private void OnEnable() {
        playerController.OnPressUse += SwitchColor;
    }

    private void OnDisable() {
        playerController.OnPressUse -= SwitchColor;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            text.enabled = true;
            playerCameUp = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            text.enabled = false;
            playerCameUp = false;
        }
    }

    private void SwitchColor (object sender, System.EventArgs e) {
        if (playerCameUp) {
            if (currentColor < colors.Count - 1) {
                currentColor++;
            } else {
                currentColor = 0;
            }
            sprite.color = colors[currentColor];
        }
    }
}
    
