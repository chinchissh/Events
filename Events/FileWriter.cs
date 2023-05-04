using System.IO;

namespace Events
{
    public class FileWriter//Лабораторная работа по Мищенко №11(3_1)
    {
        private readonly string filePath; // путь к файлу

        public FileWriter(string filePath)
        {
            this.filePath = filePath; // сохраняем путь к файлу
        }

        public void WriteToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.Default)) // создаем объект StreamWriter для записи текста в файл
            {
                sw.WriteLine(text); // записываем текст в файл
            }
        }
    }
}