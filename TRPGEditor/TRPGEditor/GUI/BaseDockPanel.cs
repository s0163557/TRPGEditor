using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TRPGEditor.Base;

namespace TRPGEditor.GUI
{
    // Подкласс DockPanel для отображения двух StackPanel друг с другом.
    // По задумке, слева должны быть статические элементы, справа - динамические.
    internal class BaseDockPanel : DockPanel
    {
        SimpleBase simpleBase;
        StackPanel left = new StackPanel(), right = new StackPanel();

        public BaseDockPanel() 
        {
            // Создание текстовых полей для отображения.
            Label staticStringLabel = new Label();
            Label dynamicStringLabel = new Label();
            staticStringLabel.Content = "Статические объекты:";
            dynamicStringLabel.Content = "Динамические объекты:";

            // В будущем заменить их на действительные элементы из SimpleBase.
            Button testbutton = new Button();
            testbutton.Content = "Тестовая кнопка 1";
            testbutton.Height = 100;
            Button testbutton2 = new Button();
            testbutton2.Content = "Тестовая кнопка 2";
            testbutton2.Height = 100;
            this.Height = 200;

            // Заполнение левого StackPanel.
            left.Orientation = Orientation.Vertical;
            // При растягивании окна размер остаётся тем же. Найти способ лучше организовать пространство.
            left.Width = 400;
            left.Children.Add(staticStringLabel);
            left.Children.Add(testbutton);
            this.Children.Add(left);

            // Заполнение правого StackPanel.
            right.Orientation = Orientation.Vertical;
            right.Children.Add(dynamicStringLabel);
            right.Children.Add(testbutton2);
            this.Children.Add(right);
        }
    }
}
