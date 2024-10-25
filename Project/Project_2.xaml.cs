using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Documents;
using Microsoft.Office.Interop.Word;


namespace Project
{
    /// <summary>
    /// Логика взаимодействия для Project_2.xaml
    /// </summary>
    public partial class Project_2
    {
        public Project_2() { InitializeComponent(); }
        private void Exit_Click(object sender, RoutedEventArgs e) { Close(); }
        private void dropZoneGrid_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effects = DragDropEffects.Copy;
            else e.Effects = DragDropEffects.None;
        }
        private void dropZoneGrid_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string filePath = files[0];
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                wordApp.Visible = false;
                Document doc = null;
                try
                {
                    doc = wordApp.Documents.Open(filePath);
                    doc.PageSetup.LeftMargin = 28.35F;
                    Font font = doc.Content.Font;
                    ParagraphFormat paragraphFormat = doc.Content.ParagraphFormat;
                    font.Name = "Times New Roman";
                    font.Size = 14;
                    font.Bold = 0;
                    font.Italic = 0;
                    font.Underline = WdUnderline.wdUnderlineNone;
                    font.StrikeThrough = 0;
                    font.Color = WdColor.wdColorBlack;
                    font.Superscript = 0;
                    font.Subscript = 0;
                    paragraphFormat.FirstLineIndent = doc.Application.CentimetersToPoints(1.25f);
                    paragraphFormat.LeftIndent = 0;
                    paragraphFormat.RightIndent = 0;
                    paragraphFormat.SpaceAfter = 0;
                    paragraphFormat.SpaceBefore = 0;
                    paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                    paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpace1pt5;
                    doc.Content.HighlightColorIndex = WdColorIndex.wdNoHighlight;
                    /*
                    "^l", // Мягкий разрыв строки
                    "^w", // Любые пробелы
                    "^11",// Вертикальная табуляция
                    "^d", // Поле
                    "^g", // Графический элемент//
                    "^~", // Неразрывный дефис
                    "^-", // Опциональный дефис
                    "^s", // Неразрывный пробел
                    "^a", // Аннотация
                    "^u", // Ручной разрыв колонок
                    */
                    string[] symbolsToReplace = { "^u", "^a", "^s", "^-", "^~", "^d", "^11", "^w", "^l" };
                    foreach (string findText in symbolsToReplace)
                    {
                        Find findObject = doc.Content.Find;
                        findObject.ClearFormatting();
                        findObject.Text = findText;
                        findObject.Replacement.ClearFormatting();
                        findObject.Replacement.Text = " ";
                        findObject.Execute(Replace: WdReplace.wdReplaceAll, Wrap: WdFindWrap.wdFindContinue);
                    }

                    if (doc.Comments.Count > 0) doc.DeleteAllComments();//коментарии
                    doc.SaveAs2(filePath, WdSaveFormat.wdFormatDocumentDefault);
                    MessageBox.Show("Ваш документ готов!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
                finally
                {
                    if (doc != null) doc.Close(WdSaveOptions.wdDoNotSaveChanges);
                    wordApp.Quit();
                    Marshal.ReleaseComObject(wordApp);
                }
            }
        }
        private void Exit2_Click(object sender, RoutedEventArgs e) { Close(); }
        private void AboutAndProgram_Click(object sender, RoutedEventArgs e)
        {
            AboutAndProgram aboutAndProgram = new AboutAndProgram();
            aboutAndProgram.Show();
        }
    }
}
