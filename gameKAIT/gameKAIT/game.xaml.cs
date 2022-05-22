using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gameKAIT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class game : ContentPage
    {
        public game()
        {
            InitializeComponent();
            Mama(); // заполнить массив рандомными
            Play(); // первичный запуск игры, далее она запускается в случае победы

        }
        List<SolidColorBrush> massiv = new List<SolidColorBrush>(); //массив кнопок цветов
        int iteration = 0; //ходы игрока
        int num = 3; //стартовое количество кнопок

        public void Mama()
        {
            Random rnd = new Random();
            for (int i = 1; i < 21; i++)
            {
                switch (rnd.Next(1, 4))  // рандом от 1 до 3, если падает 3 то в массив зальется синий
                {
                    case 1:
                        massiv.Add(new SolidColorBrush(Color.Green));
                        break;
                    case 2:
                        massiv.Add(new SolidColorBrush(Color.Red));
                        break;
                    case 3:
                        massiv.Add(new SolidColorBrush(Color.Blue));
                        break;
                }
            }// задали массив цветов

        }

        private async void Play()
        {
            Green.Background = new SolidColorBrush(Color.Gray);
            Red.Background = new SolidColorBrush(Color.Gray);
            Blue.Background = new SolidColorBrush(Color.Gray);
            await Task.Delay(TimeSpan.FromSeconds(1));
            for (int i = 0; i < num; i++)
            {
                if (massiv[i].Color == new SolidColorBrush(Color.Green).Color) // если цвет массива совпадает с цветом условия то красит
                {
                    Green.Background = massiv[i]; //цвет ставится из массива цветов
                }
                else if (massiv[i].Color == new SolidColorBrush(Color.Red).Color)
                {
                    Red.Background = massiv[i];

                }
                else if (massiv[i].Color == new SolidColorBrush(Color.Blue).Color)
                {
                    Blue.Background = massiv[i];
                }
                await Task.Delay(TimeSpan.FromSeconds(1));

                Green.Background = new SolidColorBrush(Color.Gray);
                Red.Background = new SolidColorBrush(Color.Gray);
                Blue.Background = new SolidColorBrush(Color.Gray);
                await Task.Delay(TimeSpan.FromSeconds(1)); 
            }
            Green.Background = new SolidColorBrush(Color.Green);
            Red.Background = new SolidColorBrush(Color.Red);
            Blue.Background = new SolidColorBrush(Color.Blue); //перекраска кнопок
        }
        private void Green_Click(object sender, EventArgs e)
        {
            if (iteration == num - 1)
            {
                DisplayAlert ("Внимание", "Вы победили!", "ОК");
                num++;
                Play();
                iteration = 0;
            }
            else
            {
                if (massiv[iteration].Color == new SolidColorBrush(Color.Green).Color)
                {
                    iteration++;
                }
                else
                {
                    iteration = 0;
                    DisplayAlert("Внимание", "Вы проиграли!", "ОК");
                }
            }

        }

        private void Red_Click(object sender, EventArgs e)
        {
            if (iteration == num - 1)
            {
                DisplayAlert("Внимание", "Вы победили!", "ОК");
                num++;
                Play();
                iteration = 0;

            }
            else
            {
                if (massiv[iteration].Color == new SolidColorBrush(Color.Red).Color)
                {
                    iteration++;
                }
                else
                {
                    iteration = 0;
                    DisplayAlert("Внимание", "Вы проиграли!", "ОК");
                }
            }
        }

        private void Blue_Click(object sender, EventArgs e)
        {
            if (iteration == num - 1) // если количество нажатых равно количеству показанных, то победа, старт игры с новой кнопкой и сброс итераций
            {
                DisplayAlert("Внимание", "Вы победили!", "ОК");
                num++; // количество показанных тебе кнопок ранее
                Play();
                iteration = 0;

            }
            else
            {
                if (massiv[iteration].Color == new SolidColorBrush(Color.Blue).Color)
                {
                    iteration++;
                }
                else
                {
                    iteration = 0; //сброс правильных ходов
                    DisplayAlert("Внимание", "Вы проиграли!", "ОК");  //ВЫвод о проигрыше
                }
            }
        }
    }
}