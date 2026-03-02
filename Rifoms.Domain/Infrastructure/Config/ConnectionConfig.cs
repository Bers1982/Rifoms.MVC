namespace Rifoms.Domain.Infrastructure.Config
{   
    public class ConnectionConfig
    {
        /// <summary>
        /// Серверная БАЗА ДАННЫХ 
        /// Тепереча ДАННЫЙ СЕРВАК НА 1GB.RU НЕ ИСПОЛЬЗУЕТСЯ, ВСЕ НА ТЕСТОВОМ СЕРВАКЕ НА 38-ОМ IP-АДРЕСЕ
        /// </summary>
        //public static string DevServerConnection = "server=mysql94.1gb.ru;user id=gb_test_mayak;password=V5C4U-MNRmzD;database=gb_test_mayak;persistsecurityinfo=True;Convert Zero Datetime=True";

        /// <summary>
        /// Локальная БАЗА ДАННЫХ
        /// </summary>
        public static string DevLocalConnection = "server=localhost;user id=gb_rifoms;password=Sovarizm82!;database=gb_rifoms;persistsecurityinfo=True;Convert Zero Datetime=True";


        /// <summary>
        /// Локальная на сервере 192.168.1.38 БАЗА ДАННЫХ
        /// </summary>
        public static string DevLocal38ServerConnection = "server=192.168.1.38;user id=gb_rifoms;password=Sovarizm82!;database=gb_rifoms;persistsecurityinfo=True;Convert Zero Datetime=True";
    }
}
