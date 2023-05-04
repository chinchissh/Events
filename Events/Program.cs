using System;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWriter fileWriter = new FileWriter("test.txt"); // создаем объект FileWriter для записи текста в файл test.txt
            Robot robot = new Robot(); // создаем объект Robot
            robot.MoveBackwards += (sender, direction) => // добавляем обработчик события MoveBackwards
            {
                string message = $"Robot moved {direction}"; // формируем сообщение о перемещении робота
                fileWriter.WriteToFile(message); // записываем сообщение в файл
                Console.WriteLine(message); // выводим сообщение в консоль
            };
            robot.StartMoving(); // запускаем робота

            Console.ReadKey(); // ожидаем нажатия любой клавиши, чтобы завершить работу
        }
    }
}