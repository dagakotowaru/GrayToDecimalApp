using System;
using System.Windows;

namespace GrayToDecimalApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // получаем введенный код Грея
                string grayCode = GrayInput.Text;

                // конвертируем код Грея в двоичный
                string binaryCode = GrayToBinary(grayCode);

                // конвертируем двоичный код в десятичное число
                int decimalNumber = Convert.ToInt32(binaryCode, 2);

                // выводим результат
                DecimalOutput.Text = decimalNumber.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // метод для конвертации кода Грея в двоичный код
        private string GrayToBinary(string grayCode)
        {
            if (string.IsNullOrEmpty(grayCode))
                throw new ArgumentException("Код Грея не может быть пустым.");

            char[] binary = new char[grayCode.Length];

            // первый бит двоичного кода такой же, как и в коде Грея
            binary[0] = grayCode[0];

            // преобразование кода Грея в двоичный
            for (int i = 1; i < grayCode.Length; i++)
            {
                if (grayCode[i] == '0')
                    binary[i] = binary[i - 1]; // Если бит Грея 0, следующий бит такой же
                else
                    binary[i] = binary[i - 1] == '0' ? '1' : '0'; // Если бит Грея 1, меняем бит
            }

            return new string(binary);
        }
    }
}
