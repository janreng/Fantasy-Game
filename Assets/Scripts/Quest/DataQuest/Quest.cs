using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Inventory/Quest")]
public class Quest : ScriptableObject
{
    // Tên nhiệm vụ
    public string name;
    // Cấp nhận nhiệm vụ
    public int level;
    // Số thứ tự của nhiệm vụ
    public int order;
    // Mô tả nhiệm vụ
    public string description;
    // Trạng thái của nhiệm vụ
    public bool state;
    // Nơi thực hiện nhiệm vụ
    public Vector3 exePlace;
    // Nơi nhận nhiệm vụ
    public Vector3 receivePlace;
    // Nơi trả nhiệm vụ
    public Vector3 payPlace;
    // Kinh nghiệm nhận được khi hoàn thành
    public float exp;
    // Vàng nhận được khi hoàn thành
    public double gold;
    // Vật phẩm nhận được khi hoàn thành
    public Item[] items;
}
