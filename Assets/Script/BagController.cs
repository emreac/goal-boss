using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BagController : MonoBehaviour
{
    private Vector3 originalScale;
    public GameObject waterBottlesInBox;

    [SerializeField] private Transform bag;
    public List<ProductData> productDataList;
    private Vector3 productSize;
    [SerializeField] TextMeshProUGUI maxText;
    int maxBagCapacity;
    // Start is called before the first frame update
    void Start()
    {
        maxBagCapacity = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ShopPoint"))
        {
            for (int i = productDataList.Count - 1; i >= 0; i--)
            {

                Destroy(bag.transform.GetChild(i).gameObject);
                productDataList.RemoveAt(i);
                StartCoroutine(AddBottlesToBoxes());
            }

            ControlBagCapacity();


        }
    }

    public void AddProductToBag(ProductData prodcutData)
    {

        GameObject bagProduct = Instantiate(prodcutData.productPrefab, Vector3.zero, Quaternion.identity);
        //Instantiate(object, position, rotation)
        bagProduct.transform.SetParent(bag, true);

        CalculateItemSize(bagProduct);
        float YPosition = CalculateNewYPositionOfItem();
        bagProduct.transform.localRotation = Quaternion.identity;
        bagProduct.transform.localPosition = Vector3.zero;
        bagProduct.transform.localPosition = new Vector3(0, YPosition, 0);
        productDataList.Add(prodcutData);
        ControlBagCapacity();
    }

    private float CalculateNewYPositionOfItem()
    {
        float newYPos = productSize.y * productDataList.Count;
        return newYPos;
    }
    private void CalculateItemSize(GameObject gameObject)
    {
        if (productSize == Vector3.zero)
        {
            MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
            productSize = renderer.bounds.size;
        }

    }
    private void ControlBagCapacity()
    {
        if (productDataList.Count == maxBagCapacity)
        {
            SetMaxTextOn();
            //Activate maxText
        }
        else
        {
            SetMaxTextOff();

        }
    }

    private void SetMaxTextOn()
    {
        if (!maxText.isActiveAndEnabled)
        {

            maxText.gameObject.SetActive(true);
            DOTween.Restart("MaxTextFade");
        }
    }
    private void SetMaxTextOff()
    {
        if (maxText.isActiveAndEnabled)
        {
            maxText.gameObject.SetActive(false);
        }
    }
    public bool IsEmptySpace()
    {
        if (productDataList.Count < maxBagCapacity)
        {
            return true;
        }
        return false;
    }

    IEnumerator AddBottlesToBoxes()
    {

        waterBottlesInBox.SetActive(true);
        DOTween.Restart("WaterBottleBoxScaleOn");
        yield return new WaitForSeconds(6.0f);

        waterBottlesInBox.SetActive(false);

    }
}
