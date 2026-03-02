namespace Rifoms.Domain.Infrastructure.Config
{
    public class ConnectionConfig
    {
        //Серверная БАЗА ДАННЫХ
        //Тепереча ДАННЫЙ СЕРВАК НА 1GB.RU НЕ ИСПОЛЬЗУЕТСЯ, ВСЕ НА ТЕСТОВОМ СЕРВАКЕ НА 38-ОМ IP-АДРЕСЕ
        //public static string DevServerConnection = "server=mysql94.1gb.ru;user id=gb_test_mayak;password=V5C4U-MNRmzD;database=gb_test_mayak;persistsecurityinfo=True;Convert Zero Datetime=True";

        //Локальная БАЗА ДАННЫХ
        public static string DevLocalConnection = "server=localhost;user id=gb_rifoms;password=Sovarizm82!;database=gb_rifoms;persistsecurityinfo=True;Convert Zero Datetime=True";

        //Локальная 192.168.1.38 БАЗА ДАННЫХ
        public static string DevLocal38ServerConnection = "server=192.168.1.38;user id=gb_rifoms;password=Sovarizm82!;database=gb_rifoms;persistsecurityinfo=True;Convert Zero Datetime=True";
    }
}
