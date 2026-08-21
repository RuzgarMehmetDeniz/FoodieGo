namespace FoodieGo.Pages;

public partial class SpinWheelPage : ContentPage
{
    // Dilim sayısı (görsele göre ayarlanacak)
    private const int SliceCount = 8;

    // Her dilimin ödülü (görseldeki sırayla, saat yönünde)
    private readonly string[] _prizes =
    {
        "%5 indirim",
        "%10 indirim",
        "%15 indirim",
        "%20 indirim",
        "%25 indirim",
        "%50 indirim",
        "Boş :(",
        "Tekrar çevir"
    };

    private readonly Random _random = new Random();

    public SpinWheelPage()
    {
        InitializeComponent();
    }

    private async void OnSpinClicked(object sender, EventArgs e)
    {
        // Çevirme sırasında butonu kapat (çift tıklama olmasın)
        SpinButton.IsEnabled = false;
        ResultLabel.Text = "";

        // Rastgele bir dilim seç
        int selectedSlice = _random.Next(SliceCount);

        // Bir dilimin açısı
        double sliceAngle = 360.0 / SliceCount;

        // Çarkı: birkaç tam tur + seçilen dilime denk gelecek açı
        int fullTurns = 5;
        double targetAngle = 360 * fullTurns + (360 - selectedSlice * sliceAngle - sliceAngle / 2);

        // Döndürme animasyonu (3 saniye, yavaşlayarak)
        await WheelImage.RotateTo(targetAngle, 3000, Easing.CubicOut);

        // Bir sonraki çevirme için açıyı sıfırla (görünmeden)
        WheelImage.Rotation = targetAngle % 360;

        // Sonucu göster
        ResultLabel.Text = $"🎉 {_prizes[selectedSlice]} kazandın!";

        SpinButton.IsEnabled = true;
    }

}