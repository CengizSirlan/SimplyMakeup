using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductManager : MonoBehaviour
{
    public GameObject product1;
    public GameObject product2;
    public GameObject product3;
    public GameObject product6;
    public GameObject product7;
    public GameObject product8;
    public GameObject product9;
    public GameObject product10;

    public products[] items= new products[8];

    public void Start()
    {
        items[0] = new products(0, product1);
        items[1] = new products(0, product2);

        items[2] = new products(0, product3);
        
        items[3] = new products(0, product6);
        items[4] = new products(0, product7);
        items[5] = new products(0, product8);
        items[6] = new products(0, product9);
        items[7] = new products(0, product10);


    }

    int[] ar = new int[] { 1555, 1205, 855, 505, 155, -195, -545, -895};

    public void arrangeProducts(products[] items)
    {
        
    }

    public void sortingRGB(Vector3 ac)
    {
        //Vector3[10] in unity engine

        //cosmetics RGB
        int[,] arrayRGB = new int[8, 3] { { 190,124,89 }, { 198,154,119 }, { 227,204,125}, { 230,186,161}, { 255, 225, 192}, { 255, 218, 189}, { 214, 180, 162}, { 250, 203, 159} };

        //face colour RGB


        int[] arrayCompare = new int[3] { (int)ac.x,(int) ac.y, (int)ac.z };

        int R1 = arrayCompare[0];
        int G1 = arrayCompare[1];
        int B1 = arrayCompare[2];

        //D values for the similarity
        products[] arraySimilar = new products[arrayRGB.GetLength(0)];
        for(int i = 0; i < arraySimilar.Length; i++)
        {
            arraySimilar[i] = new products(0, items[i].ui);
        }

        for (int i = 0; i < arrayRGB.GetLength(0); i++)
        {
            int R2 = arrayRGB[i, 0];
            int G2 = arrayRGB[i, 1];
            int B2 = arrayRGB[i, 2];

            float d = Mathf.Sqrt((float)(Math.Pow(((R2 - R1) * 0.3), 2) + Math.Pow(((G2 - G1) * 0.59), 2) + Math.Pow(((B2 - B1) * 0.11), 2)));

            arraySimilar[i].d = d;
        }


        //Sorts the similar colours from least to highest using a bubble sort algorithm
        products temp = null;

        for (int i = 0; i < arraySimilar.Length; i++)
        {
            for (int sort = 0; sort < arraySimilar.Length - 1; sort++)
            {
                if (arraySimilar[sort].d > arraySimilar[sort + 1].d)
                {
                    temp = arraySimilar[sort + 1];
                    arraySimilar[sort + 1] = arraySimilar[sort];
                    arraySimilar[sort] = temp;
                }
            }
        }
        

        arrangeProducts(arraySimilar);
    }

    public class products
    {
        public float d;
        public GameObject ui;

        public products(float d, GameObject u)
        {
            ui = u;
            this.d = d;
        }
    }
}
