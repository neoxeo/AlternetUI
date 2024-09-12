﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ControlsSample
{
    public static class PropNamesRu
    {
        public static class ControlProperties
        {
            public static string Layout = "Макет";
            public static string Title = "Заголовок";
            public static string Dock = "Докирование";
            public static string Text = "Текст";
            public static string ToolTip = "Подсказка";
            public static string Left = "Лево";
            public static string Top = "Верх";
            public static string Visible = "Видимый";
            public static string Enabled = "Включено";
            public static string Width = "Ширина";
            public static string Height = "Высота";
            public static string SuggestedWidth = "Желаем ширина";
            public static string SuggestedHeight = "Желаем высота";
            public static string MinChildMargin = "Мин отступ детей";
            public static string Margin = "Внешний отступ";
            public static string Padding = "Внутр отступ";
            public static string MinWidth = "Мин ширина";
            public static string MinHeight = "Мин высота";
            public static string MaxWidth = "Макс ширина";
            public static string MaxHeight = "Макс высота";
            public static string BackgroundColor = "Цвет фона";
            public static string ParentBackColor = "Цвет фона родителя";
            public static string ParentForeColor = "Цвет текста родителя";
            public static string ParentFont = "Шрифт родителя";
            public static string ForegroundColor = "Цвет текста";
            public static string Font = "Шрифт";
            public static string IsBold = "Жирный шрифт";
            public static string VerticalAlignment = "Вертикальн полож";
            public static string HorizontalAlignment = "Горизонт полож";
            public static string CanFocus = "Могу фокус";
            public static string TabStop = "Таб остановка";
            public static string CanSelect = "Могу выбрать";
            public static string Background = "Покрасить фон";
        }

        public static class BaseComponentProperties
        {
            public static string Name = "(Имя)";
            public static string Tag = "Таг";
        }

        public static class BorderProperties
        {
            public static string BorderWidth = "Ширина границ";
            public static string UniformCornerRadius = "Общ радиус угла";
            public static string UniformRadiusIsPercent = "Радиус угла процент";
            public static string UniformBorderWidth = "Общ ширина границ";
            public static string BorderColor = "Цвет границ";
        }

        public static class UserControlProperties
        {
            public static string ScrollBars = "Скроллбары";
            public static string DropDownMenu = "Выпадающее меню";
            public static string WantChars = "Разреш ввод символов";
            public static string HasBorder = "Показать границу";
        }

        public static class ButtonProperties
        {
            public static string HasBorder = "Показать границу";
            public static string Image = "Картинка";
            public static string HoveredImage = "Картинка активно";
            public static string FocusedImage = "Картинка фокус";
            public static string PressedImage = "Картинка нажато";
            public static string DisabledImage = "Картинка неактивно";
            public static string UseVisualStyleBackColor = "Использ фон стиля";
            public static string IsDefault = "Кнопка по умолч";
            public static string ExactFit = "Точный размер";
            public static string IsCancel = "Кнопка отмены";
            public static string TextVisible = "Показать текст";
            public static string TextAlign = "Выравнивание текста";
        }

        public static class CheckBoxProperties
        {
            public static string CheckState = "Состояние отметки";
            public static string ThreeState = "Три состояния";
            public static string AlignRight = "Выравнивание вправо";
            public static string AllowAllStatesForUser = "Разреш три состоян";
            public static string IsChecked = "Отмечено";
        }

        public static class RadioButtonProperties
        {
            public static string IsChecked = "Отмечено";
        }
    }
}