using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ResourceManger : MonoBehaviour
{
    private static ResourceManger instance;
    public static ResourceManger Instance => instance;

    [SerializeField]
    private int coins;
    public int Coins => coins;

    private void Awake()
    {
        instance = this;
    }
}

