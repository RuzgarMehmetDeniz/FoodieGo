public class StatisticsData
{
    public int TotalProductCount { get; set; }
    public int CartItemCount { get; set; }
    public decimal CartTotal { get; set; }
    public int ActiveDiscountCount { get; set; }

    public int TotalCategoryCount { get; set; }
    public decimal AverageProductPrice { get; set; }
    public int DistinctCartProductCount { get; set; }
    public double MaxDiscountRate { get; set; }

    public List<CategoryProductStat> CategoryDistribution { get; set; }
}

public class CategoryProductStat
{
    public string Name { get; set; }
    public int ProductCount { get; set; }
    public double Percentage { get; set; }
    public double BarWidth => Percentage * 2;
}