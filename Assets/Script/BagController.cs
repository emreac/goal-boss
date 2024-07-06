using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    [SerializeField] private Transform bag;
    public List<ProductData> productDataList;
    private Vector3 productSize;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

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
}
