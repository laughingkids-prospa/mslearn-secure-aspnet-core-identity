using QRCoder;

namespace RazorPagesPizza.Services;

public class QRCodeService
{
    private readonly QRCodeGenerator _qrCodeGenerator;

    public QRCodeService(QRCodeGenerator qRCodeGenerator)
    {
        _qrCodeGenerator = qRCodeGenerator;
    }

    public string GetQRCodeBase64(string textToEncode)
    {
        var qrCodeData = _qrCodeGenerator.CreateQrCode(textToEncode, QRCodeGenerator.ECCLevel.Q);
        var qrCode = new PngByteQRCode(qrCodeData);

        return Convert.ToBase64String(qrCode.GetGraphic(4));
    }
}