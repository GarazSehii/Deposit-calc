using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Deposit_calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string[] _buttonStyles = { "GlassButtonOne", "GlassButtonSix", "GlassButtonTwo", "GlassButtonFive", "GlassButtonThree", "GlassButtonFour", "btn3DStyle", "BbButton", "controlButtonTemplate", "controlButtonTemplate2" };
        private string[] _textBoxStyles = { "GlassTextBoxOne", "GlassTextBoxSix", "GlassTextBoxTwo", "GlassTextBoxFive", "GlassTextBoxThree", "GlassTextBoxFour", "GlassTextBoxFour", "GlassTextBoxFive", "GlassTextBoxThree", "GlassTextBoxTwo" };
        private string[] _comboBoxStyles = { "ComboBoxStyle", "ComboBoxStyleSix", "ComboBoxStyleTwo", "ComboBoxStyleFive", "ComboBoxStyleThree", "ComboBoxStyleFour", "ComboBoxStyleFour", "ComboBoxStyleFive", "ComboBoxStyleThree", "ComboBoxStyleTwo" };
        private string[] _BacgroundImages = { "021_WallpapersAmazingCar_010609_Go2LoadCOM.jpg",
                                              "60679466.jpg","rgeye-1024.jpg",
                                              "skachat-oboi-rabochego-stola-besplatno.jpg",
                                              "look.com.ua-51681.jpg",
                                              "look.com.ua-57487.jpg",
                                              "url.jpg",
                                              "1405269791_rabochego_stola_vodopad._13.jpg",
                                              "HD.at.ua-1920-1080-02-19.jpg",
                                              "game_b107.jpg"};
        private int _currentStyleIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_currentStyleIndex >= _buttonStyles.Length - 1)
                _currentStyleIndex = 0;
            else
            {
                _currentStyleIndex++;
            }

            
            string basePath = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\net7.0-windows\\", "");
            ImageBrush myBrush = new ImageBrush();
            string uri = new Uri(basePath + @"images\" + _BacgroundImages[_currentStyleIndex], UriKind.Relative).ToString();
            myBrush.ImageSource = new BitmapImage(new Uri(uri, UriKind.Relative));
            this.Background = myBrush;
       
            foreach (var control in CalcGrid.Children)
            {
                if (control is Button)
                {   
                    (control as Button).Style = (Style)FindResource(_buttonStyles[_currentStyleIndex]);
                    (control as Button).Opacity = 1;
                }
                if (control is TextBox)
                {
                    (control as TextBox).Style = (Style)FindResource(_textBoxStyles[_currentStyleIndex]);
                }
                if (control is ComboBox)
                {
                    (control as ComboBox).Style = (Style)FindResource(_comboBoxStyles[_currentStyleIndex]);
                }
               
            }
        }
    }
}
