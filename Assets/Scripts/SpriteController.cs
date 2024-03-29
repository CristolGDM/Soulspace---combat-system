using ORKFramework;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    static int currentCharacter = 0;
    private readonly int maxCharacter = 2;
    static int characterDirection = 2;

    private readonly float minSize = 0.5f;
    private readonly float maxSize = 2.0f;
    private readonly float sizeInterval = 0.5f;
    static float characterSize = 1.0f;

    private Animator animator;


    private void Awake() {
        if (animator == null) {
            animator = GetComponentInChildren<Animator>();
            animator.SetInteger("Direction", characterDirection);
        }
    }

    #region CharacterSwitching
    public void PreviousCharacter() {
        if(currentCharacter == 0) {
            currentCharacter = maxCharacter;
        } else {
            currentCharacter--;
        }
        SetCharacter();
    }

    public void NextCharacter() {
        if (currentCharacter == maxCharacter) {
            currentCharacter = 0;
        }
        else {
            currentCharacter++;
        }
        SetCharacter();
    }

    private void SetCharacter() {
        ORK.GlobalEvents.Get(currentCharacter).Call();
    }

    #endregion

    public void SetDirection(Vector2 vector) {
        float x = vector.x;
        float y = vector.y;

        if(x == 0) {
            if(y < 0) {
                SetDirectionDown();
                return;
            }
            if (y > 0) {
                SetDirectionUp();
                return;
            }
        }
        if(x < 0) {
            SetDirectionLeft();
            return;
        }
        if (x > 0) {
            SetDirectionRight();
            return;
        }
    }

    private void SetDirectionUp() {
        if (animator != null) {
            animator.SetInteger("Direction", 0);
            characterDirection= 0;
        }
    }
    private void SetDirectionRight() {
        if (animator != null) {
            animator.SetInteger("Direction", 1);
            characterDirection= 1;
        }
    }
    private void SetDirectionDown() {
        if (animator != null) {
            animator.SetInteger("Direction", 2);
            characterDirection= 2;
        }
    }
    private void SetDirectionLeft() {
        if (animator != null) {
            animator.SetInteger("Direction", 3);
            characterDirection= 3;
        }
    }

    public void ZoomSprite() {
        if(characterSize == maxSize) {
            SetSpriteSize(minSize);
            return;
        }
        SetSpriteSize(characterSize + sizeInterval);
    }
    public void UnzoomSprite() {
        if (characterSize == minSize) {
            SetSpriteSize(maxSize);
            return;
        }
        SetSpriteSize(characterSize - sizeInterval);
    }

    private void SetSpriteSize(float size) {

    }
}
