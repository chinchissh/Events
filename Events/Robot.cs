using System;
using System.Threading;

namespace Events
{
    public class Robot
    {
        private readonly Random random; // объект класса Random для генерации случайных чисел
        public event EventHandler<string> MoveBackwards; // событие MoveBackwards, которое генерируется при выборе роботом направления "назад"

        public Robot()
        {
            random = new Random(); // инициализируем объект Random
        }

        public void StartMoving()
        {
            new Thread(() => // создаем новый поток
            {
                while (true) // бесконечный цикл
                {
                    int direction = random.Next(4); // генерируем случайное число от 0 до 3 (направление движения робота)
                    string directionString = ""; // строковая переменная для хранения направления движения в текстовом виде
                    switch (direction) // выбираем текстовое направление в зависимости от сгенерированного числа
                    {
                        case 0:
                            directionString = "forward";
                            break;
                        case 1:
                            directionString = "backward";
                            MoveBackwards?.Invoke(this, directionString); // если робот выбрал направление "назад", генерируем событие MoveBackwards
                            break;
                        case 2:
                            directionString = "left";
                            break;
                        case 3:
                            directionString = "right";
                            break;
                    }
                    Console.WriteLine($"Robot moves {directionString}"); // выводим направление движения робота в консоль
                    Thread.Sleep(1000); // засыпаем на 1 секунду
                }
            }).Start(); // запускаем поток
        }
    }
}