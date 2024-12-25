using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // Структура для хранения информации о книге
    public struct Книга
    {
        public string Название; // Название книги
        public string Автор; // Автор книги
        public string Издательство; // Издательство книги
        public int КоличествоСтраниц; // Количество страниц в книге

        // Конструктор структуры
        public Книга(string название, string автор, string издательство, int количествоСтраниц)
        {
            Название = название; // Инициализация названия
            Автор = автор; // Инициализация автора
            Издательство = издательство; // Инициализация издательства
            КоличествоСтраниц = количествоСтраниц; // Инициализация количества страниц
        }

        // Метод для получения информации о книге в виде строки
        public override string ToString()
        {
            return $"{Название}, {Автор}, {Издательство}, {КоличествоСтраниц} стр."; // Формирование строки информации о книге
        }
    }

    public partial class MainWindow : Window
    {
        private List<Книга> книги; // Список книг

        public MainWindow()
        {
            InitializeComponent(); // Инициализация компонентов окна

            // Инициализация списка книг с примерами данных
            книги = new List<Книга>
            {
                new Книга("Война и мир", "Лев Толстой", "Эксмо", 1200), // Добавление книги в список
                new Книга("1984", "Джордж Оруэлл", "АСТ", 300), // Добавление книги в список
                new Книга("Мастер и Маргарита", "Михаил Булгаков", "АСТ", 400), // Добавление книги в список
                new Книга("Преступление и наказание", "Федор Достоевский", "Эксмо", 500), // Добавление книги в список
                new Книга("Гарри Поттер и философский камень", "Джоан Роулинг", "Росмэн", 300) // Добавление книги в список
            };

            // Вывод всех книг в ListBox при запуске приложения
            foreach (var книга in книги)
            {
                listBoxBooks.Items.Add(книга); // Добавление каждой книги в список на экране
            }
        }

        private void ShowBooks_Click(object sender, RoutedEventArgs e)
        {
            listBoxBooks.Items.Clear(); // Очистка списка перед выводом новых данных

            string издательство = textBoxPublisher.Text; // Получение введенного издательства

            // Фильтрация книг по введенному издательству и добавление их в список
            var отфильтрованныеКниги = книги.Where(k => k.Издательство.Equals(издательство, StringComparison.OrdinalIgnoreCase));

            foreach (var книга in отфильтрованныеКниги)
            {
                listBoxBooks.Items.Add(книга); // Добавление отфильтрованных книг в ListBox
            }

            if (!отфильтрованныеКниги.Any()) // Проверка, есть ли отфильтрованные книги
            {
                MessageBox.Show("Книги с таким издательством не найдены.", "Информация"); // Сообщение об отсутствии книг с заданным издательством
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Закрытие приложения при нажатии кнопки "Выход"
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Кошеренков Максим Сергеевич\nНомер работы: 9\nЗадание: Заполнить таблицу с учебной литературой.", "О программе");
            // Вывод информации о разработчике и задании при нажатии кнопки "О программе"
        }
    }
}