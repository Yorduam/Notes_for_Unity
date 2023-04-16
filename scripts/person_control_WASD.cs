// Контроль персонажа с помощью WASD и с плавающей камерой
// Character control with WASD and floating camera

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
    
{
    private Vector3 m_camRot;
    private Transform m_camTransform; // Преобразование камеры

    private Transform m_transform; // Преобразование родительского объекта камеры
    public float m_movSpeed = 10; // Коэффициент движения
    public float m_rotateSpeed = 1; // коэффициент вращения

    private void Start()
    {
        m_camTransform = Camera.main.transform;
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        Control();
    }

    void Control()
    {
        if (Input.GetMouseButton(0))
        {
                         // Получаем расстояние перемещения мыши
            float rh = Input.GetAxis("Mouse X");
            float rv = Input.GetAxis("Mouse Y");
 
                         // Поворачиваем камеру
            m_camRot.x -= rv * m_rotateSpeed;
            m_camRot.y += rh*m_rotateSpeed;
 
        }
 
        m_camTransform.eulerAngles = m_camRot;
 
                 // Согласовываем направление взгляда главного героя с камерой
        Vector3 camrot = m_camTransform.eulerAngles;
        camrot.x = 0; camrot.z = 0;
        m_transform.eulerAngles = camrot;
 
                 // Определяем 3 значения для управления движением
        float xm = 0, ym = 0, zm = 0;
 
                 // Нажмите клавишу W, чтобы переместиться вверх
        if (Input.GetKey(KeyCode.W))
        {
            zm += m_movSpeed * Time.deltaTime;
        }
                else if (Input.GetKey (KeyCode.S)) // Нажмите клавишу S, чтобы переместиться вниз
        {
            zm -= m_movSpeed * Time.deltaTime;
        }
 
                 if (Input.GetKey (KeyCode.A)) // Нажмите клавиатуру A для перемещения влево
        {
            xm -= m_movSpeed * Time.deltaTime;
        }
                 else if (Input.GetKey (KeyCode.D)) // Нажмите клавишу D, чтобы переместиться вправо
        {
            xm += m_movSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) && m_transform.position.y <= 3)
        {
            ym+=m_movSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.F) && m_transform.position.y >= 1)
        {
            ym -= m_movSpeed * Time.deltaTime;
        }
        m_transform.Translate(new Vector3(xm,ym,zm),Space.Self);
    }
}