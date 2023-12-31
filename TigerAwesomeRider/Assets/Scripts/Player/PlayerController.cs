using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public enum PlayerState { OnShip, Action }

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerEnterPoint;

    [Space]
    [SerializeField] private Joystick joystick;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;

    [Space]
    [SerializeField] private float moveSpeed;

    [Space]
    [SerializeField] private PlayerState state;
    public ParticleSystem MoveEffect1;
    public ParticleSystem MoveEffect2;
    //[ReadOnly, SerializeField] private PlayerState state;

    private HealthComponent health;

    private void Awake()
    {
        //health = HealthComponent.instance;
        health = GetComponent<HealthComponent>();

        health.onDie += Die;
    }

    private void OnDestroy()
    {
        health.onDie -= Die;
    }

    private void Die()
    {
        print("�� ����");
        moveSpeed = 0;
        animator.SetBool("IsDead", true);
        UIManager.Instance.ChangeScreen("Lose");
        Invoke("SetActiveFalse", 2);
    }

    private void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (state != PlayerState.Action) return;

        Vector3 movement = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        animator.SetBool("IsMove", movement != Vector3.zero);

        if (movement != Vector3.zero)
        {
            MoveEffect1.Play();
            MoveEffect2.Play();
            // ��������� ������� ���� �������� �� ������ ����������� ��������.
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            // ������ ������������� ������� ���� �������� � �������� ���� ��������.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3);

            // ���������� ��������.
            rb.MovePosition(transform.position + movement * Time.deltaTime * moveSpeed);
        }



        //if (state != PlayerState.Action) return;

        //Vector3 movement = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        //rb.MovePosition(transform.position + movement * Time.deltaTime * moveSpeed);

        //transform.rotation = Quaternion.LookRotation(movement);
        //animator.SetBool("IsMove", movement != Vector3.zero);
    }

    public void ChangeState(PlayerState newState)
    {
        state = newState;

        if (state == PlayerState.Action)
        {
            transform.position = playerEnterPoint.position;
        }
        else
        {
            animator.SetBool("IsMove", false);
        }
    }
}
