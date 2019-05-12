using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherApp.Models;

namespace WeatherApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            todayDockPanel.IsEnabled = false;
            daysStackPanel.IsEnabled = false;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FindButtonClick(object sender, RoutedEventArgs e)
        {
            #region Получение координат
            string geoCodeUrl = $"https://geocode-maps.yandex.ru/1.x/?geocode={findTextBox.Text}&format=json";
            string json = "";
            WebClient client = new WebClient();
            using (Stream stream = client.OpenRead(geoCodeUrl))
            {
                using (var reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        json += line;
                    }
                }
            }
            GeoCodeService geoCodeService = new GeoCodeService();
            geoCodeService = JsonConvert.DeserializeObject<GeoCodeService>(json);
            if (geoCodeService.Response.GeoObjectCollection.MetaDataProperty.GeocoderResponseMetaData.BoundedBy is null)
            {
                MessageBox.Show("Wrong input!");
                return;
            }
            #endregion

            #region Получение данных о погоде
            
            bool isLongitude = true;
            string longitude = "";
            string latitude = "";

            foreach (var symbol in geoCodeService.Response.GeoObjectCollection.MetaDataProperty.GeocoderResponseMetaData.BoundedBy.Position.LowerCorner)
            {
                if (symbol == ' ')
                {
                    isLongitude = false;
                    continue;
                }
                if (isLongitude)
                {
                    longitude += symbol;
                }
                else
                {
                    latitude += symbol;
                }
            }
            
            WebRequest request = WebRequest.Create($"https://api.weather.yandex.ru/v1/forecast?lat={latitude}lon={longitude}&extra=true&lang=ru_RU&limit=7");
            request.Headers.Add("X-Yandex-API-Key", "2f174269-cd88-4e10-9520-9a1e8f51dcf4");
            WebResponse response = request.GetResponse();
            json = "";
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        json += line;
                    }
                }
            }
            response.Close();

            Weather weather = new Weather();

            weather = JsonConvert.DeserializeObject<Weather>(json);

            #endregion

            todayDockPanel.IsEnabled = true;
            daysStackPanel.IsEnabled = true;


            #region Заполнение данными
            firstDateLable.Content = weather.Forecasts[0].Date;

            firstDayWeatherImage.Kind = GetWeatherImage(weather.Forecasts[0].Parts.Day);

            firstNightTemperatureLable.Content = weather.Forecasts[0].Parts.Night.TempAvg.ToString();
            firstMorningTemperatureLable.Content = weather.Forecasts[0].Parts.Morning.TempAvg.ToString();
            firstDayTemperatureLable.Content = weather.Forecasts[0].Parts.Day.TempAvg.ToString();
            firstEveningTemperatureLable.Content = weather.Forecasts[0].Parts.Evening.TempAvg.ToString();


            secondDateLable.Content = weather.Forecasts[1].Date;

            secondDayWeatherImage.Kind = GetWeatherImage(weather.Forecasts[1].Parts.Day);

            secondNightTemperatureLable.Content = weather.Forecasts[1].Parts.Night.TempAvg.ToString();
            secondMorningTemperatureLable.Content = weather.Forecasts[1].Parts.Morning.TempAvg.ToString();
            secondDayTemperatureLable.Content = weather.Forecasts[1].Parts.Day.TempAvg.ToString();
            secondEveningTemperatureLable.Content = weather.Forecasts[1].Parts.Evening.TempAvg.ToString();


            thirdDateLable.Content = weather.Forecasts[2].Date;

            thirdDayWeatherImage.Kind = GetWeatherImage(weather.Forecasts[2].Parts.Day);

            thirdNightTemperatureLable.Content = weather.Forecasts[2].Parts.Night.TempAvg.ToString();
            thirdMorningTemperatureLable.Content = weather.Forecasts[2].Parts.Morning.TempAvg.ToString();
            thirdDayTemperatureLable.Content = weather.Forecasts[2].Parts.Day.TempAvg.ToString();
            thirdEveningTemperatureLable.Content = weather.Forecasts[2].Parts.Evening.TempAvg.ToString();


            fourthDateLable.Content = weather.Forecasts[3].Date;

            fourthDayWeatherImage.Kind = GetWeatherImage(weather.Forecasts[3].Parts.Day);

            fourthNightTemperatureLable.Content = weather.Forecasts[3].Parts.Night.TempAvg.ToString();
            fourthMorningTemperatureLable.Content = weather.Forecasts[3].Parts.Morning.TempAvg.ToString();
            fourthDayTemperatureLable.Content = weather.Forecasts[3].Parts.Day.TempAvg.ToString();
            fourthEveningTemperatureLable.Content = weather.Forecasts[3].Parts.Evening.TempAvg.ToString();


            fifthDateLable.Content = weather.Forecasts[4].Date;

            fifthDayWeatherImage.Kind = GetWeatherImage(weather.Forecasts[4].Parts.Day);

            fifthNightTemperatureLable.Content = weather.Forecasts[4].Parts.Night.TempAvg.ToString();
            fifthMorningTemperatureLable.Content = weather.Forecasts[4].Parts.Morning.TempAvg.ToString();
            fifthDayTemperatureLable.Content = weather.Forecasts[4].Parts.Day.TempAvg.ToString();
            fifthEveningTemperatureLable.Content = weather.Forecasts[4].Parts.Evening.TempAvg.ToString();


            sixthDateLable.Content = weather.Forecasts[5].Date;

            sixthDayWeatherImage.Kind = GetWeatherImage(weather.Forecasts[5].Parts.Day);

            sixthNightTemperatureLable.Content = weather.Forecasts[5].Parts.Night.TempAvg.ToString();
            sixthMorningTemperatureLable.Content = weather.Forecasts[5].Parts.Morning.TempAvg.ToString();
            sixthDayTemperatureLable.Content = weather.Forecasts[5].Parts.Day.TempAvg.ToString();
            sixthEveningTemperatureLable.Content = weather.Forecasts[5].Parts.Evening.TempAvg.ToString();


            seventhDateLable.Content = weather.Forecasts[6].Date;

            seventhDayWeatherImage.Kind = GetWeatherImage(weather.Forecasts[6].Parts.Day);

            seventhNightTemperatureLable.Content = weather.Forecasts[6].Parts.Night.TempAvg.ToString();
            seventhMorningTemperatureLable.Content = weather.Forecasts[6].Parts.Morning.TempAvg.ToString();
            seventhDayTemperatureLable.Content = weather.Forecasts[6].Parts.Day.TempAvg.ToString();
            seventhEveningTemperatureLable.Content = weather.Forecasts[6].Parts.Evening.TempAvg.ToString();
            #endregion
        }


        private MaterialDesignThemes.Wpf.PackIconKind GetWeatherImage(Day day)
        {

            if (day.Condition.Contains("rain"))
            {
                return MaterialDesignThemes.Wpf.PackIconKind.WeatherRainy;
            }
            if (day.Condition.Contains("clear"))
            {
                return MaterialDesignThemes.Wpf.PackIconKind.WeatherSunny;
            }
            if (day.Condition.Contains("overcast"))
            {
                return MaterialDesignThemes.Wpf.PackIconKind.WeatherCloudy;
            }
            if (day.Condition.Contains("cloud"))
            {
                return MaterialDesignThemes.Wpf.PackIconKind.WeatherCloudy;
            }

            return MaterialDesignThemes.Wpf.PackIconKind.WeatherSnowy;
        }
    }
}
