using UnityEngine;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;
    private int coins;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    public void ExchangeProduct(ProductData productData)
    {
        AddCoin(productData.productPrice);
    }
    public void AddCoin(int price)
    {
        coins += price;
        DisplayCash();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void DisplayCash()
    {
        UIManager.Instance.ShowCoinCountOnScreen(coins);
    }
}
